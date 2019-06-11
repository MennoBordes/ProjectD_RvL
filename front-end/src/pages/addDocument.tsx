import React from "react";
import "../style/App.css";
import { Button, Row, Col, Dropdown, Input } from "reactstrap";
import { Location, History } from "history";
import { Link } from "react-router-dom";


type doc = {
  Antecedenten_Radicalen_OGR: string
  Antecedenten_LokalePGA_OGR: string
  Antecedenten_ZSM_OGR: string
  Antecedenten_Detentie: string
  Naam: string
  BSN: string
  Geb_datum: string
}

interface props {
  // block: doc
  location : Location
  history : History

}

interface state {
    role : string
}

class AddDocument extends React.Component<props, state> {

    selectedInput = -1;

  constructor(props: any){
    super(props);
    this.state = this.props.location.state
    
    
  }


  render() {
    return (
        <header className="App-header">
            <Row className="">
                <Input placeholder="Name" />
                <Input placeholder="BSN" />
                <Input placeholder="Date of birth" />
            </Row>
            


            {this.selectedInput == 1 ? <>1</> : 
            this.selectedInput == 2 ? <>2</> : 
            this.selectedInput == 3 ? <>3</> :
            this.selectedInput == 4 ? <>4</> : <></>
        }
        </header>
    );
  }
}

export default AddDocument;
