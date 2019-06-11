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

    

  constructor(props: any){
    super(props);
    this.state = this.props.location.state
    this.state = {...this.state,       
      dropdownOpen: false,
      selected: "kies uw organisatie"
    }
    this.toggle = this.toggle.bind(this);
    
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
    this.setState((prevState) => ({
      dropdownOpen: !prevState.dropdownOpen,
    }));
  }

  DisplayDropdown() {
    return (
      <Dropdown block isOpen={this.state.dropdownOpen} toggle={this.toggle}>
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
              {this.DisplayDropdown()}
            </Row>
            <Row>
              <Col>
              {this.state.selected == "OM" ?  //OM
               <>
                <Input placeholder="Antecedenten_ZSM" name="Antecedenten_ZSM" />
                <Input placeholder="Sepots_ZSM" name="Sepots_ZSM" />
                <Input placeholder="Antecedenten_Radicalen" name="Antecedenten_Radicalen" />
                <Input placeholder="Sepots_Radicalen" name="Sepots_Radicalen" />
                <Input placeholder="OnderzoekRad_Radicalen" name="OnderzoekRad_Radicalen" />
                <Input placeholder="Antecedenten_LokalePGA" name="Antecedenten_LokalePGA" />
                <Input placeholder="LopendeDossiers_Detentie" name="LopendeDossiers_Detentie" />
              </>: 
                this.state.selected == "Politie" ? //Politie
                 <>
                    <Input placeholder="Antecedenten_Radicalen" name="Antecedenten_Radicalen" />
                    <Input placeholder="Antecedenten_LokalePGA" name="Antecedenten_LokalePGA" />
                    <Input placeholder="Antecedenten_ZSM" name="Antecedenten_ZSM" />
                    <Input placeholder="Antecedenten_Detentie" name="Antecedenten_Detentie" />
                    <Input placeholder="Aanhoudingen_Radicalen" name="Aanhoudingen_Radicalen" />
                    <Input placeholder="Aanhoudingen_Detentie" name="Aanhoudingen_Detentie" />
                    <Input placeholder="Aanhoudingen_ZSM" name="Aanhoudingen_ZSM" />
                    <Input placeholder="ISDMaatregel_ZSM" name="ISDMaatregel_ZSM" />
                    <Input placeholder="ISDMaatregel_Radicalen" name="ISDMaatregel_Radicalen" />
                </>: 
                this.state.selected == "Gemeente" ?  // Gemeente
                 <>
                  <Input placeholder="BezitUitkering_ZSM" name="BezitUitkering_ZSM" />
                  <Input placeholder="MeldingenRad_Radicalen" name="MeldingenRad_Radicalen" />
                  <Input placeholder="BezitUitkering_LokalePGA" name="BezitUitkering_LokalePGA" />
                  <Input placeholder="ZitInGroepsAanpak_LokalePGA" name="ZitInGroepsAanpak_LokalePGA" />
                  <Input placeholder="BezitUitkering_Detentie" name="BezitUitkering_Detentie" />
                  <Input placeholder="IdBewijs_Detentie" name="IdBewijs_Detentie" />

                </>:
                this.state.selected == "Reclassering" ? //reclassering
                 <> 
                  <Input placeholder="LopendTraject_ZSM" name="LopendTraject_ZSM" />
                  <Input placeholder="LaatsteGesprek_ZSM" name="LaatsteGesprek_ZSM" />
                  <Input placeholder="LopendTraject_Radicalen" name="LopendTraject_Radicalen" />
                  <Input placeholder="LaatsteGesprek_Radicalen" name="LaatsteGesprek_Radicalen" />
                  <Input placeholder="LopendTraject_Detentie" name="LopendTraject_Detentie" />
                  <Input placeholder="LaatsteGesprek_Detentie" name="LaatsteGesprek_Detentie" />
                </>: <></>
              }
              {this.state.role !== "kies uw organisatie" ?  <Button>Add</Button> :<></>}
              </Col>
              </Row>
        }
        </header>
    );
  }
}

export default AddDocument;
