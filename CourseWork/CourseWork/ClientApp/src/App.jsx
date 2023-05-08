import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import { Layout } from "./components/Layout";

import "./custom.css";
import { Home } from "./components/Home";
import React from "react";
import { Login } from "./components/Login";
import { GenerateAbiturient } from "./components/Generate-abiturient";
import Profile from "./components/Profile";

export default class App extends React.Component {
  static displayName = App.name;
  render() {
    return (
      <Router>
        <Layout>
          <Route exact path="/" component={Home} />
          <Route path="/login" component={Login} />
          <Route path="/profile" component={Profile} />
          <Route path="/generate-abiturient" component={GenerateAbiturient} />
        </Layout>
      </Router>
    );
  }
}
