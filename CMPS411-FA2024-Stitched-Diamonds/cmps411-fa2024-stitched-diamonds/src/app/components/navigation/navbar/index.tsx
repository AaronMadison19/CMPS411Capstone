import React from "react";
import Link from "next/link";

const Navbar = () => {
  return (
    <ul style={{ display: 'flex', listStyle: 'none', padding: 0 }}>

      <li style={{ marginRight: '20px' }}>
        <Link href="/">
        Home
        </Link>
      </li>

      <li style={{ marginRight: '20px' }}>
        <Link href="/about">
        About Us
        </Link>
      </li>

      <li style={{ marginRight: '20px' }}>
        <Link href="/contact">
        Contact Us
        </Link>
      </li>

      <li style={{ marginRight: '20px' }}>
        <Link href="/products">
        Products
        </Link>
      </li>

      <li style={{ marginRight: '20px' }}>
        <Link href="/account">
        Account
        </Link>
      </li>
      
    </ul>
  );
};

export default Navbar;