CREATE TABLE `users` (
  `id` integer PRIMARY KEY,
  `first_name` varchar(255),
  `last_name` varchar(255),
  `email` varchar(255),
  `username` varchar(255),
  `password` varchar(255),
  `phone_number` varchar(255),
  `create_date` timestamp,
  `is_active` bool,
  `role` varchar(255)
);

CREATE TABLE `account` (
  `id` integer PRIMARY KEY,
  `user_id` integer,
  `billing_address` varchar(255),
  `shipping_address` varchar(255),
  `username` varchar(255),
  `is_active` bool
);

CREATE TABLE `products` (
  `id` integer PRIMARY KEY,
  `image_url` varchar(255),
  `name` varchar(255),
  `description` text,
  `price` integer,
  `category_id` integer,
  `details` text,
  `materials_id` integer
);

CREATE TABLE `categories` (
  `id` integer PRIMARY KEY,
  `type` varchar(255),
  `category_type` varchar(255)
);

CREATE TABLE `reviews` (
  `id` integer PRIMARY KEY,
  `title` varchar(255),
  `body` text COMMENT 'Content of the post',
  `user_id` integer,
  `created_at` timestamp,
  `product_id` integer,
  `rating` integer,
  `is_visible` bool
);

CREATE TABLE `orders` (
  `id` integer PRIMARY KEY,
  `date` timestamp,
  `number` integer,
  `total_price` decimal,
  `payment_method` varchar(255),
  `account_id` integer,
  `product_id` integer
);

CREATE TABLE `sales` (
  `product_id` integer,
  `quantity_sold` integer,
  `unit_price` integer
);

CREATE TABLE `inventory` (
  `product_id` integer,
  `quantity_in_stock` integer,
  `cost` decimal,
  `reorder_level` integer,
  `reorder_quantity` integer
);

CREATE TABLE `shipping` (
  `id` integer PRIMARY KEY,
  `account_id` integer,
  `address` varchar(255),
  `cost` decimal
);

CREATE TABLE `materials` (
  `id` integer PRIMARY KEY,
  `type` varchar(255),
  `is_allergen_free` bool,
  `quantity_in_stock` integer
);

CREATE TABLE `statistics` (
  `collection_date` timestamp,
  `total_sales` decimal,
  `total_orders` integer,
  `total_units_sold` integer,
  `total_users` integer,
  `average_order_value` decimal,
  `average_units_per_order` integer,
  `refund_amount` decimal,
  `top_performing_category` varchar(255),
  `gross_profit_margin` decimal,
  `operating_expenses` decimal,
  `net_profit` decimal
);

ALTER TABLE `account` ADD FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

ALTER TABLE `account` ADD FOREIGN KEY (`username`) REFERENCES `users` (`username`);

ALTER TABLE `account` ADD FOREIGN KEY (`is_active`) REFERENCES `users` (`is_active`);

ALTER TABLE `products` ADD FOREIGN KEY (`category_id`) REFERENCES `categories` (`id`);

CREATE TABLE `materials_products` (
  `materials_id` integer,
  `products_materials_id` integer,
  PRIMARY KEY (`materials_id`, `products_materials_id`)
);

ALTER TABLE `materials_products` ADD FOREIGN KEY (`materials_id`) REFERENCES `materials` (`id`);

ALTER TABLE `materials_products` ADD FOREIGN KEY (`products_materials_id`) REFERENCES `products` (`materials_id`);


ALTER TABLE `reviews` ADD FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

ALTER TABLE `reviews` ADD FOREIGN KEY (`product_id`) REFERENCES `products` (`id`);

ALTER TABLE `orders` ADD FOREIGN KEY (`account_id`) REFERENCES `account` (`id`);

CREATE TABLE `products_orders` (
  `products_id` integer,
  `orders_product_id` integer,
  PRIMARY KEY (`products_id`, `orders_product_id`)
);

ALTER TABLE `products_orders` ADD FOREIGN KEY (`products_id`) REFERENCES `products` (`id`);

ALTER TABLE `products_orders` ADD FOREIGN KEY (`orders_product_id`) REFERENCES `orders` (`product_id`);


ALTER TABLE `sales` ADD FOREIGN KEY (`product_id`) REFERENCES `products` (`id`);

ALTER TABLE `products` ADD FOREIGN KEY (`id`) REFERENCES `inventory` (`product_id`);

ALTER TABLE `shipping` ADD FOREIGN KEY (`account_id`) REFERENCES `account` (`id`);

ALTER TABLE `shipping` ADD FOREIGN KEY (`address`) REFERENCES `account` (`shipping_address`);
