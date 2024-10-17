import Image from "next/image";
import styles from "./styles/page.module.css";
import Link from "next/link";

export default function Home() {
  return (
    <main>
      <section>
        <div>
          <h2>Browse Earrings</h2>
          <Link href="/products">Shop Now</Link>
        </div>
        <div>
          <h2>Browse Clothing</h2>
          <Link href="/products">Shop Now</Link>
        </div>
        <div>
          <h2>Browse Sales</h2>
          <Link href="/products">Shop Now</Link>
        </div>
      </section>

      <footer className={styles.footer}>
        <p>© 2024 Made By Omega. All rights reserved.</p>
      </footer>
    </main>
  );
}
