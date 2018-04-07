import axios from 'axios';

const BASE_URL = 'http://127.0.0.1:8000';

export {getAllUsers, login};

function getAllUsers() {
  const url = `${BASE_URL}/api/users`;
  return axios.get(url).then(response => response.data);
}

function login() {
  const url = `${BASE_URL}/login`;
  return axios.post(url, {email : 'helo@helo.com', password : 'hello'}).then(response => response.data);
}
