import React, { useEffect } from "react";
import Footer from "./components/Footer";
import Hero from "./components/Hero";
import Navbar from "./components/Navbar";
import Recommend from "./components/Recommend";
import ScrollToTop from "./components/ScrollToTop";
import Services from "./components/Services";
import Testimonials from "./components/Testimonials";
import scrollreveal from "scrollreveal";
import MainPage from "./components/MainPage";
import Login from "./components/Login";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

export default function App() {
  useEffect(() => {
    const sr = scrollreveal({
      origin: "top",
      distance: "80px",
      duration: 2000,
      reset: true,
    });
    sr.reveal(
      `nav,
      #hero,
      #services,
      #recommend,
      testimonials,
      #footer
      `,
      {
        opacity: 0,
        interval: 300,
      }
    );
  }, []);

  return (
    <Router>
      {/* ScrollToTop should be outside Routes but inside Router */}
      <ScrollToTop />
      
      {/* Navbar is part of the static layout */}
      <Navbar />
      
      {/* Routes for dynamic content */}
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/login" element={<Login />} />
      </Routes>

      {/* Footer remains the same throughout the app */}
      <Footer />
    </Router>
  );
}
