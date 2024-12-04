import axios from 'axios';

export const registration = async (id, username, email, password, role) => {
  try {
    let convertRole = 0; 
    if (role == "customer") {
      convertRole = 0
    }
    const response = await axios.post('https://localhost:7045/api/User/Register', {
      username: username,
      email: email,
      password: password,
      id: id,
      role: convertRole,
    });
    return response;
  } catch (error) {
    console.error('Error during registration:', error);
    return error.response;
  }
};

export const login = async (email, password) => {
  try {
    const response = await axios.post('https://localhost:7045/api/User/Login', {
      username: email,
      password: password,
    });
    return response;
  } catch (error) {
    console.error('Error during login:', error);
    return error.response;
  }
};
