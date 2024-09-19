import React from "react";
import Link from "next/link";

const Navbar = () => {
  return (
    <>
            <ul className="hidden md:flex gap-x-6">
              <li>
                <Link href="/about" className = "mr-6">
                     About Us 
                </Link>
                <Link href="/contact">
                     Contact Us 
                </Link>
                <Link href="/products">
                  Products
                </Link>
             </li>
           </ul>
    </>
  );
};

export default Navbar;