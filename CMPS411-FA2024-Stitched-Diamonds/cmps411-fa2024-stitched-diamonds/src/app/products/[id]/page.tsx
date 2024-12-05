"use client";

import axios from "axios";
import https from "https";
import { useState, useEffect } from "react";
import { useParams } from "next/navigation";
import { StarIcon } from "@heroicons/react/20/solid";
import { RadioGroup } from "@headlessui/react";

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

type CartItemCreateDto = {
  CartId: number;
  ProductId: string;
  VariantId: number | null;
  Quantity: number;
  Price: number;
};

export default function ProductPage() {
  const params = useParams(); // Fetch params using the client-side router
  const { id } = params as { id: string }; // Typecast if needed
  const [product, setProduct] = useState<Product | null>(null);
  const [selectedColor, setSelectedColor] = useState(null);
  const [selectedSize, setSelectedSize] = useState(null);
  const [cartId, setCartId] = useState<number | null>(null);

  useEffect(() => {
    if (!id) return; // Ensure `id` is available before making the request
    const fetchProduct = async () => {
      try {
        const res = await axios.get(
          `https://localhost:7120/api/products/${id}`,
          { httpsAgent }
        );
        const productData = res.data.data;
        setProduct(productData);
      } catch (error) {
        console.error("Error fetching product:", error);
      }
    };
    fetchProduct();
  }, [id]);

  const addToCart = async () => {
    if (!product || !cartId) return;

    const cartItem: CartItemCreateDto = {
      CartId: cartId,
      ProductId: product.id,
      VariantId: null, // Use selected color or size as variant ID
      Quantity: 1, // Defaulting to 1 for now, can be adjusted
      Price: product.price,
    };

    try {
      await axios.post("https://localhost:7120/api/cartItems", cartItem, {
        httpsAgent,
      });
      console.log("Product added to cart");
    } catch (error) {
      console.error("Error adding product to cart", error);
    }
  };

  if (!product) {
    return <div>Loading...</div>;
  }

  return (
    <div className="bg-white">
      <div className="pb-16 pt-6 sm:pb-24">
        {/* Breadcrumbs */}
        <nav
          aria-label="Breadcrumb"
          className="mx-auto max-w-7xl px-4 sm:px-6 lg:px-8"
        >
          {/* Breadcrumbs logic here */}
        </nav>

        <div className="mx-auto mt-8 max-w-2xl px-4 sm:px-6 lg:max-w-7xl lg:px-8">
          <div className="lg:grid lg:auto-rows-min lg:grid-cols-12 lg:gap-x-8">
            {/* Product Details */}
            <div className="lg:col-span-5 lg:col-start-8">
              <h1 className="text-xl font-medium text-gray-900">
                {product.name}
              </h1>
              <p className="text-xl font-medium text-gray-900">
                ${product.price.toFixed(2)}
              </p>

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
              <img
                src={product.imageUrl}
                alt={product.name}
                className="rounded-lg"
              />
            </div>

            {/* Color and Size selection */}
            <div className="mt-8 lg:col-span-5">
              <form>
                <div>
                  <h2 className="text-sm font-medium text-gray-900">Color</h2>
                  <fieldset className="mt-2">
                    <RadioGroup
                      value={selectedColor}
                      onChange={setSelectedColor}
                      className="flex items-center space-x-3"
                    >
                      {/* Color options */}
                    </RadioGroup>
                  </fieldset>
                </div>

                <div className="mt-8">
                  <h2 className="text-sm font-medium text-gray-900">Size</h2>
                  <fieldset className="mt-2">
                    <RadioGroup
                      value={selectedSize}
                      onChange={setSelectedSize}
                      className="grid grid-cols-3 gap-3 sm:grid-cols-6"
                    >
                      {/* Size options */}
                    </RadioGroup>
                  </fieldset>
                </div>

                <button
                  type="submit"
                  className="mt-8 w-full rounded-md bg-indigo-600 px-8 py-3 text-white"
                  onClick={addToCart}
                >
                  Add to cart
                </button>
              </form>

              {/* Description */}
              <div className="mt-10">
                <h2 className="text-sm font-medium text-gray-900">
                  Description
                </h2>
                <div
                  className="prose prose-sm mt-4 text-gray-500"
                  dangerouslySetInnerHTML={{ __html: product.description }}
                />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
