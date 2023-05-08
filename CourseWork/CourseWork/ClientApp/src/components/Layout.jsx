import React, { Component } from "react";
import { Header } from "./Header";
import Footer from "./Footer";

export class Layout extends React.Component {
  static displayName = Layout.name;

  constructor(props) {
    super(props);
    this.state = { spinnerLoading: true };
  }

  render() {
    return (
      <div>
        <Header />
        {this.props.children}
        <Footer />
      </div>
    );
  }
}
