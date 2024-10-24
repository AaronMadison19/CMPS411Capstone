"use client"; // Ensures this component is rendered on the client side
import styles from "./styles/about.module.css"; // Correct path to the styles folder

const About: React.FC = () => {
  return (
    <div className={styles.aboutContainer}>
      {/* Hero Section */}
      <section className={styles.heroSection}>
        <h1 className={styles.heroTitle}>About Us</h1>
        <p className={styles.heroSubtitle}>
          Welcome to Stitched Diamonds, where passion meets craftsmanship.
        </p>
      </section>

      {/* Horizontal Sections for Mission, Story, Values */}
      <div className={styles.horizontalSections}>
        {/* Mission Section */}
        <div className={styles.sectionCard}>
          <h2 className={styles.sectionTitle}>Our Mission</h2>
          <p className={styles.sectionText}>
            At Stitched Diamonds, our mission is to provide high-quality products that combine both functionality and style. We focus on sourcing the best materials and ensuring every product meets the highest standards.
          </p>
        </div>

        {/* Story Section */}
        <div className={styles.sectionCard}>
          <h2 className={styles.sectionTitle}>Our Story</h2>
          <p className={styles.sectionText}>
            Born from a desire to craft exceptional products, Makena Johnson started with a vision to bring unique, durable, and elegant items to the market. What began as a small passion project quickly grew into something much bigger, thanks to our loyal customers and the dedication of our team.
          </p>
        </div>

        {/* Values Section */}
        <div className={styles.sectionCard}>
          <h2 className={styles.sectionTitle}>Our Values</h2>
          <ul className={styles.valuesList}>
            <li>Quality Craftsmanship</li>
            <li>Customer Satisfaction</li>
            <li>Innovation</li>
            <li>Sustainability</li>
          </ul>
        </div>
      </div>

      {/* Team Section */}
      <section className={styles.teamSection}>
        <h2 className={styles.sectionTitle}>Meet the Team</h2>
        <p className={styles.sectionText}>
          Our team consists of experienced professionals dedicated to bringing you the finest products on the market. From design to production, we ensure every step is handled with care.
          <br />
          Meet the faces behind Stitched Diamonds and discover the passion that drives us to create exceptional products every day.
        </p>
      </section>
    </div>
  );
};

export default About;
