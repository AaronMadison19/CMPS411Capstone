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
};

type CategoryResponse = {
  data: {
    id: number;
    type: string;
    products: Product[];
  };
  errors: any[];
  hasErrors: boolean;
};

export default function CategoryPage() {
  const params = useParams();
  const { id } = params as { id: string };
  const [categoryResponse, setCategoryResponse] = useState<CategoryResponse | null>(null);

  useEffect(() => {
    if (!id) return;
    
    const fetchCategory = async () => {
      try {
        const res = await axios.get<CategoryResponse>(`https://localhost:7120/api/categories/${id}`, { 
          httpsAgent 
        });
        setCategoryResponse(res.data);
      } catch (error) {
        console.error('Error fetching category:', error);
      }
    };
    
    fetchCategory();
  }, [id]);

  if (!categoryResponse || categoryResponse.hasErrors) {
    return <div>Loading or Error...</div>;
  }

  const { type, products } = categoryResponse.data;

  return (
    <div className="bg-white">
      <div className="mx-auto max-w-7xl px-4 sm:px-6 lg:px-8">
        <div className="py-16">
          <h1 className="text-3xl font-bold text-gray-900 mb-8">{type} Category</h1>

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
              </Link>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
}