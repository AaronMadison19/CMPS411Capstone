"use client"; 
import { useState } from "react";
import Navbar from "../components/navbar"; 

const SignUp: React.FC = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [phoneNumber, setphoneNumber] = useState('');
  const [billingAddress, setbillingAddress] = useState('');
  const [shippingAddress, setshippingAddress] = useState('');
  const [role, setrole] = useState('');
  const [termsAgreed, setTermsAgreed] = useState(false);

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    if (password !== confirmPassword) {
      alert('Passwords do not match!');
      return;
    }
    if (!termsAgreed) {
      alert('Please agree to the terms and conditions.');
      return; 
    }

    const response = await fetch('https://localhost:7120/api/accounts', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        FirstName: firstName,
        LastName: lastName,
        Email: email,
        UserName: username,
        Password: password,
        // Optional fields based on your DTO
        phoneNumber: phoneNumber || '',
        billingAddress: billingAddress || '',
        shippingAddress: shippingAddress || '',
        role: role || 'User',
        createDate: new Date().toISOString(),
        isActive: true, // Or false if applicable        
      })
    });

    if (response.ok) {
      console.log('Signup successful!');
      const data = await response.json();
      const newUserId = data.data.id; // Assuming the API returns the ID in `data.id`

      // Redirect to the user's account page
      window.location.href = `/account?id=${newUserId}`; // Navigate to the account page with the user's ID
      
      // You might want to redirect the user after successful signup
      // window.location.href = "/login"; // Redirect to login page after successful signup
    } else {
      console.log('Failed to signup.');
      alert("Signup failed. Please try again.");
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
          <h1 className="text-5xl font-extrabold leading-tight">Create Your Account</h1>
          <p className="mt-4 text-lg md:text-xl font-light">
            Join us at Stitched Diamonds and experience exceptional craftsmanship.
          </p>
        </div>
      </section>

      {/* Sign Up Form */}
      <div className="container mx-auto px-6 py-16">
        <div className="max-w-lg mx-auto bg-white shadow-lg rounded-xl p-8">
          <h2 className="text-3xl font-semibold text-gray-800 text-center mb-8">Sign Up</h2>
          <form onSubmit={handleSubmit}>
            <div className="mb-4">
              <label htmlFor="firstName" className="block text-gray-800">First Name</label>
              <input
                type="text"
                id="firstName"
                placeholder="Enter your First Name"
                value={firstName}
                onChange={(e) => setFirstName(e.target.value)}
                required
                className="w-full p-3 mt-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
            </div>
            <div className="mb-4">
              <label htmlFor="lastName" className="block text-gray-800">Last Name</label>
              <input
                type="text"
                id="lastName"
                placeholder="Enter your Last Name"
                value={lastName}
                onChange={(e) => setLastName(e.target.value)}
                required
                className="w-full p-3 mt-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
            </div>
            <div className="mb-4">
              <label htmlFor="email" className="block text-gray-800">Email</label>
              <input
                type="email"
                id="email"
                placeholder="Enter your Email Address"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
                className="w-full p-3 mt-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
            </div>
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
            <div className="mb-4">
              <label htmlFor="confirmPassword" className="block text-gray-800">Confirm Password</label>
              <input
                type="password"
                id="confirmPassword"
                placeholder="Confirm your password"
                value={confirmPassword}
                onChange={(e) => setConfirmPassword(e.target.value)}
                required
                className="w-full p-3 mt-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
            </div>
            <div className="mb-6 flex items-center">
              <input
                type="checkbox"
                id="terms"
                checked={termsAgreed}
                onChange={(e) => setTermsAgreed(e.target.checked)}
                className="h-5 w-5 border-gray-300 rounded"
              />
              <label htmlFor="terms" className="ml-2 text-sm text-gray-600">I agree to the <a href="#" className="text-blue-500">Terms and Conditions</a></label>
            </div>
            <button type="submit" className="w-full p-3 bg-blue-600 text-white font-semibold rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500">
              Create Account
            </button>
          </form>
          <p className="text-center text-sm text-gray-600 mt-6">
            Already have an account? <a href="/login" className="text-blue-500">Log in</a>
          </p>
        </div>
      </div>
    </div>
  );
};

export default SignUp;
