"use client";

import React, { useEffect, useState } from "react";
import axios from "axios";
import Link from "next/link";

interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  imageurl: string;
}

export default function ProductList() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    // Fetch products from the API
    axios
      .get("https://localhost:7120/api/products")
      .then((response) => {
        const fetchedProducts = response.data.data; // Assuming the data is in the 'data' field
        setProducts(fetchedProducts);

        // Log the image URLs to the console
        fetchedProducts.forEach((product: Product) => {
          console.log(product.imageurl); // Log each image URL
        });
      })
      .catch((error) => {
        console.error("Error fetching products", error);
      });
  }, []);

  return (
    <>
      <h1>Product List</h1>
      <div style={{ display: "grid", gridTemplateColumns: "repeat(4, 1fr)", gap: "20px" }}>
        {products.map((product) => (
          <div key={product.id} className="card" style={{ display: "flex", alignItems: "flex-start" }}>
          <Link href={`/products/${product.id}`}>
            <div className="imageContainer">
              <img
                src={product.imageurl}
                alt={product.name}
                style={{ width: "100%", height: "auto", objectFit: "cover" }} // Use object-fit to maintain aspect ratio
              />
            </div>
          </Link>
          <div className="details">
            <h2 style={{ margin: 0 }}>{product.name}</h2>
            <p>{product.description}</p>
            <p className="price">Price: ${product.price}</p>
            <button className="addToCartBtn">Add to Cart</button>
          </div>
        </div>        
        ))}
      </div>
    </>
  );
}
