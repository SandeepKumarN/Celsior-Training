<template>
    <div>
      <!-- Header Section -->
      <header class="header">
        <div class="header-left">
          <img src="" alt="EShopping" class="logo" />
        </div>
        <div class="header-center">
          <input v-model="searchQuery" type="text" placeholder="Search for books..." class="search-bar" />
        </div>
        <div class="header-right">
          <button @click="goToCart" class="cart-button">
            <span>🛒 Cart</span>
          </button>
          <button class="login-button" @click="goToLogin">Login</button>
        </div>
      </header>
  
      <!-- Books Section -->
      <section class="books-section">
        <h2>Books</h2>
        <div class="books-grid">
          <div v-for="book in books" :key="book.id" class="book-card">
            <img :src="book.image" :alt="book.title" class="book-image" />
            <div class="book-details">
              <h3>{{ book.title }}</h3>
              <p><strong>Author:</strong> {{ book.author }}</p>
              <p>{{ book.description }}</p>
              <span class="price">${{ book.price }}</span>
              <div class="rating">
                <span v-for="n in book.rating" :key="n" class="star">⭐</span>
                <span class="rating-count">({{ book.reviewsCount }} reviews)</span>
              </div>
              <button @click="addToCart(book)" class="add-to-cart">Add to Cart</button>
            </div>
          </div>
        </div>
      </section>
  
      <!-- Footer Section -->
      <footer class="footer">
        <p>&copy; 2024 Amazon Clone. All Rights Reserved.</p>
        <div class="footer-links">
          <a href="#">Privacy Policy</a>
          <a href="#">Terms of Service</a>
          <a href="#">Help</a>
        </div>
      </footer>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        searchQuery: '',
        books: [
          {
            id: 1,
            title: 'The Great Gatsby',
            author: 'F. Scott Fitzgerald',
            description: 'A novel about the American dream in the 1920s.',
            price: 10.99,
            image: 'https://via.placeholder.com/150',
            rating: 4,
            reviewsCount: 1500
          },
          {
            id: 2,
            title: '1984',
            author: 'George Orwell',
            description: 'A dystopian novel that explores totalitarianism.',
            price: 8.99,
            image: 'https://via.placeholder.com/150',
            rating: 5,
            reviewsCount: 3200
          },
          {
            id: 3,
            title: 'To Kill a Mockingbird',
            author: 'Harper Lee',
            description: 'A story about racial injustice in the 1930s American South.',
            price: 12.49,
            image: 'https://via.placeholder.com/150',
            rating: 5,
            reviewsCount: 4500
          },
          // Add more books here
        ]
      };
    },
    methods: {
      goToCart() {
        // Navigate to the cart page
        this.$router.push('/cart');
      },
      goToLogin() {
        // Navigate to the login page
        this.$router.push('/login');
      },
      addToCart(book) {
        // Mock function to add book to cart
        console.log('Added to Cart:', book);
        // You can integrate actual cart functionality here
      }
    }
  };
  </script>
  
  <style scoped>
  /* Header Styles */
  .header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    background-color: #131921;
    padding: 10px 20px;
    color: white;
  }
  
  .header-left .logo {
    height: 40px;
  }
  
  .header-center .search-bar {
    width: 50%;
    padding: 8px;
    border-radius: 20px;
    border: none;
  }
  
  .header-right .cart-button,
  .header-right .login-button {
    background-color: #ff9900;
    color: white;
    padding: 8px 16px;
    border: none;
    cursor: pointer;
  }
  
  .header-right .login-button {
    background-color: #232f3e;
    margin-left: 10px;
  }
  
  /* Books Section Styles */
  .books-section {
    padding: 20px;
  }
  
  .books-section h2 {
    font-size: 24px;
    margin-bottom: 20px;
  }
  
  .books-grid {
    display: flex;
    justify-content: space-around;
    flex-wrap: wrap;
  }
  
  .book-card {
    width: 220px;
    background-color: #f8f8f8;
    padding: 15px;
    border-radius: 8px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
    margin-bottom: 20px;
  }
  
  .book-card .book-image {
    width: 100%;
    height: 250px;
    object-fit: cover;
    border-radius: 8px;
  }
  
  .book-card .book-details {
    margin-top: 10px;
  }
  
  .book-card .price {
    font-size: 18px;
    font-weight: bold;
    color: #ff9900;
  }
  
  .book-card .rating {
    margin-top: 10px;
  }
  
  .book-card .star {
    color: #ff9900;
  }
  
  .book-card .rating-count {
    margin-left: 5px;
    color: gray;
  }
  
  .book-card .add-to-cart {
    background-color: #ff9900;
    color: white;
    padding: 8px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
  }
  
  /* Footer Styles */
  .footer {
    background-color: #232f3e;
    color: white;
    text-align: center;
    padding: 20px 0;
  }
  
  .footer-links {
    margin-top: 10px;
  }
  
  .footer-links a {
    color: #ff9900;
    margin: 0 10px;
    text-decoration: none;
  }
  </style>
  