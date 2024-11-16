// src/app/layout.tsx
import Navbar from './components/navbar';
import Footer from './components/footer'; 
import './globals.css';  

export const metadata = {
  title: 'Stitched Diamonds',
  description: 'Discover high-quality diamond jewelry.',
};

const RootLayout = ({ children }: { children: React.ReactNode }) => {
  return (
    <html lang="en">
      <body className="font-sans bg-gray-100">
        {/* Navbar */}
        <Navbar />
        
        {/* Page Content */}
        <main>{children}</main>

        {/* Footer */}
        <Footer />
      </body>
    </html>
  );
};

export default RootLayout;
