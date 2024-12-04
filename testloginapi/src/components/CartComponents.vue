<template>
  <div>
    <h1>Your Cart</h1>

    <!-- Show loading state -->
    <div v-if="loading">Loading cart...</div>

    <!-- Show error state -->
    <div v-if="error" class="error">{{ error }}</div>

    <!-- Display cart items -->
    <div v-if="cart.length > 0">
      <ul>
        <li v-for="item in cart" :key="item.id">
          <p>{{ item.name }} - ${{ item.price }}</p>
        </li>
      </ul>
      <button @click="checkout">Proceed to Checkout</button>
    </div>

    <!-- Empty cart state -->
    <div v-else>
      <p>Your cart is empty.</p>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: {
    cart: {
      type: Array,
      default: () => [],
    },
  },
  data() {
    return {
      loading: false,
      error: null,
    };
  },
  watch: {
    cart: {
      handler(newCart) {
        this.saveCartToAPI(newCart);
      },
      deep: true, // Watch for changes in nested objects
    },
  },
  methods: {
    async saveCartToAPI(cart) {
      this.loading = true;
      this.error = null;
      try {
        // Replace with your backend API endpoint
        await axios.post("https://localhost:7045/api/Cart", { cartItems: cart });
      } catch (error) {
        console.error("Failed to save cart to API:", error);
        this.error = "Failed to update cart. Please try again.";
      } finally {
        this.loading = false;
      }
    },
    checkout() {
      alert("Proceeding to checkout!");
    },
  },
};
</script>

<style scoped>
.error {
  color: red;
  font-weight: bold;
}

button {
  margin-top: 10px;
  padding: 8px 16px;
  background-color: #4CAF50;
  color: white;
  border: none;
  cursor: pointer;
}

button:hover {
  background-color: #45a049;
}
</style>
