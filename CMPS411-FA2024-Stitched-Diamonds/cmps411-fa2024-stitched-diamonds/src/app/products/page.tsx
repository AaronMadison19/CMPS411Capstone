"use client";

import React, { useEffect, useState } from "react";
import axios from "axios";
import Link from "next/link";

interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
}

export default function ProductList() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    axios
      .get("https://localhost:7120/api/products")
      .then((response) => {
        setProducts(response.data.data); // Assuming products are under 'data'
        console.log("Fetched products:", response.data.data);
      })
      .catch((error) => {
        console.error("Error fetching products", error);
      });
  }, []);

  return (
    <div className="bg-white">
      <div className="mx-auto max-w-2xl px-4 py-16 sm:px-6 sm:py-24 lg:max-w-7xl lg:px-8">
        <h2 className="text-2xl font-bold tracking-tight text-gray-900">
          Products
        </h2>

        <div className="mt-6 grid grid-cols-1 gap-y-10 gap-x-6 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 xl:gap-x-8">
          {products.map((product) => {
            console.log("Dynamic Image Url:", product.imageUrl); // Log the image URL here
            return (
              <Link
                key={product.id}
                href={`/products/${product.id}`}
                className="group"
              >
                <div className="aspect-w-1 aspect-h-1 w-full overflow-hidden rounded-lg bg-gray-200 xl:aspect-w-7 xl:aspect-h-8">
                  <img
                    src={product.imageUrl} // Use dynamic URL
                    alt={product.name}
                    onError={(e) => {
                      e.currentTarget.src = "/assets/mocha-cardigan.jpg";
                    }}
                    className="h-full w-full object-cover object-center transition-opacity duration-300 group-hover:opacity-75"
                  />
                </div>
                <h3 className="mt-4 text-sm text-gray-700">{product.name}</h3>
                <p className="mt-1 text-lg font-medium text-gray-900">
                  ${product.price.toFixed(2)}
                </p>
              </Link>
            );
          })}
        </div>
      </div>
    </div>
  );
}
