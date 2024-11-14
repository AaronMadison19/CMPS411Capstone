"use client"; 
import Navbar from '../components/navbar';

const About: React.FC = () => {
  return (
    <div className="text-gray-900">

      {/* Navbar */}
      <Navbar />

      {/* Hero Section */}
      <section className="relative h-96 bg-gradient-to-r from-indigo-600 to-blue-500 flex items-center justify-center text-center text-white px-6">
        <div className="absolute inset-0 bg-black bg-opacity-40"></div>
        <div className="relative z-10 container mx-auto">
          <h1 className="text-5xl font-extrabold leading-tight">About Us</h1>
          <p className="mt-4 text-lg md:text-xl font-light">
            Welcome to Stitched Diamonds, where passion meets craftsmanship.
          </p>
        </div>
      </section>

      {/* Mission, Story, Values */}
      <div className="container mx-auto px-6 py-16 grid grid-cols-1 md:grid-cols-3 gap-8">
        
        {/* Mission Section */}
        <div className="bg-white shadow-lg rounded-xl overflow-hidden p-6 hover:shadow-xl transition duration-300 transform hover:scale-105">
          <h2 className="text-2xl font-semibold text-gray-800 mb-4">Our Mission</h2>
          <p className="text-gray-600">
            At Stitched Diamonds, our mission is to provide high-quality products that combine both functionality and style. We focus on sourcing the best materials and ensuring every product meets the highest standards.
          </p>
        </div>

        {/* Story Section */}
        <div className="bg-white shadow-lg rounded-xl overflow-hidden p-6 hover:shadow-xl transition duration-300 transform hover:scale-105">
          <h2 className="text-2xl font-semibold text-gray-800 mb-4">Our Story</h2>
          <p className="text-gray-600">
            Born from a desire to craft exceptional products, Makena Johnson started with a vision to bring unique, durable, and elegant items to the market. What began as a small passion project quickly grew into something much bigger, thanks to our loyal customers and the dedication of our team.
          </p>
        </div>

        {/* Values Section */}
        <div className="bg-white shadow-lg rounded-xl overflow-hidden p-6 hover:shadow-xl transition duration-300 transform hover:scale-105">
          <h2 className="text-2xl font-semibold text-gray-800 mb-4">Our Values</h2>
          <ul className="text-gray-600 space-y-2 list-disc pl-6">
            <li>Quality Craftsmanship</li>
            <li>Customer Satisfaction</li>
            <li>Innovation</li>
            <li>Sustainability</li>
          </ul>
        </div>
      </div>

      {/* Team Section */}
      <section className="bg-gray-100 py-16">
        <div className="container mx-auto px-6 text-center">
          <h2 className="text-3xl font-semibold text-gray-900 mb-4">Meet the Team</h2>
          <p className="text-lg text-gray-700 mb-8">
            Our team consists of experienced professionals dedicated to bringing you the finest products on the market. From design to production, we ensure every step is handled with care. Meet the faces behind Stitched Diamonds and discover the passion that drives us to create exceptional products every day.
          </p>

          {/* Founder & CEO */}
          <div className="flex justify-center mb-12">
            <div className="bg-white shadow-xl rounded-lg p-6 w-80 transform hover:scale-105 transition duration-300">
              <img src="https://via.placeholder.com/200" alt="Makena Johnson" className="rounded-full mx-auto mb-4 w-40 h-40 object-cover" />
              <h3 className="text-xl font-semibold text-gray-800">Makena Johnson</h3>
              <p className="text-gray-600">Founder & CEO</p>
            </div>
          </div>

          {/* Developers Section */}
          <div className="container mx-auto px-9 py-16 grid grid-cols-1 md:grid-cols-5 gap-8">
            <div className="bg-white shadow-xl rounded-lg p-6 w-64">
              <img src="https://via.placeholder.com/100" alt="Team Member" className="rounded-full mx-auto mb-4" />
              <h3 className="text-xl font-semibold text-gray-800">Aaron Madison</h3>
              <p className="text-gray-600">Developer</p>
            </div>
            <div className="bg-white shadow-xl rounded-lg p-6 w-64">
              <img src="https://via.placeholder.com/100" alt="Team Member" className="rounded-full mx-auto mb-4" />
              <h3 className="text-xl font-semibold text-gray-800">Alex Chaplain</h3>
              <p className="text-gray-600">Developer</p>
            </div>
            <div className="bg-white shadow-xl rounded-lg p-6 w-64">
              <img src="https://via.placeholder.com/100" alt="Team Member" className="rounded-full mx-auto mb-4" />
              <h3 className="text-xl font-semibold text-gray-800">Caleb Patrick</h3>
              <p className="text-gray-600">Developer</p>
            </div>
            <div className="bg-white shadow-xl rounded-lg p-6 w-64">
              <img src="https://via.placeholder.com/100" alt="Team Member" className="rounded-full mx-auto mb-4" />
              <h3 className="text-xl font-semibold text-gray-800">Jake Sasser</h3>
              <p className="text-gray-600">Developer</p>
            </div>
            <div className="bg-white shadow-xl rounded-lg p-6 w-64">
              <img src="https://via.placeholder.com/100" alt="Team Member" className="rounded-full mx-auto mb-4" />
              <h3 className="text-xl font-semibold text-gray-800">Wonda White</h3>
              <p className="text-gray-600">Developer</p>
            </div>
          </div>
        </div>
      </section>

    </div>
  );
};

export default About;
