"use client";  // Client-side rendering

import { useState } from 'react';
import Link from 'next/link';

const Navbar = () => {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const toggleMenu = () => setIsMenuOpen(!isMenuOpen);

  return (
    <header className="bg-gradient-to-r from-indigo-700 via-purple-600 to-blue-500 fixed top-0 left-0 w-full z-50 shadow-xl">
      <div className="container mx-auto px-6 py-4 flex justify-between items-center">
        {/* Logo/Brand Name */}
        <h1 className="text-3xl font-extrabold text-white tracking-wide cursor-pointer hover:text-yellow-400 transition duration-300 ease-in-out">
          Stitched <span className="text-yellow-400">Diamonds</span>
        </h1>

        {/* Desktop Navbar */}
        <nav className="hidden md:flex space-x-8 items-center">
          <Link href="/" className="text-white hover:text-yellow-400 transition duration-300 ease-in-out">Home</Link>
          <Link href="/products" className="text-white hover:text-yellow-400 transition duration-300 ease-in-out">Shop</Link>
          <Link href="/about" className="text-white hover:text-yellow-400 transition duration-300 ease-in-out">About Us</Link>
          <Link href="/contact1" className="text-white hover:text-yellow-400 transition duration-300 ease-in-out">Contact</Link>
          <Link href="/account" className="text-white hover:text-yellow-400 transition duration-300 ease-in-out">Account</Link>
          {/* CTA Button */}
          <Link href="/login" className="bg-yellow-400 text-black px-6 py-3 rounded-full font-semibold shadow-xl hover:bg-yellow-500 transition duration-300 ease-in-out">Log In</Link>
        </nav>

        {/* Mobile Navbar (Hamburger Menu) */}
        <div className="md:hidden flex items-center">
          <button onClick={toggleMenu} className="text-white focus:outline-none">
            <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M4 6h16M4 12h16M4 18h16"></path>
            </svg>
          </button>
        </div>
      </div>

      {/* Mobile Menu Dropdown */}
      <div className={`md:hidden ${isMenuOpen ? 'block' : 'hidden'} transition-all duration-300 ease-in-out`}>
        <nav className="flex flex-col items-center space-y-6 py-6 bg-gradient-to-r from-indigo-700 via-purple-600 to-blue-500 rounded-b-xl shadow-2xl">
          <Link href="/" className="text-white hover:text-yellow-400 transition duration-300 ease-in-out">Home</Link>
          <Link href="/shop" className="text-white hover:text-yellow-400 transition duration-300 ease-in-out">Shop</Link>
          <Link href="/about" className="text-white hover:text-yellow-400 transition duration-300 ease-in-out">About Us</Link>
          <Link href="/contact" className="text-white hover:text-yellow-400 transition duration-300 ease-in-out">Contact</Link>
          {/* Mobile CTA Button */}
          <Link href="/signup" className="bg-yellow-400 text-black px-6 py-3 rounded-full font-semibold shadow-xl hover:bg-yellow-500 transition duration-300 ease-in-out">Sign Up</Link>
        </nav>
      </div>
    </header>
  );
};

export default Navbar;
