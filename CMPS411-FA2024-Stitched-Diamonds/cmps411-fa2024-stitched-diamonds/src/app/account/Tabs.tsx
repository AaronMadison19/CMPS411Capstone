"use client";
import React, { useState} from 'react';
import ThreeDropdowns from './ThreeDropdowns';
import UserProfileForm from './UserProfileForm';
import Link from "next/link"
import { useRouter, useSearchParams } from 'next/navigation';


const Tabs: React.FC = () => {
  // const searchParams = useSearchParams();
  // // const tab = searchParams.get('tab');
  // const router = useRouter();
  // useEffect(() => {
  //   if (!Tabs) {
  //     router.push('/account?tab=tab2');
  //   }
  // }, [Tabs, router]);
  // const { tab } = router.query;
  const [activeTab, setActiveTab] = useState<'tab1' | 'tab2' | 'tab3' | 'tab4'>('tab1');

  const handleTabClick = (tab: 'tab1' | 'tab2' | 'tab3' | 'tab4') => {
    setActiveTab(tab);
  };

  return (
    <div className="tabs-container">
      <div className="tabs">
        <button 
          className={activeTab === 'tab1' ? 'active' : ''} 
          onClick={() => handleTabClick('tab1')}
          aria-pressed={activeTab === 'tab1'}
        >
          Account
        </button>
        <button 
          className={activeTab === 'tab2' ? 'active' : ''} 
          onClick={() => handleTabClick('tab2')}
          aria-pressed={activeTab === 'tab2'}
        >
          Addresses
        </button>
        <button 
          className={activeTab === 'tab3' ? 'active' : ''} 
          onClick={() => handleTabClick('tab3')}
          aria-pressed={activeTab === 'tab3'}
        >
          Credit Cards
        </button>
        <button 
          className={activeTab === 'tab4' ? 'active' : ''} 
          onClick={() => handleTabClick('tab4')}
          aria-pressed={activeTab === 'tab4'}
        >
          Public Profile
        </button>
      </div>
      <div className="tab-content">
        {activeTab === 'tab1' && (
          <form className="form" onSubmit={(e) => e.preventDefault()}>
            <div className="borderstest">
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
            </div>
            <div className="borderstest">
              <ThreeDropdowns />
            </div>
          </form>
        )}
        {activeTab === 'tab2' && (
          <form className="form" onSubmit={(e) => e.preventDefault()}>
            <div className="borderstest">
              <h3>Manage Addresses</h3>
              <div className="form-group">
                <label>Address:</label>
                <input type="text" placeholder="Enter your address" />
              </div>
              <button 
                // type="submit"
                onClick={() => handleTabClick('tab2')}
                className="edit-profile-button"
              >
                Save Address
              </button>            
            </div>
          </form>
        )}
        {activeTab === 'tab3' && (
          <form className="form" onSubmit={(e) => e.preventDefault()}>
            <div className="borderstest">
            <h3>Manage Credit Cards</h3>
              <div className="form-group">
                <label>Card Number:</label>
                <input type="text" placeholder="Enter card number" />
              </div>
              <div className="form-group">
                <label>Expiration Date:</label>
                <input type="date" />
              </div>
              <button 
                // type="submit"
                onClick={() => handleTabClick('tab3')}
                className="edit-profile-button"
              >
                Save Address
              </button>            
            </div>
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