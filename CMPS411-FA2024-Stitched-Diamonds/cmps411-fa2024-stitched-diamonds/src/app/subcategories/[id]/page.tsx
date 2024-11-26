'use client';

import axios from 'axios';
import https from 'https';
import { useState, useEffect } from 'react';
import { useParams } from 'next/navigation';
import Link from 'next/link';

const httpsAgent = new https.Agent({
  rejectUnauthorized: false,
});

type Product = {
  id: number;
  name: string;
  price: number;
  imageUrl: string;
  description: string;
  details: string;
  quantityInStock: number;
};

type SubcategoryResponse = {
  data: {
    id: number;
    subtype: string;
    categoryId: number;
    products: Product[];
  };
  errors: any[];
  hasErrors: boolean;
};

export default function SubcategoryPage() {
  const params = useParams();
  const { id } = params as { id: string };
  const [subcategoryResponse, setSubcategoryResponse] = useState<SubcategoryResponse | null>(null);

  useEffect(() => {
    if (!id) return;
    
    const fetchSubcategory = async () => {
      try {
        const res = await axios.get<SubcategoryResponse>(`https://localhost:7120/api/subcategories/${id}`, { 
          httpsAgent 
        });
        setSubcategoryResponse(res.data);
      } catch (error) {
        console.error('Error fetching subcategory:', error);
      }
    };
    
    fetchSubcategory();
  }, [id]);

  if (!subcategoryResponse || subcategoryResponse.hasErrors) {
    return <div>Loading or Error...</div>;
  }

  const { subtype, products } = subcategoryResponse.data;

  return (
    <div className="bg-white">
      <div className="mx-auto max-w-7xl px-4 sm:px-6 lg:px-8">
        <div className="py-16">
          <h1 className="text-3xl font-bold text-gray-900 mb-8">{subtype}</h1>

          <div className="grid grid-cols-1 gap-x-6 gap-y-10 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 xl:gap-x-8">
            {products.map((product) => (
              <Link 
                key={product.id} 
                href={`/products/${product.id}`} 
                className="group"
              >
                <div className="aspect-h-1 aspect-w-1 w-full overflow-hidden rounded-lg bg-gray-200 xl:aspect-h-8 xl:aspect-w-7">
                  <img
                    src={product.imageUrl}
                    alt={product.name}
                    className="h-full w-full object-cover object-center group-hover:opacity-75"
                  />
                </div>
                <h3 className="mt-4 text-sm text-gray-700">{product.name}</h3>
                <p className="mt-1 text-lg font-medium text-gray-900">${product.price.toFixed(2)}</p>
                <p className="mt-2 text-sm text-gray-500 line-clamp-2">{product.description}</p>
                <div className="mt-2 flex justify-between items-center">
                  <p className="text-sm text-gray-500">In Stock: {product.quantityInStock}</p>
                  <p className="text-xs text-gray-400 italic">{product.details}</p>
                </div>
              </Link>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
}