import axios from 'axios';

const BASE_URL = 'http://127.0.0.1:8000';

export {getAllUsers};

function getAllUsers() {
  const url = `${BASE_URL}/api/users`;
  return axios.get(url).then(response => response.data);
}
