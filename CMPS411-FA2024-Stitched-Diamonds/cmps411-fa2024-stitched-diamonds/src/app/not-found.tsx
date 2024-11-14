import { FC } from 'react';
import Navbar from './components/navbar'; 

export default function NotFound() {
  return (
  <div>
      {/* Navbar */}
      <Navbar />

      {/* Hero Section */}
      <section className="relative h-screen bg-gradient-to-r from-indigo-600 to-blue-500 flex items-center justify-center text-center text-white px-6">
        <div className="absolute inset-0 bg-black bg-opacity-40"></div>
        <div className="relative z-10 container mx-auto">
          <h1 className="text-5xl md:text-6xl font-extrabold leading-tight tracking-tight mb-4">
            Page Not Found!
          </h1>
          <p className="text-lg md:text-xl font-light mb-6">
            It wasn't meant to be.
          </p>
          <a href="/" className="inline-block px-8 py-3 bg-indigo-700 text-white font-semibold rounded-full shadow-lg hover:bg-indigo-800 transition duration-300 transform hover:scale-105">
            Go Home
          </a>
        </div>
      </section>
  </div>)
}