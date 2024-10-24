import React, { useState } from 'react';

const UserProfileForm: React.FC = () => {
    const [name, setName] = useState('');
    const [gender, setGender] = useState('');
    const [birthday, setBirthday] = useState('');
    const [aboutYou, setAboutYou] = useState('');
    const [hobbies, setHobbies] = useState({
        hobby1: false,
        hobby2: false,
        hobby3: false,
    });
    const [profilePicture, setProfilePicture] = useState<string | ArrayBuffer | null>(null);

    const handleHobbyChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, checked } = e.target;
        setHobbies((prev) => ({ ...prev, [name]: checked }));
    };

    const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const file = e.target.files?.[0];
        if (file) {
            const reader = new FileReader();
            reader.onloadend = () => {
                setProfilePicture(reader.result);
            };
            reader.readAsDataURL(file);
        }
    };

    const handleSave = () => {
        // Save logic goes here
        console.log({ name, gender, birthday, aboutYou, hobbies, profilePicture });
    };

    return (
        <div className="profile-form">
            <h2>User Profile</h2>
            <div className="form-group">
                <label htmlFor="profilePicture">Profile Picture:</label>
                <input 
                    type="file" 
                    id="profilePicture" 
                    accept="image/*" 
                    onChange={handleFileChange} 
                />
                {profilePicture && (
                    <img src={profilePicture as string} alt="Profile Preview" className="profile-preview" />
                )}
            </div>
            <div className="publicprofile">
                <label htmlFor="name">Name:</label>
                <input
                    type="text"
                    id="name"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
                {/* <button onClick={() => alert('Edit feature not implemented.')} className="edit-profile-button">Edit</button> */}

                
            </div>
            <div className="publicprofile">
                <label htmlFor="birthday">Birthday:</label>
                <input
                    type="date"
                    id="birthday"
                    value={birthday}
                    onChange={(e) => setBirthday(e.target.value)}
                />
            </div>
            <div className="publicprofile">
                <label htmlFor="aboutYou">About You:</label>
                <textarea
                    id="aboutYou"
                    value={aboutYou}
                    onChange={(e) => setAboutYou(e.target.value)}
                />
            </div>
            {/* <button onClick={handleSave}>Save</button> */}
            <div>        
                <button onClick={() => alert("Saved!")} className="edit-profile-button">Save</button>
            </div>
            
        </div>
    );
};

export default UserProfileForm;
