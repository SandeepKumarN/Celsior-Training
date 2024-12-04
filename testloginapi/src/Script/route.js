import AddProductComponent from "@/components/AddProductComponent.vue";
import AdminDashboardComponent from "@/components/AdminDashboardComponent.vue";
import CartComponents from "@/components/CartComponents.vue";
import CustomerComponent from "@/components/CustomerComponent.vue";
import HelloWorld from "@/components/HelloWorld.vue";
import LoginComponent from "@/components/Login/LoginComponent.vue";
import ProductComponent from "@/components/Login/ProductComponent.vue";
import ProductsComponent from "@/components/Login/ProductsComponent.vue";
import RegisterUserComponent from "@/components/Login/RegisterUserComponent.vue";
import OrderComponent from "@/components/OrderComponent.vue";
import { createRouter, createWebHistory } from 'vue-router';

const routes = [
  { path: "/", component: HelloWorld },
  { path: "/registration", component: RegisterUserComponent },
  { path: "/login", component: LoginComponent },
  { path: "/orders", component: OrderComponent},
  { path: "/add-product", component: AddProductComponent},
  //{ path: "/customer", component: CustomerComponent},
  { path: "/cart", component: CartComponents},
  { path: "/admin-dashboard", component: AdminDashboardComponent,
    children:[
      {
        // UserProfile will be rendered inside User's <router-view>
        // when /user/:id/profile is matched
        path: '/products',
        component: ProductsComponent,        
      },
      {
        path: '/customer',
        component: CustomerComponent,
      }
    ],    
  },
  { path: "/product", component: ProductComponent},
  { path: "/products", component: ProductsComponent,
    beforeEnter: (to, from, next) => {
      if (sessionStorage.getItem("token")) {
        next();
      } else {
        next("/login");
      }
    },
  },
  // { path: "/customer", component: CustomerComponent,
  //   beforeEnter: (to, from, next) => {
  //     const token = sessionStorage.getItem('token');
  //     const role = sessionStorage.getItem('role');

  //     if (token && role === 'customer') {
  //       next(); 
  //     } else {
  //       next("/login");
  //     }
  //   }
  // },
  
  // { path: "/admin-dashboard", component: AdminDashboardComponent,
  //   beforeEnter: (to, from, next) => {
  //     const role = sessionStorage.getItem("role");
  //     if(role === "admin") {
  //       next();
  //     } else {
  //       next("/login");
  //     }
  //   }
  // },
  
  // { path: "/add-product", component: AddProductComponent,
  //   beforeEnter: (to, from, next) => {
  //     const role = sessionStorage.getItem("role");
  //     if(role === "admin") {
  //       next();
  //     } else {
  //       next("/login");
  //     }
  //   } 
  //  },

];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL), // HTML5 History mode
  routes,
});

export default router;
