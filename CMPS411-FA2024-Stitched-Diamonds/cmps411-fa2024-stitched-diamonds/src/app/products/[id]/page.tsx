// src/app/products/[id]/page.tsx
import axios from 'axios';
import https from 'https';
import { useRouter } from 'next/navigation';

const httpsAgent = new https.Agent({
  rejectUnauthorized: false,
})

type Product = {
  id: string;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
  details: string;
};

const ProductPage = async ({ params }: { params: { id: string } }) => {
  const { id } = params;

  try {
  // Fetch product data for the given ID
  const res = await axios.get(`https://localhost:7120/api/products/${id}`, {
    httpsAgent,
  });
  const product: Product = res.data;

  return (
    <div>
      <h1>{product.name}</h1>
      <img src={product.imageUrl} alt={product.name} />
      <p>{product.description}</p>
      <p>${product.price}</p>
      <p>{product.details}</p>
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
    const products: Product[] = res.data;

    return products.map((product) => ({
      id: product.id.toString(), // Ensure id is a string
  }));
  } catch (error) {
    console.error('Error fetching products:', error);
    return [];
  }
}

export default ProductPage;
