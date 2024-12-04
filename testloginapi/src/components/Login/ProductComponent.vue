<script>
export default {
  name: "ProductComponent",
  props: ["product"],
  methods: {
    addToCart() {
      this.$emit("add-to-cart", this.product);
    },
  },
};
</script>

<template>
  <div class="product-card">
    <img :src="product.basicImage || 'https://via.placeholder.com/150'" alt="product image" />
    <h3>{{ product.name }}</h3>
    <p>{{ product.description }}</p>
    <p>{{ product.quantity }}</p>
    <p>${{ product.price }}</p>
    <button @click="addToCart">Add to Cart</button>
  </div>
</template>

<style scoped>
.product-card {
  border: 1px solid #ccc;
  padding: 20px;
  border-radius: 10px;
  text-align: center;
}
.product-card img {
  max-width: 100%;
  height: auto;
}
</style>
