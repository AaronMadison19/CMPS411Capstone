import Image from "next/image";
import styles from "./styles/page.module.css";
import Link from "next/link";

export default function Home() {
  return (
    <main className={styles.main}>
      <header className={styles.header}>
        <div className={styles.logo}>
          <Image src="/logo.png" alt="Stitched Diamonds Logo" width={150} height={80} />
        </div>
        <h1 className={styles.companyName}>Stitched Diamonds</h1>
        <nav className={styles.nav}>
          <ul className={styles.navList}>
            <li><Link href="/">Home</Link></li>
            <li><Link href="#">Products</Link></li>
            <li><Link href="#">About Us</Link></li>
            <li><Link href="#">Cart</Link></li>
            <li><Link href="/login">Login</Link></li>
            <li><Link href="/signup">Sign up</Link></li>
          </ul>
        </nav>
      </header>

      <section className={styles.promoBanner}>
        <Image
          src="/promo-banner.jpg"
          alt="Promotional Banner"
          layout="fill"
          objectFit="cover"
          priority
        />
        <div className={styles.promoText}>
          <h2>Exclusive Deals Await!</h2>
          <p>Shop the latest arrivals at discounted prices.</p>
          <Link href="#" className={styles.shopNowBtn}>Shop Now</Link>
        </div>
      </section>

      <section className={styles.featuredProducts}>
        <h2 className={styles.sectionTitle}>Featured Products</h2>
        <div className={styles.grid}>
          <div className={styles.card}>
            <Image
              src="/product1.jpg"
              alt="Product 1"
              width={300}
              height={300}
            />
            <h3>500oz Diamond</h3>
            <p className={styles.price}>$29.99</p>
            <button className={styles.addToCartBtn}>Add to Cart</button>
          </div>
          {/* Add more product cards as necessary */}
        </div>
      </section>

      <footer className={styles.footer}>
        <p>© 2024 Stitched Diamonds. All rights reserved.</p>
      </footer>
    </main>
  );
}