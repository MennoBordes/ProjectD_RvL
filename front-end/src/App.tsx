import React from 'react';
import './style/App.css';
// import Button from 'reactstrap';

import { Route, Switch } from "react-router";
import { BrowserRouter } from "react-router-dom";
import Dashboard from './pages/dashboard'
import Login from './pages/login';
import DocumentDisplay from './pages/documentDisplay';
import AddDocument from './pages/addDocument';

const organizations = [
  "Openbaar Ministerie",
  "Politie",
  "Gemeente",
  "Reclassering"
]

type doc = {
  Antecedenten_Radicalen_OGR: string
  Antecedenten_LokalePGA_OGR: string
  Antecedenten_ZSM_OGR: string
  Antecedenten_Detentie: string
  Naam: string
  BSN: string
  Geb_datum: string
}


let currentOrg = null;


const App: React.FC = () => {


  const setOrganization : any = (id : string) => {
    currentOrg = id
  }

  return (
    <div className="App">
      <BrowserRouter>
        <Switch>
          <Route exact path="/" component={Login}/>
          <Route exact path="/login" render={(props) => <Login setOrg={setOrganization} {...props} />}  />
          <Route exact path="/dashboard/:id" render={(props) => <Dashboard {...props}  />} />
          <Route exact path="/document" component={DocumentDisplay} />
          <Route exact path="/add" component={AddDocument} />
        </Switch>
      </BrowserRouter>
    </div>
  );
}


export default App;