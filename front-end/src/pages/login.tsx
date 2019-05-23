import React from "react";
import "./App.css";
import { Button } from "reactstrap";

class Login extends React.Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          Press the button to log in.
          <Button onClick={() => {}} size="lg" color="success" outline block>
            Login
          </Button>
        </header>
      </div>
    );
  }
}

export default Login;
