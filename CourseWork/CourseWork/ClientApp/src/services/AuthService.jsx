import axios from "axios";
import { useState } from "react";

const API_URL = "https://localhost:44308/api/User/";

class AuthService {
  getCurrentUser() {
    const { data, setData } = useState({});
    axios
      .get(API_URL + `get-current-user?email=${localStorage.getItem("email")}`)
      .then((response) => {
        if (response.status === 200) {
          // localStorage.removeItem("email");
          // localStorage.setItem("currentUser", JSON.stringify(response.data));
        }
        setData(response.data);
        // return response.data;
      });
    console.log(data);
    return data;
  }

  login(email, password) {
    return axios
      .post(API_URL + "login", {
        email,
        password,
      })
      .then((response) => {
        if (response.status === 200) {
          localStorage.setItem("token", response.data.token);
          localStorage.setItem("email", email);
        }
        return response.data;
      });
  }

  logout() {
    localStorage.removeItem("token");
  }

  getToken() {
    return JSON.stringify(localStorage.getItem("token"));
  }
}
export default new AuthService();
