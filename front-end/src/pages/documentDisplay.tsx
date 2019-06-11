import React from "react";
import "../style/App.css";
import { Button, Row, Col, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from "reactstrap";
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
  block: doc | null
}

class DocumentDisplay extends React.Component<props, state> {

  constructor(props: any){
    super(props);
    this.state = this.props.location.state

    
    
  }


  render() {
    return (
        <header className="App-header">
        {this.state.block !== null ? 
        <div style={{textAlign: "left"}}>
            <p style={{color: 'white'}}>Naam: {this.state.block.Naam}</p>
            <p style={{color: 'white'}}>Bsn: {this.state.block.BSN}</p>
            <p style={{color: 'white'}}>Geboorte datum: {this.state.block.Geb_datum}</p>
            <hr style={{color: 'white'}}/>
            <p style={{color: 'white'}}>Antecedenten Radicalen OGR: {(this.state.block.Antecedenten_Radicalen_OGR == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>Antecedenten Lokale PGA OGR: {(this.state.block.Antecedenten_LokalePGA_OGR == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>Antecedenten Detentie: {(this.state.block.Antecedenten_Detentie == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>Antecedenten Detentie: {(this.state.block.Antecedenten_Detentie == 'True') ? 'ja' : 'nee'}</p>
        </div>
            :<></>
      }
        <Button onClick={this.props.history.goBack} >Terug</Button>
      
        </header>
    );
  }
}

export default DocumentDisplay;
