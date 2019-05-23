import React from 'react';
import './App.css';
// import Button from 'reactstrap';
import {Button, Alert} from 'reactstrap';

const App: React.FC = () => {
  return (
    <div className="App">
      <header className="App-header">
        Press the button to log in.
        <Button onClick={() =>{}} size="lg" color="success" outline block>
          Login
        </Button>
      </header>
      
    </div>
  );
}

export default App;
