<template>
  <div class="admin-dashboard">
    <div class="sidebar">
      <h2>Admin Dashboard</h2>
      <ul>
        <!-- <li><router-link to="/admin-dashboard/overview">Overview</router-link></li> -->
        <li><router-link to="/products">Products</router-link></li>
        <li><router-link to="/admin-dashboard/orders">Orders</router-link></li>
        <li><router-link to="/customer">Customers</router-link></li>
        <!-- <li><router-link to="/admin-dashboard/settings">Settings</router-link></li> -->
      </ul>
    </div>

    <div class="main-content">
      <router-view /> <!-- This will render the content based on the selected route -->
    </div>
  </div>
</template>

<script>
export default {
  name: "AdminDashboardComponent",
};
</script>

<style scoped>
.admin-dashboard {
  display: flex;
}

.sidebar {
  width: 250px;
  background-color: #333;
  color: white;
  padding: 20px;
  position: fixed;
  height: 100%;
}

.sidebar h2 {
  margin: 0;
  font-size: 24px;
  padding-bottom: 20px;
  border-bottom: 1px solid #444;
}

.sidebar ul {
  list-style-type: none;
  padding: 0;
}

.sidebar ul li {
  margin: 20px 0;
}

.sidebar ul li a {
  color: white;
  text-decoration: none;
  font-size: 18px;
}

.sidebar ul li a:hover {
  color: #f2b632;
}

.main-content {
  margin-left: 270px;
  padding: 20px;
  width: 100%;
}

h1 {
  font-size: 28px;
  margin-bottom: 20px;
}

.card {
  background-color: #fff;
  padding: 20px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  margin-bottom: 20px;
}

.card .card-header {
  font-size: 20px;
  font-weight: bold;
}

.card .card-body {
  font-size: 16px;
}

.card .card-footer {
  text-align: right;
  font-size: 14px;
  color: gray;
}
</style>
