"use client";
import { useState } from "react";
import Navbar from "../components/navbar";
import { useNavigate } from 'react-router-dom';

  const Login: React.FC = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
  event.preventDefault();

  const url = `https://localhost:7120/api/accounts/login?username=${username}&password=${password}`;
  console.log('Fetching from URL:', url);

  try {
    const response = await fetch(url, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    });

    console.log('Response received.');

    if (response.ok) {
      const data = await response.json();
      if (data && data.data) {
        const accountId = data.data.id;
        console.log('Login successful! Account ID:', accountId);

        // Clear the username and password fields
        setUsername('');
        setPassword('');
        console.log('Username and password cleared');

        // Navigate to /account and pass the ID as state
        window.location.href = `/account?id=${accountId}`; // Navigate to the account page with the user's ID

        // Redirect or handle the account ID
        // Example: window.location.href = `/accounts/${accountId}`;
      } else {
        console.log('Account data not found in response.');
        alert('Account data not found in response.')
      }
    } else {
      console.error('Failed to log in:', response.status, response.statusText);
    }
  } catch (error) {
    console.error('Error during fetch:', error);
  }
};


  return (
    <div className="bg-gray-50 text-gray-900">

      {/* Navbar */}
      <Navbar />

      {/* Hero Section */}
      <section className="relative h-96 bg-gradient-to-r from-indigo-600 to-blue-500 flex items-center justify-center text-center text-white px-6">
        <div className="absolute inset-0 bg-black bg-opacity-40"></div>
        <div className="relative z-10 container mx-auto">
          <h1 className="text-5xl font-extrabold leading-tight">Login to Your Account</h1>
          <p className="mt-4 text-lg md:text-xl font-light">
            Access your Stitched Diamonds profile and manage your orders.
          </p>
        </div>
      </section>

      {/* Login Form */}
      <div className="container mx-auto px-6 py-16">
        <div className="max-w-lg mx-auto bg-white shadow-lg rounded-xl p-8">
          <h2 className="text-3xl font-semibold text-gray-800 text-center mb-8">Login</h2>
          <form onSubmit={handleSubmit}>
            <div className="mb-4">
              <label htmlFor="username" className="block text-gray-800">Username</label>
              <input
                type="text"
                id="username"
                placeholder="Enter your username"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                required
                className="w-full p-3 mt-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
            </div>
            <div className="mb-4">
              <label htmlFor="password" className="block text-gray-800">Password</label>
              <input
                type="password"
                id="password"
                placeholder="Enter your password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
                className="w-full p-3 mt-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
            </div>
            <button type="submit" className="w-full p-3 bg-blue-600 text-white font-semibold rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500">
              Log In
            </button>
          </form>
          <p className="text-center text-sm text-gray-600 mt-6">
            Don't have an account? <a href="/signup" className="text-blue-500">Sign up</a>
          </p>
        </div>
      </div>

    </div>
  );
};

export default Login;
