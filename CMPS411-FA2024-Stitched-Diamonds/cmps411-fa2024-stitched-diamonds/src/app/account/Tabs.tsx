import React, { useState } from 'react';
import ThreeDropdowns from './ThreeDropdowns';
import UserProfileForm from './UserProfileForm';

const Tabs: React.FC = () => {
  const [activeTab, setActiveTab] = useState('tab1');

  const handleTabClick = (tab: string) => {
    setActiveTab(tab);
  };

  return (
    <div className="tabs-container">
      <div className="tabs">
        <button 
          className={activeTab === 'tab1' ? 'active' : ''} 
          onClick={() => handleTabClick('tab1')}
        >
          Account
        </button>
        <button 
          className={activeTab === 'tab2' ? 'active' : ''} 
          onClick={() => handleTabClick('tab2')}
        >
          Addresses
        </button>
        <button 
          className={activeTab === 'tab3' ? 'active' : ''} 
          onClick={() => handleTabClick('tab3')}
        >
          Credit Cards
        </button>
        <button 
          className={activeTab === 'tab4' ? 'active' : ''} 
          onClick={() => handleTabClick('tab4')}
        >
          Public Profile
        </button>
      </div>
      <div className="tab-content">
        {activeTab === 'tab1' && (
          <form className="form">
            <h3>About You</h3>
            <div className="form-group">
              <label>Name:</label>
              <input type="text" placeholder="Enter your name" />
            </div>
            <div className="form-group">
              <label>Member Since:</label>
              <input type="text" placeholder="Membership date" disabled />
            </div>
            <button 
              type="button" 
              onClick={() => handleTabClick('tab4')}
              className="edit-profile-button"
            >
              Edit Public Profile
            </button>
            <ThreeDropdowns />
          </form>
        )}
        {activeTab === 'tab2' && (
          <form className="form">
            <h3>Manage Addresses</h3>
            <div className="form-group">
              <label>Address:</label>
              <input type="text" placeholder="Enter your address" />
            </div>
            <button type="submit">Save Address</button>
          </form>
        )}
        {activeTab === 'tab3' && (
          <form className="form">
            <h3>Manage Credit Cards</h3>
            <div className="form-group">
              <label>Card Number:</label>
              <input type="text" placeholder="Enter card number" />
            </div>
            <div className="form-group">
              <label>Expiration Date:</label>
              <input type="date" />
            </div>
            <button type="submit">Save Card</button>
          </form>
        )}
        {activeTab === 'tab4' && (
          <div>
            <UserProfileForm />
          </div>
        )}
      </div>
    </div>
  );
};

export default Tabs;
