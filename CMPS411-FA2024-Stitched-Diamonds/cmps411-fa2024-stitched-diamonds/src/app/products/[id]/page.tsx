'use client';

import axios from 'axios';
import https from 'https';
import { useState, useEffect } from 'react';
import { StarIcon } from '@heroicons/react/20/solid';
import { Radio, RadioGroup } from '@headlessui/react';
import { CurrencyDollarIcon, GlobeAmericasIcon } from '@heroicons/react/24/outline';
import { useRouter } from 'next/navigation';

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

export default function ProductPage({ params }: { params: { id: string } }) {
  const { id } = params;
  const [product, setProduct] = useState<Product | null>(null);
  const [selectedColor, setSelectedColor] = useState(null);
  const [selectedSize, setSelectedSize] = useState(null);

  useEffect(() => {
    const fetchProduct = async () => {
      try {
        const res = await axios.get(`https://localhost:7120/api/products/${id}`, { httpsAgent });
        const productData = res.data.data;
        setProduct(productData);
      } catch (error) {
        console.error('Error fetching product:', error);
      }
    };
    fetchProduct();
  }, [id]);

  if (!product) {
    return <div>Loading...</div>;
  }

  return (
    <div className="bg-white">
      <div className="pb-16 pt-6 sm:pb-24">
        {/* Breadcrumbs */}
        <nav aria-label="Breadcrumb" className="mx-auto max-w-7xl px-4 sm:px-6 lg:px-8">
          {/* Breadcrumbs logic here */}
        </nav>

        <div className="mx-auto mt-8 max-w-2xl px-4 sm:px-6 lg:max-w-7xl lg:px-8">
          <div className="lg:grid lg:auto-rows-min lg:grid-cols-12 lg:gap-x-8">
            {/* Product Details */}
            <div className="lg:col-span-5 lg:col-start-8">
              <h1 className="text-xl font-medium text-gray-900">{product.name}</h1>
              <p className="text-xl font-medium text-gray-900">${product.price}</p>
              
              {/* Reviews */}
              <div className="mt-4">
                <h2 className="sr-only">Reviews</h2>
                <div className="flex items-center">
                  {/* Star rating logic */}
                </div>
              </div>
            </div>

            {/* Image Gallery */}
            <div className="mt-8 lg:col-span-7 lg:col-start-1 lg:row-span-3 lg:row-start-1 lg:mt-0">
              <h2 className="sr-only">Images</h2>
              <img src={product.imageUrl} alt={product.name} className="rounded-lg" />
            </div>

            {/* Color and Size selection */}
            <div className="mt-8 lg:col-span-5">
              <form>
                <div>
                  <h2 className="text-sm font-medium text-gray-900">Color</h2>
                  <fieldset className="mt-2">
                    <RadioGroup value={selectedColor} onChange={setSelectedColor} className="flex items-center space-x-3">
                      {/* Color options here */}
                    </RadioGroup>
                  </fieldset>
                </div>

                <div className="mt-8">
                  <h2 className="text-sm font-medium text-gray-900">Size</h2>
                  <fieldset className="mt-2">
                    <RadioGroup value={selectedSize} onChange={setSelectedSize} className="grid grid-cols-3 gap-3 sm:grid-cols-6">
                      {/* Size options here */}
                    </RadioGroup>
                  </fieldset>
                </div>

                <button type="submit" className="mt-8 w-full rounded-md bg-indigo-600 px-8 py-3 text-white">
                  Add to cart
                </button>
              </form>

              {/* Description */}
              <div className="mt-10">
                <h2 className="text-sm font-medium text-gray-900">Description</h2>
                <div className="prose prose-sm mt-4 text-gray-500" dangerouslySetInnerHTML={{ __html: product.description }} />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
