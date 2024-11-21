"use client"; 
import Navbar from '../components/navbar';
import React, { useState, useEffect } from 'react';
// import axios from 'axios';
import axios from 'axios';
import { PaperClipIcon } from '@heroicons/react/24/outline';
import './styles.css';

// Define the Account type and ApiResponse interface
interface Account {
  firstName: string;
  lastName: string;
  email: string;
  username: string;
  phoneNumber: string;
  billingAddress: string;
  shippingAddress: string;
  role: string;
  createDate: string;
  isActive: number | string;
}

interface ApiResponse {
  data: Account[];
}

const Account: React.FC = () => {
    const [activeTab, setActiveTab] = useState('profile');
    const [profileData, setProfileData] = useState<{ firstName: string; lastName: string; email: string; username: string; 
            phoneNumber: string; billingAddress: string; shippingAddress: string; role: string; createDate: string; isActiveValue: string; } | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    const [newPassword, setNewPassword] = useState<string>('');

    // Assume the ID of the user is 1 for this example
    const userId = 1; // Change this dynamically as per your app requirements

    // Fetch profile data when the component mounts
    useEffect(() => {
        const fetchProfileData = async () => {
        try {
            const response = await axios.get<ApiResponse>("https://localhost:7120/api/accounts");
            console.log("API Response:", response.data); // Log the full response for debugging
            // const account = response.data.data; // Adjust based on your actual response structure
            // setProfileData({
            //     // firstName: account.firstName,
            //     firstName: "caleb",
            //     username: account.username,
            // });
            // setLoading(false);
            // Ensure that there is data available and set it
            const account = response.data.data[userId-1]; // Access the first item in the data array
            if (account) {
            const isActiveValue = 
                    account.isActive == 1 || account.isActive == "1"
                        ? "true"
                        : account.isActive == 2 || account.isActive == "2"
                        ? "false"
                        : "unknown"; // Handle unexpected values              
                setProfileData({
                    firstName: account.firstName, // Get first name from the API response
                    lastName: account.lastName, // Get first name from the API response
                    email: account.email,   // Get username from the API response
                    username: account.username,
                    phoneNumber: account.phoneNumber,
                    billingAddress: account.billingAddress,
                    shippingAddress: account.shippingAddress,
                    role: account.role,
                    createDate: account.createDate,
                    // Set isActive based on the value: 1 = true, 2 = false
                    isActiveValue: isActiveValue,
                });
            } else {
                setError("No account data found");
            }
            setLoading(false);

        } catch (err) {
            setError('Failed to load profile data');
            setLoading(false);
        }
        };

        fetchProfileData();
    }, [userId]);

    // const handleSaveChanges = async () => {
    //   // Make sure the new password field is not empty
    //   if (newPassword === '') {
    //     setError("Please fill in the new password.");
    //     return;
    //   }
    
    //   let existingData; // Declare existingData only once here
    
    //   try {
    //     // Fetch the existing user data
    //     alert("in try")
    //     const response = await axios.get(`https://localhost:7120/api/accounts/${userId}`);
    
    //     // Store the response data in existingData
    //     existingData = response.data;
    
    //     // Ensure existingData is an object and contains the necessary fields
    //     if (!existingData || typeof existingData !== 'object') {
    //       throw new Error('Invalid user data.');
    //     }
    
    //     // Prepare the updated data object, merging with existing data
    //     const updatedData = {
    //       // ...existingData, // Spread the existing data
    //       firstName: "Caleb", // Get first name from the API response
    //       lastName: "Patric", // Get first name from the API response
    //       email: "calebpatrick@abc.com",   // Get username from the API response
    //       username: "calebp",
    //       phoneNumber: "123456789",
    //       billingAddress: "500 W University Ave, Hammond, LA 70402",
    //       shippingAddress: "500 W University Ave, Hammond, LA 70402",
    //       password: newPassword, // Overwrite the password with the new value
    //     };
    
    //     console.log("Updated Data:", updatedData);
    //     alert("got the updated data")
    //     // Send the PUT request to update the user's data
    //     const putResponse = await axios.put(
    //       `https://localhost:7120/api/accounts/${userId}`,
    //       updatedData,
    //       {
    //         headers: {
    //           "Content-Type": "application/json",
    //         },
    //       }
    //     );
    //       alert("after response")

    //     // If the request is successful, inform the user
    //     if (putResponse.status === 200) {
    //       alert("Password updated successfully!");
    //       setNewPassword(""); // Clear the password input field
    //       setError(null); // Clear any previous error messages
    //     } else {
    //       setError("Failed to update password."); // Handle failure case
    //     }
    //   } catch (error) {
    //     // General error handling (no AxiosError check)
    //     console.error("Error:", error);
    //     setError("Failed to update password due to an error.");
    //   }
    // };

    const handleSaveChanges = async () => {
    if (newPassword === '') {
        setError("Please fill in the new password.");
        return;
    }

    try {
        const updatedData = { ...profileData, password: newPassword };

        const putResponse = await axios.put(
        `https://localhost:7120/api/accounts/${userId}`,
        updatedData,
        {
            headers: {
            "Content-Type": "application/json",
            },
        }
        );

        if (putResponse.status === 200) {
        setNewPassword('');
        setError(null);
        alert("Password updated successfully!");
        } else {
        setError("Failed to update password.");
        }
    } catch (error) {
        console.error("Error during password update:", error);
        setError("Failed to update password due to an error.");
    }
    };



    // Handle loading state (display loading message)
    // if (loading) {
    //     return <div>Loading...</div>;
    // }

    // // Handle error state (display error message)
    // if (error) {
    //     return <div>{error}</div>;
    // }



  return (
    <div className="text-gray-900">
        
      {/* Navbar */}
      <Navbar />


      {/* Hero Section */}
      <div className="flex">
      {/* Sidebar */}

      {/* Main Content */}
      <div className="w-1/4 bg-white shadow-md p-6">
        <h2 className="text-xl font-semibold text-gray-700 mb-8">Account Settings</h2>
        <ul>
          <li>
            <button
              className={`w-full text-left py-3 px-4 text-lg font-medium ${
                activeTab === 'profile' ? 'bg-gray-200 text-blue-600' : 'hover:bg-gray-100'
              }`}
              onClick={() => setActiveTab('profile')}
            >
              Profile
            </button>
          </li>
          <li>
            <button
              className={`w-full text-left py-3 px-4 text-lg font-medium ${
                activeTab === 'email' ? 'bg-gray-200 text-blue-600' : 'hover:bg-gray-100'
              }`}
              onClick={() => setActiveTab('email')}
            >
              Email & Password
            </button>
          </li>
          <li>
            <button
              className={`w-full text-left py-3 px-4 text-lg font-medium ${
                activeTab === 'payment' ? 'bg-gray-200 text-blue-600' : 'hover:bg-gray-100'
              }`}
              onClick={() => setActiveTab('payment')}
            >
              Payment Methods
            </button>
          </li>
          <li>
            <button
              className={`w-full text-left py-3 px-4 text-lg font-medium ${
                activeTab === 'security' ? 'bg-gray-200 text-blue-600' : 'hover:bg-gray-100'
              }`}
              onClick={() => setActiveTab('security')}
            >
              Security
            </button>
          </li>
        </ul>
      </div>

      {/* Main Content */}
      <div className="flex-1 p-6">
        {/* Profile Section */}
        {activeTab === 'profile' && profileData && (
        //   <div className="bg-white shadow-md rounded-lg p-6 mb-6">
        //     <h2 className="text-2xl font-semibold text-gray-800 mb-4">Profile Information</h2>
        //     <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        //       <div>
        //         <label htmlFor="full-name" className="block text-sm font-medium text-gray-700">Full Name</label>
        //         <input
        //           type="text"
        //           id="full-name"
        //         //   value={profileData?.username || ''}
        //           value={profileData.firstName}
        //           className="mt-1 block w-full px-4 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
        //           readOnly
        //         />
        //       </div>
        //       <div>
        //         <label htmlFor="username" className="block text-sm font-medium text-gray-700">Username</label>
        //         <input
        //           type="text"
        //           id="username"
        //           value={profileData.username}
        //           className="mt-1 block w-full px-4 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
        //           readOnly
        //         />
        //       </div>
        //     </div>
        //   </div>
            <div>
                <div className="px-4 sm:px-0">
                <h3 className="text-base/7 font-semibold text-gray-900">Applicant Information</h3>
                <p className="mt-1 max-w-2xl text-sm/6 text-gray-500">Personal details and application.</p>
                </div>
                <div className="mt-6 border-t border-gray-100">
                <dl className="divide-y divide-gray-100">
                    <div className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                    <dt className="text-sm/6 font-medium text-gray-900">Full name</dt>
                    <dd className="mt-1 text-sm/6 text-gray-700 sm:col-span-2 sm:mt-0">{profileData.firstName} {profileData.lastName}</dd>
                    </div>
                    <div className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                    <dt className="text-sm/6 font-medium text-gray-900">Email Address</dt>
                    <dd className="mt-1 text-sm/6 text-gray-700 sm:col-span-2 sm:mt-0">{profileData.email}
                      <span
                        onClick={() => setActiveTab('email')}  // This will switch the tab to "email"
                        className="text-sm text-blue-600 hover:underline"
                      >
                        {' '}Update Email
                      </span>
                    </dd>
                    </div>
                    <div className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                    <dt className="text-sm/6 font-medium text-gray-900">Member Since</dt>
                    <dd className="mt-1 text-sm/6 text-gray-700 sm:col-span-2 sm:mt-0">{profileData.createDate}</dd>
                    </div>
                    <div className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                    <dt className="text-sm/6 font-medium text-gray-900">Status</dt>
                    <dd className="mt-1 text-sm/6 text-gray-700 sm:col-span-2 sm:mt-0">{profileData.isActiveValue}</dd>
                    </div>
                    <div className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                    <dt className="text-sm/6 font-medium text-gray-900">Close your account</dt>
                    <dd className="mt-1 text-sm/6 text-gray-700 sm:col-span-2 sm:mt-0">
                        <h3 className="close-account-title wt-text-title font-bold">What happens when you close your account?</h3>
                        <ul className="wt-list list-disc pl-5">
                            <li className="close-account-items wt-text-body--tight">Your account will be inactive, until you reopen it.</li>
                            <li className="close-account-items wt-text-body--tight">Your profile will no longer appear anywhere on Etsy.</li>
                            <li className="close-account-items wt-text-body--tight">We'll close any non-delivery cases you opened.</li>
                            <li className="close-account-items wt-text-body--tight">Your account settings will remain intact, and no one will be able to use your username.</li>
                        </ul>
                        <div className="wt-mt-xs-2 wt-widht-full">
                            <p className="wt-display-block wt-text-body wt-mb-xs-2 wt-width-full">You can reopen your account anytime. Just sign back in to Etsy or&nbsp;<a className="wt-text-link underline" href="https://www.etsy.com/help/contact">contact Etsy support</a>&nbsp;for help.</p>
                            <p className="wt-text-title wt-width-full font-bold">Want to permanently delete your account instead? Go to your&nbsp;<a className="wt-text-link underline" href="https://www.etsy.com/your/account/privacy">Privacy Settings</a>&nbsp;and click "Request deletion of your data."</p>                    
                        </div>
                    </dd>
                    </div>
                </dl>
            </div>
        </div>        
        )}

        {/* Email & Password Section */}
        {activeTab === 'email'  && profileData && (
          <div className="bg-white shadow-md rounded-lg p-6 mb-6">
            <h2 className="text-2xl font-semibold text-gray-800 mb-4">Email & Password</h2>
            <div className="space-y-6">
              <div>
                <label htmlFor="email" className="block text-sm font-medium text-gray-700">Email Address</label>
                <input
                  type="email"
                  id="email"
                  value={profileData.email}
                  className="mt-1 block w-full px-4 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
                  disabled // This will disable the field and make it non-editable
                />
              </div>
              <div>
                <label htmlFor="new-password" className="block text-sm font-medium text-gray-700">New Password</label>
                <input
                  type="password"
                  id="new-password"
                  value={newPassword}
                  onChange={(e) => setNewPassword(e.target.value)}  // Track password input changes
                  className="mt-1 block w-full px-4 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
                  placeholder="••••••••"
                />
              </div>
            </div>
            {/* <button className="mt-4 px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700">
              Save Changes
            </button> */}
            <button
              onClick={handleSaveChanges}
              className="mt-4 px-6 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700"
              >
                Save Changes
              </button>            
          </div>
        )}

        {/* Payment Methods Section */}
        {activeTab === 'payment' && profileData && (
        <div className="bg-white shadow-md rounded-lg p-6 mb-6">
            <h2 className="text-2xl font-semibold text-gray-800 mb-4">Payment Methods</h2>
            <div className="space-y-6">
            {/* PayPal Option */}
            <div className="flex items-center justify-between border p-4 rounded-lg shadow-sm">
                <div className="flex items-center space-x-4">
                <img
                    src="https://upload.wikimedia.org/wikipedia/commons/b/b5/PayPal.svg"
                    alt="PayPal"
                    className="h-8"
                />
                {/* <span className="text-lg">PayPal</span> */}
                </div>
                <button className="text-sm text-blue-600 hover:underline">Connect PayPal</button>
            </div>

            {/* Stripe Option */}
            <div className="flex items-center justify-between border p-4 rounded-lg shadow-sm">
                <div className="flex items-center space-x-4">
                <img
                    src="https://upload.wikimedia.org/wikipedia/commons/b/ba/Stripe_Logo%2C_revised_2016.svg"
                    alt="Stripe"
                    className="h-8"
                />
                {/* <span className="text-lg">Stripe</span> */}
                <button className="text-sm text-blue-600 hover:underline">Connect Stripe</button>
                </div>
                {/* <button className="text-sm text-blue-600 hover:underline">Connect Stripe</button> */}
            </div>
            </div>

            {/* Add Payment Method Button */}
            <button className="mt-4 px-6 py-2 bg-green-600 text-white rounded-lg hover:bg-green-700">
            Add Payment Method
            </button>
        </div>
        )}

        {/* Security Section */}
        {activeTab === 'security' && profileData && (
          <div className="bg-white shadow-md rounded-lg p-6 mb-6">
            <h2 className="text-2xl font-semibold text-gray-800 mb-4">Security Settings</h2>
            <div className="space-y-6">
              <div>
                <label htmlFor="two-factor" className="block text-sm font-medium text-gray-700">Two-Factor Authentication</label>
                <div className="flex items-center space-x-4">
                  <button className="px-6 py-2 bg-yellow-600 text-white rounded-lg hover:bg-yellow-700">
                    Enable 2FA
                  </button>
                  <span className="text-sm text-gray-500">Increase your account security</span>
                </div>
              </div>
            </div>
          </div>
        )}
      </div>
    </div>

      
  </div> 
    
    
)}
export default Account;
