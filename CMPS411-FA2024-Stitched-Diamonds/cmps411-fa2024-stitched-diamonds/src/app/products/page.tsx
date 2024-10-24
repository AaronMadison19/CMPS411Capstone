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
        setProducts(response.data.data); // Assuming the data is in the 'data' field
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
          <div key={product.id} style={{ border: "1px solid #ccc", padding: "10px" }}>
            <Link href={`/products/${product.id}`}>
              <h2>{product.name}</h2>
            </Link>
            <p>{product.description}</p>
            <p>Price: ${product.price}</p>
            <img src={product.imageurl} alt={product.name} style={{ width: "100%", height: "auto" }} />
          </div>
        ))}
      </div>
    </>
  );
}