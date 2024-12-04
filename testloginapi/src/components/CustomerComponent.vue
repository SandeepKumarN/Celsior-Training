<script>
import axios from 'axios';

export default {
  name: 'CustomerComponent',
  data() {
    return {
      customer: null,
      loading: true,
      errorMessage: '',
    };
  },
  created() {
    this.fetchCustomerData();
  },
  methods: {
    async fetchCustomerData() {
      //const customerId = sessionStorage.getItem('customerId'); // Get the customerId from sessionStorage
      const token = sessionStorage.getItem('token'); // Get the token from sessionStorage

      if (!token) {
        this.errorMessage = "User is not logged in. Please log in.";
        this.loading = false;
        return;
      }

      try {
        // Make the API call with customerId in the URL
        const response = await axios.get('https://localhost:7045/api/Customer/17', {
          headers: {
            Authorization: `Bearer ${token}`, // Send the token in the Authorization header
          },
        });

        if (response.status === 200) {
          this.customer = response.data; // Store the fetched customer data
        } else {
          this.errorMessage = `Failed to fetch customer data: ${response.statusText}`;
        }
      } catch (error) {
        if (error.response) {
          // Handle specific HTTP status codes if needed
          switch (error.response.status) {
            case 401:
              this.errorMessage = "Unauthorized. Please log in again.";
              break;
            case 404:
              this.errorMessage = "Customer not found.";
              break;
            default:
              this.errorMessage = "Error fetching customer data. Please try again later.";
          }
        } else {
          this.errorMessage = "Network error. Please check your connection.";
        }
        console.error('Error fetching customer data:', error);
      } finally {
        this.loading = false;
      }
    },
  },
};
</script>

<template>
  <div class="container">
    <div v-if="loading" class="loading">
      <p>Loading customer data...</p>
    </div>

    <div v-else>
      <div v-if="errorMessage">
        <p>{{ errorMessage }}</p>
      </div>

      <div v-else>
        <h3>Customer Information</h3>
        <p><strong>Name:</strong> {{ customer.name }}</p>
        <p><strong>Email:</strong> {{ customer.email }}</p>
        <p><strong>Phone:</strong> {{ customer.phone }}</p>
        <p><strong>Address:</strong> {{ customer.address }}</p>
      </div>
    </div>
  </div>
</template>

<style scoped>
.container {
  padding: 20px;
}

.loading {
  text-align: center;
}

p {
  font-size: 1.2em;
}

h3 {
  font-size: 2em;
  margin-bottom: 10px;
}
</style>
