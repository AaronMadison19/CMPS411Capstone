import React from "react";
import Link from "next/link";
import styles from "./styles/navbar.module.css";

const Navbar = () => {
  return (
    <ul
      style={{
        display: "flex",
        listStyle: "none",
        padding: 0,
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <li className={styles.navbar}>
        <Link href="/">Home</Link>
      </li>

      <li className={styles.navbar}>
        <Link href="/about">About Us</Link>
      </li>

      <li className={styles.navbar}>
        <Link href="/contact">Contact Us</Link>
      </li>

      <li className={styles.navbar}>
        <Link href="/products">Products</Link>
      </li>

      <li className={styles.navbar}>
        <Link href="/login">Login</Link>
      </li>

      <li className={styles.navbar}>
        <Link href="/account">Account</Link>
      </li>
    </ul>
  );
};

export default Navbar;
