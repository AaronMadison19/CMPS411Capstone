"use client"; // This tells Next.js that this component should be rendered on the client side
import { useState } from "react";
import styles from "./styles/signup.module.css"; // Ensure the path is correct

const SignUp: React.FC = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
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

    const response = await fetch('/api/users', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        UserName: username,
        Password: password,
        Roles: ['User']
      })
    });

    if (response.ok) {
      console.log('Signup successful!');
    } else {
      console.log('Failed to signup.');
    }
  };

  return (
    <div className={styles.signupContainer}>
      <div className={styles.formWrapper}>
        <h2>Create Your Account</h2>
        <form className={styles.signupForm} onSubmit={handleSubmit}>
          <div className={styles.formGroup}>
            <label htmlFor="username">Username</label>
            <input 
              type="text" 
              id="username" 
              placeholder="Enter your username" 
              value={username} 
              onChange={(e) => setUsername(e.target.value)} 
              required 
            />
          </div>
          <div className={styles.formGroup}>
            <label htmlFor="password">Password</label>
            <input 
              type="password" 
              id="password" 
              placeholder="Enter your password" 
              value={password} 
              onChange={(e) => setPassword(e.target.value)} 
              required 
            />
          </div>
          <div className={styles.formGroup}>
            <label htmlFor="confirmPassword">Confirm Password</label>
            <input 
              type="password" 
              id="confirmPassword" 
              placeholder="Confirm your password" 
              value={confirmPassword} 
              onChange={(e) => setConfirmPassword(e.target.value)} 
              required 
            />
          </div>
          <div className={styles.formGroupCheckbox}>
            <input 
              type="checkbox" 
              id="terms" 
              checked={termsAgreed} 
              onChange={(e) => setTermsAgreed(e.target.checked)} 
            />
            <label htmlFor="terms">I agree to the <a href="#">Terms and Conditions</a></label>
          </div>
          <button type="submit" className={styles.submitButton}>Create Account</button>
        </form>
        <p className={styles.alreadyHaveAccount}>
          Already have an account? <a href="/login" className={styles.loginLink}>Log in</a>
        </p>
      </div>
    </div>
  );
};

export default SignUp;
