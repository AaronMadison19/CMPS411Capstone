"use client";  // Client-side rendering

// import { useState } from 'react';
import React, { useState } from "react";
import Link from 'next/link';

const Navbar = () => {
  const [isMenuOpen, setIsMenuOpen] = useState(false);
  const [isLoggedIn, setIsLoggedIn] = useState(false); // Track login state
  const toggleMenu = () => setIsMenuOpen(!isMenuOpen);
  const [isDropdownOpen, setIsDropdownOpen] = useState(false); // Dropdown menu state

  const handleLogin = () => {
    // Simulate login and store a token
    // const token = "user-auth-token"; // Replace with real token from backend
    // localStorage.setItem("authToken", token);
    setIsLoggedIn(true);
    window.location.href = "/login"; // Redirect
  };

  const handleLogout = () => {
    // localStorage.removeItem("authToken"); // Clear the token
    setIsLoggedIn(false);
    window.location.href = "/login"; // Redirect
  };


  const toggleDropdown = () => {
    setIsDropdownOpen(!isDropdownOpen);
  };

  return (
    <header className="bg-gradient-to-r from-indigo-700 via-purple-600 to-blue-500 fixed top-0 left-0 w-full z-50 shadow-xl">
      <div className="container mx-auto px-6 py-4 flex justify-between items-center">
        {/* Logo/Brand Name */}
        {/* <h1 className="text-3xl font-extrabold text-white tracking-wide cursor-pointer hover:text-yellow-400 transition duration-300 ease-in-out">
          Stitched <span className="text-yellow-400">Diamonds</span>
        </h1> */}

        <h1 className="text-3xl font-extrabold text-white tracking-wide cursor-pointer hover:text-yellow-400 transition duration-300 ease-in-out">
          <Link href="/" className="text-3xl font-extrabold text-white tracking-wide cursor-pointer hover:text-yellow-400 transition duration-300 ease-in-out">
              Stitched <span className="text-yellow-400">Diamonds</span>
          </Link>
        </h1>        

        {/* Desktop Navbar */}
        <nav className="hidden md:flex space-x-8 items-center">
          <Link href="/products" className="text-white hover:text-yellow-400 transition duration-300 ease-in-out">Shop</Link>
          <Link href="/about" className="text-white hover:text-yellow-400 transition duration-300 ease-in-out">About Us</Link>
          <Link href="/contact1" className="text-white hover:text-yellow-400 transition duration-300 ease-in-out">Contact</Link>
          {/* <Link href="/account" className="text-white hover:text-yellow-400 transition duration-300 ease-in-out">Account</Link> */}
          {/* CTA Button */}
          {/* <Link href="/login" className="bg-yellow-400 text-black px-6 py-3 rounded-full font-semibold shadow-xl hover:bg-yellow-500 transition duration-300 ease-in-out">Login</Link> */}
          {/* Dynamic Login/Logout Button */}

          {/* Dynamic Login/Logout and User Options */}
          {isLoggedIn ? (
            <div className="relative">
              <button onClick={toggleDropdown} className="flex items-center text-white">
                <img 
                  src="https://cdn.jsdelivr.net/npm/bootstrap-icons/icons/person-circle.svg" 
                  alt="User"  
                  style={{ width: '1.5rem', height: '1.5rem' }} // User icon
                />
              </button>
              
              {isDropdownOpen && (
                <div className="absolute right-0 mt-2 bg-white text-black rounded-lg shadow-xl p-4">
                  <Link href="/account">
                    <a className="block px-4 py-2 hover:bg-gray-200 transition">Account Setting</a>
                  </Link>
                  <button onClick={handleLogout} className="block w-full px-4 py-2 text-left hover:bg-gray-200 transition">
                    Logout
                  </button>
                </div>
              )}
            </div>
          ) : (
            <button
              onClick={handleLogin}
              className="bg-yellow-400 text-black px-6 py-3 rounded-full font-semibold shadow-xl hover:bg-yellow-500 transition duration-300 ease-in-out"
            >
              Login
            </button>
          )}

          <Link href="/cart">
            <img 
              src="https://cdn.jsdelivr.net/npm/bootstrap-icons/icons/cart.svg" 
              alt="Cart"  
              style={{ width: '1.5rem', height: '1.5rem' }} // Increase the size here
            />
          </Link>

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
          <Link href="/Login" className="bg-yellow-400 text-black px-6 py-3 rounded-full font-semibold shadow-xl hover:bg-yellow-500 transition duration-300 ease-in-out">Login</Link>
          <Link href="/cart">
            <img 
              src="https://cdn.jsdelivr.net/npm/bootstrap-icons/icons/cart.svg" 
              alt="Cart"  
              style={{ width: '1.5rem', height: '1.5rem' }} // Increase the size here
            />
          </Link>        
        </nav>
      </div>
    </header>
  );
};

export default Navbar;
