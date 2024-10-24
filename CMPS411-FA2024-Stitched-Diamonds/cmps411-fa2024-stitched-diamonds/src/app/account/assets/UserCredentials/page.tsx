import axios from 'axios';
import https from 'https';
import { useRouter } from 'next/navigation';

const httpsAgent = new https.Agent({
  rejectUnauthorized: false,
});

type Account = {
    first_Name: string
    last_Name: string
    email: string
    username: string
    password: string
    phone_Number: string
    billing_Address: string
    shipping_Address: string
    create_Date: "2024-10-24T00:07:27.158Z"
    is_Active: true
    role: string
};

const AccountID = async ({ params }: { params: { id: string } }) => {
  const { id } = params;

  try {
    // Fetch product data for the given ID with correct URL string interpolation
    const res = await axios.get(`https://localhost:7120/api/accounts/${id}`, {
      httpsAgent,
    });

    // Access account data from the correct field
    const account = res.data.data;

    console.log(account);

    if (!account) {
      return <div>Account not found</div>;
    }

    // Render product details
    return (
      <div>
        <h1>{AccountID.first_name}</h1>
        <p>Quantity: {product.quantity_In_Stock}</p>
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
      const res = await axios.get('https://localhost:7120/api/account', {
      httpsAgent,
    });

    // Access the products array from the response
      const account = res.data.data;

      if (!Array.isArray(account)) {
      throw new Error("Expected an array of products");
    }

    // Return params for each product
    return account.map((account: any) => ({
      params: { id: account.id.toString() }
    }));
  } catch (error) {
    console.error('Error fetching products:', error);
    return [];
  }
}

export default AccountID;