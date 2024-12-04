<!-- <script>
    export default{
        name:"ProductList",
        data(){
            return{
                products:[],
                btnClick:()=>{
                    fetch('https://dummyjson.com/products')
                    .then(res => res.json())
                    .then(data=>{
                        console.log(data.products);
                        this.products = data.products
                    });
                }
            }
        }
    }
</script>
<template>
    <section>
        <h1>Products</h1>

        <button @click="btnClick()" class="btn btn-success">Click me</button>
        <div v-if="products.length>0">
            <h2>List</h2>
            <div class="d-flex gap-5">
                <p v-for="product in products" :key="product.id">
                {{ product.title }}
            </p>
            </div>
            
        </div>
    </section>
</template>
<style>
</style> -->

<script>
export default {
  name: "ProductList",
  data() {
    return {
      products: [],
      categories: [],
      selectedCategory: "",
    };
  },
  methods: {
    fetchProductsByCategory() {
      if (this.selectedCategory) {
        fetch(`https://dummyjson.com/products/category/${this.selectedCategory}`)
          .then((res) => res.json())
          .then((data) => {
            if (data.products && data.products.length > 0) {
              this.products = data.products;
            } else {
              this.products = [];
            }
          })
          .catch((error) => {
            console.error("Error fetching products:", error);
            this.products = [];
          });
      } else {
        this.products = [];
      }
    },

    fetchCategories() {
      fetch("https://dummyjson.com/products/categories")
        .then((res) => res.json())
        .then((data) => {
          this.categories = data;
        })
        .catch((error) => {
          console.error("Error fetching categories:", error);
        });
    },
  },
  watch: {
    selectedCategory() {
      this.fetchProductsByCategory();
    },
  },
  mounted() {
    this.fetchCategories();
  },
};
</script>

<template>
  <section>
    <h1>Product List</h1>

    <!-- Dropdown for Categories -->
    <div>
      <label for="category">Select Category:</label>
      <select id="category" v-model="selectedCategory">
        <option value="">Select a Category</option>
        <option v-for="category in categories" :key="category" :value="category">
          {{ category }}
        </option>
      </select>
    </div>

    <!-- Product List -->
    <div v-if="products.length > 0">
      <h2>Products in Category: {{ selectedCategory }}</h2>
      <div>
        <div v-for="product in products" :key="product.id">
          <h3>{{ product.title }}</h3>
          <p>{{ product.description }}</p>
          <span>${{ product.price }}</span>
        </div>
      </div>
    </div>

    <!-- Message if no products are available -->
    <div v-if="products.length === 0 && selectedCategory">
      <p>No products available for this category.</p>
    </div>
  </section>
</template>

<style>
</style>





