<script>
import axios from "axios";
import CartComponents from "../CartComponents.vue";
import ProductComponent from "./ProductComponent.vue";

export default {
  name: "ProductsComponent",
  components: { ProductComponent, CartComponents },
  data() {
    return {
      products: [],
      cart: [],
    };
  },
  created() {
    this.fetchProducts();
  },
  methods: {
    fetchProducts() {
      axios
        .get("https://localhost:7045/api/Product")
        .then((response) => {
          this.products = response.data;
        })
        .catch((error) => {
          console.error("Failed to fetch products:", error);
          alert("Failed to load products.");
        });
    },
    addToCart(product) {
      const exists = this.cart.some((item) => item.id === product.id);
      if (!exists) {
        this.cart.push(product);
      }
    },
  },
};
</script>

<template>
  <div class="products-container">
    <h1>Products</h1>
    <div class="products-grid">
      <ProductComponent
        v-for="product in products"
        :key="product.id"
        :product="product"
        @add-to-cart="addToCart"
      />
    </div>
    <CartComponents :cart="cart" />
  </div>
</template>

<style scoped>
.products-grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 20px;
}
</style>
