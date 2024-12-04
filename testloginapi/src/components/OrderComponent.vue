<template>
    <div class="order-container">
      <h1>Your Orders</h1>
  
      <!-- Loading State -->
      <div v-if="loading">Loading orders...</div>
  
      <!-- Error State -->
      <div v-if="error" class="error">{{ error }}</div>
  
      <!-- Orders List -->
      <div v-if="orders && orders.length > 0">
        <ul>
          <li v-for="order in orders" :key="order.id" class="order-item">
            <h3>Order #{{ order.id }}</h3>
            <p>Status: {{ order.status }}</p>
            <p>Total: ${{ order.totalPrice }}</p>
            <ul>
              <li v-for="item in order.orderItems" :key="item.product.id">
                <p>{{ item.product.name }} - Quantity: {{ item.quantity }} - ${{ item.totalPrice }}</p>
              </li>
            </ul>
            <button @click="viewOrderDetails(order.id)">View Details</button>
          </li>
        </ul>
      </div>
  
      <!-- No orders state -->
      <div v-else>
        <p>You have no orders yet.</p>
      </div>
  
      <hr />
  
      <h2>Create a New Order</h2>
  
      <!-- Check if cart is empty before placing an order -->
      <div v-if="cart && cart.length > 0">
        <button @click="createOrder">Place Order</button>
      </div>
      <div v-else>
        <p>Your cart is empty. Add products to the cart before placing an order.</p>
      </div>
    </div>
  </template>
  
  <script>
  import axios from "axios";
  
  export default {
    name: "OrderComponent",
    data() {
      return {
        orders: [], // Holds the list of orders
        cart: [], // Holds the products added to cart for the current user
        loading: false, // Loading state for orders
        error: null, // Error message for API calls
      };
    },
    created() {
      this.fetchOrders(); // Fetch orders when the component is created
      this.fetchCart(); // Fetch current user's cart
    },
    methods: {
      // Fetch the user's orders
      async fetchOrders() {
        this.loading = true;
        this.error = null; // Reset error state
  
        try {
          const response = await axios.get("https://localhost:7045/api/Order"); // Replace with the correct API endpoint for fetching orders
          this.orders = response.data; // Assign the orders data
        } catch (err) {
          console.error("Error fetching orders:", err);
          this.error = "Failed to fetch orders. Please try again later.";
        } finally {
          this.loading = false; // Stop the loading spinner
        }
      },
  
      // Fetch the user's cart (replace with correct endpoint if needed)
      async fetchCart() {
        try {
          const response = await axios.get("https://localhost:7045/api/Cart/2"); // Assume cart ID is 2
          this.cart = response.data.cartItems || []; // If the cart has items, set them to cart
        } catch (err) {
          console.error("Error fetching cart data:", err);
        }
      },
  
      // Create a new order from the current cart
      async createOrder() {
        // Ensure cart is not empty
        if (this.cart.length === 0) {
          alert("Your cart is empty! Add products to the cart before placing an order.");
          return;
        }
  
        // Prepare the order data from cart
        const orderData = {
          customerId: 16, // Assuming a fixed customerId for this example, replace with dynamic value
          totalPrice: this.cart.reduce((total, item) => total + item.price * item.quantity, 0),
          orderItems: this.cart.map(item => ({
            productId: item.productId,
            quantity: item.quantity,
            totalPrice: item.price * item.quantity,
          })),
        };
  
        try {
          // Send POST request to create the order
          const response = await axios.post("https://localhost:7045/api/Order", orderData);
  
          if (response.data) {
            alert("Order placed successfully!");
            this.cart = []; // Clear the cart after placing the order
            this.fetchOrders(); // Refresh orders
          }
        } catch (err) {
          console.error("Error placing order:", err);
          alert("Failed to place order. Please try again later.");
        }
      },
  
      // View order details (you can add more functionality as needed)
      viewOrderDetails(orderId) {
        this.$router.push({ name: "OrderDetails", params: { orderId } });
      },
    },
  };
  </script>
  
  <style scoped>
  .order-container {
    width: 80%;
    margin: auto;
  }
  
  .order-item {
    border-bottom: 1px solid #ccc;
    margin-bottom: 15px;
    padding-bottom: 15px;
  }
  
  .error {
    color: red;
    font-weight: bold;
  }
  
  button {
    background-color: #4CAF50;
    color: white;
    padding: 10px 20px;
    border: none;
    cursor: pointer;
  }
  
  button:hover {
    background-color: #45a049;
  }
  
  h3 {
    margin: 0;
  }
  
  hr {
    margin-top: 20px;
  }
  </style>
  