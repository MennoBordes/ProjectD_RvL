import React from 'react';
import './style/App.css';
// import Button from 'reactstrap';

import { Route, Switch } from "react-router";
import { BrowserRouter } from "react-router-dom";
import Dashboard from './pages/dashboard'
import Login from './pages/login';

const App: React.FC = () => {
  return (
    <div className="App">
      <BrowserRouter>
        <Switch>
          <Route exact path="/" component={Login}/>
          <Route exact path="/login" component={Login}/>
          <Route exact path="/dashboard" component={Dashboard}/>
        </Switch>
      </BrowserRouter>
    </div>
  );
}

export default App;
