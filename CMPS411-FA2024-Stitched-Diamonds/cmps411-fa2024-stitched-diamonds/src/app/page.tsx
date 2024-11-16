// src/app/page.tsx
import { FC } from 'react';
import Navbar from './components/navbar'; 

const HomePage: FC = () => {
  return (
    <div className="bg-gray-50 text-gray-900 font-sans">

      {/* Navbar */}
      <Navbar />

      {/* Hero Section */}
      <section className="relative h-screen bg-gradient-to-r from-indigo-600 to-blue-500 flex items-center justify-center text-center text-white px-6">
        <div className="absolute inset-0 bg-black bg-opacity-40"></div>
        <div className="relative z-10 container mx-auto">
          <h1 className="text-5xl md:text-6xl font-extrabold leading-tight tracking-tight mb-4">
            Discover the Best Jewelry Pieces
          </h1>
          <p className="text-lg md:text-xl font-light mb-6">
            Handcrafted diamond jewelry for every occasion. Timeless elegance, unmatched quality.
          </p>
          <a href="#featured-products" className="inline-block px-8 py-3 bg-indigo-700 text-white font-semibold rounded-full shadow-lg hover:bg-indigo-800 transition duration-300 transform hover:scale-105">
            Shop Now
          </a>
        </div>
      </section>

      {/* Featured Products Section */}
      <section id="featured-products" className="container mx-auto px-6 py-16">
        <h2 className="text-4xl font-semibold text-center text-gray-900 mb-12">
          Shop Our Featured Products
        </h2>
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-12">
          {["Sweater", "Ring", "Earrings"].map((product, index) => (
            <div key={index} className="bg-white rounded-xl shadow-lg overflow-hidden transform transition duration-300 hover:scale-105">
              <img 
                src={`https://source.unsplash.com/featured/?jewelry${index + 1}`} 
                alt={product} 
                className="w-full h-64 object-cover"
              />
              <div className="p-6">
                <h3 className="text-xl font-semibold text-gray-800">{product}</h3>
                <p className="mt-2 text-gray-600">$50.00</p>
                <a href="#" className="mt-4 inline-block px-6 py-3 bg-indigo-600 text-white font-semibold rounded-lg hover:bg-indigo-700 transition duration-300">
                  Buy Now
                </a>
              </div>
            </div>
          ))}
        </div>
      </section>

      {/* Call to Action Section */}
      <section className="relative py-16 text-center text-white bg-gradient-to-r from-indigo-600 to-blue-500">
        <div className="absolute inset-0 bg-black bg-opacity-40"></div>
        <div className="relative z-10">
          <h2 className="text-3xl font-semibold mb-4">
            Get the Latest Updates
          </h2>
          <p className="text-lg mb-8">
            Subscribe to our newsletter for the latest products, exclusive offers, and more.
          </p>
          <form className="max-w-lg mx-auto flex justify-center">
            <input
              type="email"
              placeholder="Enter your email"
              className="px-6 py-3 w-full md:w-80 rounded-l-lg text-black focus:outline-none focus:ring-2 focus:ring-indigo-600"
            />
            <button
              type="submit"
              className="px-6 py-3 bg-gray-800 hover:bg-gray-900 rounded-r-lg text-white font-semibold"
            >
              Subscribe
            </button>
          </form>
        </div>
      </section>

    </div>
  );
};

export default HomePage;
