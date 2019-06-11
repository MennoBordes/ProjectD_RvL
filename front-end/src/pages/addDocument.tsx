import React from "react";
import "../style/App.css";
import { Button, Row, Col, Dropdown, Input, DropdownToggle, DropdownMenu, DropdownItem } from "reactstrap";
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
    dropdownOpen : boolean
    selected : string
}

class AddDocument extends React.Component<props, state> {

    selectedInput = -1;

  constructor(props: any){
    super(props);
    this.state = this.props.location.state
    this.state = {...this.state,       
      dropdownOpen: false,
      selected: "kies uw organisatie"
    }
    
  }

  organizations = [
    "OM",
    "Politie",
    "Gemeente",
    "Reclassering"
  ];


  changeOrg(org: string) {
    this.setState({selected: org})
  }
  toggle() {
    this.setState(prevState => ({
      dropdownOpen: !prevState.dropdownOpen,
    }));
  }

  DisplayDropdown() {
    return (
      <Dropdown sm={{size:12}} block isOpen={this.state.dropdownOpen} toggle={this.toggle}>
        <DropdownToggle caret>
          {this.state.selected}
        </DropdownToggle>
        <DropdownMenu>
          
          {this.organizations.map(val => {return (
            <DropdownItem onClick={() => this.changeOrg(val)}> {val}</DropdownItem>
          )})}

        </DropdownMenu>
      </Dropdown>
    )
  }

  render() {
    return (
        <header className="App-header">
            <Row className="">
                <Input placeholder="Name" />
                <Input placeholder="BSN" />
                <Input placeholder="Date of birth" />
            </Row>
            <Row>


            {this.selectedInput == 1 ? 
            <>
            
            </> : 
              this.selectedInput == 2 ? <>2</> : 
              this.selectedInput == 3 ? <>3</> :
              this.selectedInput == 4 ? <>4</> : <></>
            }
            </Row>

        }
        </header>
    );
  }
}

export default AddDocument;
