import React from "react";
import Link from "next/link"
/*
const Product = () => {
  return <div>Products Page</div>;
};

export default Product;
*/

export default function ProductList() {
  return (
    <>
      <h1>Product List</h1>
      <h2>Product 1</h2>
      <h2>Product 2</h2>
      <Link href= "/products/3">
      <h2>Product 3</h2>
      </Link>
    </>
  );
}