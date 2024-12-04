<script>
import { AddProduct } from "@/Script/ProductService";

export default {
  name: "AddProductComponent",
  data() {
    return {
      product: {
        name: "",
        description: "",
        quantity: 0,
        price: 0,
        basicImage: "",
      },
    };
  },
  methods: {
    addProduct() {
      AddProduct(this.product).then((response) => {
        alert(response.data.message);
        this.$router.push("/admin-dashboard");  // Redirect to Admin Dashboard after adding
      }).catch((error) => {
        alert("Failed to add product.");
        console.error(error);
      });
    },
  },
};
</script>

<template>
  <div class="add-product-form">
    <h2>Add a New Product</h2>
    <form @submit.prevent="addProduct">
      <div class="swap">
        <label>Name</label>
        <input class="sand" type="text" v-model="product.name" required />
      </div>
      <div class="swap">
        <label>Description</label>
        <input class="sand" type="text" v-model="product.description" required />
      </div>
      <div class="swap">
        <label>Quantity</label>
        <input class="sand" type="number" v-model="product.quantity" required />
      </div>
      <div class="swap">
        <label>Price</label>
        <input class="sand" type="number" v-model="product.price" required />
      </div>
      <div class="swap">
        <label>Image URL</label>
        <input class="sand" type="text" v-model="product.basicImage" />
      </div>
      <button id="add" type="submit">Add Product</button>
    </form>
  </div>
</template>

<style scoped>
.sand {
  height: 30px;
  width: 190px;
}

.swap {
  display: flex;
  justify-content: space-between;
}

#add {
    height: 60px;
    width: 100px;
    margin-left: 130px;
    background-color: blue;
    color: gold;
}
.add-product-form {
  width: 300px;
  margin: auto;
}
.add-product-form form {
  display: flex;
  flex-direction: column;
}
.add-product-form form div {
  margin-bottom: 10px;
}
.add-product-form form button {
  margin-top: 10px;
}
</style>
