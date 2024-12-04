<template>
  <img alt="Vue logo" src="./assets/logo.png">
  <!-- <HelloWorld/>
  <FirstComponent/> -->
  <ProductList/>
</template>

<script>
// import FirstComponent from './components/FirstComponent.vue';
// import HelloWorld from './components/HelloWorld.vue'
import ProductList from './components/ProductList.vue';

export default {
  name: 'App',
  components: {
    // HelloWorld,
    // FirstComponent,
    ProductList
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
