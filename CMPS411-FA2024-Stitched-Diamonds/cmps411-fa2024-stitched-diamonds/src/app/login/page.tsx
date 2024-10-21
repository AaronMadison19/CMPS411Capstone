"use client"; // This tells Next.js that this component should be rendered on the client side
import { useState } from "react";
import styles from "./styles/login.module.css"; // Ensure the path is correct

const Login: React.FC = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const response = await fetch('/api/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        UserName: username,
        Password: password,
      })
    });

    if (response.ok) {
      console.log('Login successful!');
      // Redirect or perform any action on successful login
    } else {
      console.log('Failed to log in.');
    }
  };

  return (
    <div className={styles.loginContainer}>
      <div className={styles.formWrapper}>
        <h2>Login to Your Account</h2>
        <form className={styles.loginForm} onSubmit={handleSubmit}>
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
          <button type="submit" className={styles.submitButton}>Log In</button>
        </form>
        <p className={styles.signupPrompt}>
          Don't have an account? <a href="/signup" className={styles.signupLink}>Sign up</a>
        </p>
      </div>
    </div>
  );
};

export default Login;
