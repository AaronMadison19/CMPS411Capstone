import axios from 'axios';
import https from 'https';
import { useRouter } from 'next/navigation';
import styles from '../../styles/page.module.css';

const httpsAgent = new https.Agent({
  rejectUnauthorized: false,
});

type Product = {
  id: string;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
  details: string;
  quantityInStock: number;
};

const ProductPage = async ({ params }: { params: { id: string } }) => {
  const { id } = params;

  try {
    // Fetch product data for the given ID with correct URL string interpolation
    const res = await axios.get(`https://localhost:7120/api/products/${id}`, {
      httpsAgent,
    });

    // Access product data from the correct field
    const product = res.data.data;

    console.log(product);

    if (!product) {
      return <div>Product not found</div>;
    }

    // Render product details
    return (
      <div className={styles.container}>
        <div className={styles.details}>
        <h1>{product.name}</h1>
        <p>{product.description}</p>
        <p>${product.price}</p>
        <p>{product.details}</p>
        <p>Quantity: {product.quantityInStock}</p>
        </div>
        <div className={styles.imageContainer}>
            <img src={product.imageUrl} alt={product.name} />
        </div>
      </div>
    );
  } catch (error) {
    console.error('Error fetching product:', error);
    return <div>Error loading product data.</div>;
  }
};

// Generate static params for dynamic routes
export async function generateStaticParams() {
  try {
    const res = await axios.get('https://localhost:7120/api/products', {
      httpsAgent,
    });

    // Access the products array from the response
    const products = res.data.data;

    if (!Array.isArray(products)) {
      throw new Error("Expected an array of products");
    }

    // Return params for each product
    return products.map((product: any) => ({
      params: { id: product.id.toString() }
    }));
  } catch (error) {
    console.error('Error fetching products:', error);
    return [];
  }
}

export default ProductPage;