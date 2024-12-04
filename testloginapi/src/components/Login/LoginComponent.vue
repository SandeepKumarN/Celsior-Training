<script>
import { login } from '@/Script/LoginService';

export default {
  name: 'LoginComponent',
  data() {
    return {
      email: '',
      password: '',
      isLoading: false,
    };
  },
  methods: {
    async handleLogin() {
      try {
        this.isLoading = true;
        const response = await login(this.email, this.password);

        if (response && response.status === 200) {
          // After successful login, store the token and role
          sessionStorage.setItem('token', response.data.token);
          sessionStorage.setItem('role', response.data.role); // Storing the role
          this.isLoading = false;

          //Redirect based on role 
          if(response.data.role === 'admin') {
            this.$router.push('/admin-dashboard'); 
          } else {
            this.$router.push('/products');
          }
        } else {
          this.isLoading = false;
          console.error('Login failed:', response);
        }
      } catch (error) {
        this.isLoading = false;
        console.error('Error during login:', error);
      }
    },
  },
};
</script>

<template>
  <div class="container d-flex align-items-center">
    <div class="row my-center align-items-center position-relative">
      <div v-if="isLoading" class="position-absolute text-center">
        <img src="./../../assets/loginload.png" alt="Loading">
      </div>
      <div class="col-md-6">
        <img src="./../../assets/gradient-connection-background_52683-116380.avif" alt="Image" class="img-fluid">
      </div>
      <div class="col-md-6 contents">
        <div class="row justify-content-center">
          <div class="col-md-8">
            <div class="mb-4">
              <h4>Welcome Back to Shopping!</h4>
              <p class="mb-4">Sign in to enjoy endless shopping.</p>
            </div>
            <form @submit.prevent="handleLogin">
              <div class="form-group first">
                <label hidden for="email">Email</label>
                <input
                  type="text"
                  class="form-control"
                  v-model="email"
                  id="email"
                  placeholder="Email"
                />
              </div>
              <div class="form-group last">
                <label hidden for="password">Password</label>
                <input
                  type="password"
                  class="form-control"
                  v-model="password"
                  id="password"
                  placeholder="Password"
                />
              </div>
                <button
                type="submit"
                class="btn btn-block btn-primary w-100 p-3"
                :disabled="isLoading"
              >
                Log In
              </button>
            </form>
            <div>
              <span>New to Shopping?</span>
              <router-link to="/registration">Sign up now</router-link>
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
  background-color: rgb(250, 248, 248);
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