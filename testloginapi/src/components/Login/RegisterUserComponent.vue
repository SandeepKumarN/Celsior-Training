<script>
  import { registration } from '@/Script/LoginService';
  
  export default {
    name: 'RegisterUserComponent',
    data() {
      return {
        id: '',
        username: '',
        email: '',
        password: '',
        role: '',
        isLoading: false,
      };
    },
    methods: {
      async handleRegistration() {
        try {
          this.isLoading = true;
  
          // Remove role parameter since it's not required
          const response = await registration(this.id, this.username, this.email, this.password, this.role);
  
          if (response && response.status === 200) {
            // After successful registration, redirect to login
            this.isLoading = false;
            this.$router.push('/login');
          } else {
            this.isLoading = false;
            console.error('Registration failed:', response);
          }
        } catch (error) {
          this.isLoading = false;
          console.error('Error during registration:', error);
        }
      },
    },
  };
  </script>

<template>
    <div class="container d-flex align-items-center">
      <div class="row my-center align-items-center position-relative">
        <div v-if="isLoading" class="position-absolute text-center">
          <img src="./../../assets/download.png" alt="Loading">
        </div>
        <div class="col-md-6">
          <img src="./../../assets/images.jpg" alt="Image" class="img-fluid">
        </div>
        <div class="col-md-6 contents">
          <div class="row justify-content-center">
            <div class="col-md-8">
              <div class="mb-4">
                <h4>Welcome to Shopping!</h4>
                <p class="mb-4">Sign Up to enjoy endless shopping.</p>
              </div>
  
              <form @submit.prevent="handleRegistration">
                <div class="form-group">
                  <label hidden for="username">Username</label>
                  <input
                    type="text"
                    class="form-control"
                    v-model="username"
                    id="username"
                    placeholder="Username"
                    required
                    minlength="5"
                  />
                </div>
                <div class="form-group">
                  <label hidden for="email">Email</label>
                  <input
                    type="text"
                    class="form-control"
                    v-model="email"
                    id="email"
                    placeholder="Email"
                    required
                  />
                </div>
                <div class="form-group">
                  <label hidden for="password">Password</label>
                  <input
                    type="password"
                    class="form-control"
                    v-model="password"
                    id="password"
                    placeholder="Create password"
                    required
                  />
                </div>

                <div class="form-group">
                  <label hidden for="id">Id</label>
                  <input
                    type="text"
                    class="form-control"
                    v-model="id"
                    id="id"
                    placeholder="Id"
                    required
                  />
                </div>
                <div class="log">
                  <select v-model="this.role" name="" id="">
                    <option value="">Role</option>
                    <option value="admin">Admin</option>
                    <option value="customer">Customer</option>

                  </select>
                </div>

                <button
                  type="submit"
                  class="btn btn-block btn-primary w-100 p-3"
                  :disabled="isLoading"
                >
                  Register
                </button>
              </form>
  
              <div>
                <span>Already have an account?</span>
                <router-link to="/login">Login now</router-link>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  
  
  <style scoped>
  .img-fluid {
    height: 600px;
    width: 800px;
  }

  .container {
    background-color: rgb(248 249 250);
    height: 100vh;
  }
  .form-group {
    color: #edf2f5;
  }
  input {
    background: #ced4da;
    height: 70px;
    font-size: 15px;
  }
  </style>