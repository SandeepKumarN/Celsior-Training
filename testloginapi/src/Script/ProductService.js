import axios from './myAxiosInterceptor';


export function AddProduct(product) {
  // console.log(name,  description, quantity,price, image);
  return axios.post('https://localhost:7045/api/Product',{

        "name": product.name,
        "description": product.description,
        "quantity": product.quantity,
        "price": product.price,
        "basicImage": product.basicImage
  }
 );
}

export function GetProducts() {
  return axios.get('https://localhost:7045/api/Product');
}