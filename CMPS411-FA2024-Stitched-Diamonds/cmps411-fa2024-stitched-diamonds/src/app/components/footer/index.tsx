// src/app/components/footer/index.tsx
const Footer = () => {
    return (
      <footer className="bg-gray-800 py-4">
        <div className="container mx-auto text-center text-white">
          <p>&copy; 2024 Stitched Diamonds. All rights reserved.</p>
          <p className="text-sm">Follow us on social media for the latest updates.</p>
          <div className="mt-4">
            <a href="#" className="text-gray-400 hover:text-white mx-2">Facebook</a>
            <a href="#" className="text-gray-400 hover:text-white mx-2">Twitter</a>
            <a href="#" className="text-gray-400 hover:text-white mx-2">Instagram</a>
          </div>
        </div>
      </footer>
    );
}

export default Footer;
