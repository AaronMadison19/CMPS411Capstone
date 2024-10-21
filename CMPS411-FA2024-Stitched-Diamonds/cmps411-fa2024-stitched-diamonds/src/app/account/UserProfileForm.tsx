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
                <label>Gender:</label>
                <div style={{ display: 'flex', gap: '10px' }}>
                    <input
                        type="radio"
                        id="male"
                        name="gender"
                        value="male"
                        checked={gender === 'male'}
                        onChange={(e) => setGender(e.target.value)}
                    />
                    <label htmlFor="male" style={{ paddingTop: '5px' }}>Male</label>
                </div>
                <div style={{ display: 'flex', gap: '10px' }}>
                    <input
                        type="radio"
                        id="female"
                        name="gender"
                        value="female"
                        checked={gender === 'female'}
                        onChange={(e) => setGender(e.target.value)}
                    />
                    <label htmlFor="female" style={{ paddingTop: '5px' }}>Female</label>
                </div>
                <div style={{ display: 'flex', gap: '10px' }}>
                    <input
                        type="radio"
                        id="other"
                        name="gender"
                        value="other"
                        checked={gender === 'other'}
                        onChange={(e) => setGender(e.target.value)}
                    />
                    <label htmlFor="other" style={{ paddingTop: '5px' }}>Other</label>
                </div>
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
            <button onClick={handleSave}>Save</button>
        </div>
    );
};

export default UserProfileForm;
