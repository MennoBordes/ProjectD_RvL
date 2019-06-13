import React, { FormEvent } from "react";
import "../style/App.css";
import { Button, Row, Col, Dropdown, Input, DropdownToggle, DropdownMenu, DropdownItem } from "reactstrap";
import { Location, History } from "history";
import { Link } from "react-router-dom";
import {PoliceType, GemeenteType, OMType, ReclasseringType} from '../types';



interface props {
  // block: doc
  location : Location
  history : History

}

interface state {
    role : string
    dropdownOpen : boolean
    WhoAmI : string
    inputData : any
}


class AddDocument extends React.Component<props, state> {

    inputData :any = {};

  constructor(props: any){
    super(props);
    this.state = this.props.location.state
    this.state = {...this.state,       
      dropdownOpen: false,
      WhoAmI: "kies uw organisatie",
      inputData : {
        Naam : "",
        BSN: "",
      }
    }
    this.toggle = this.toggle.bind(this);
    this.handleChange = this.handleChange.bind(this);
    this.uploadDocument = this.uploadDocument.bind(this);
  }

  organizations = [
    "OM",
    "Politie",
    "Gemeente",
    "Reclassering"
  ];



  uploadDocument() {
    console.log(this.state);
    let data = this.state.inputData;
    // data.WhoAmI = this.state.WhoAmI;
    
    let newdata = {
      Politie : data,
      Reclassering : data,
      Gemeente : data,
      OM : data
    }
    let toSend = {
      newdata : newdata
    }
    console.log(JSON.stringify({newdata}));
    console.log("uploadDocument was called");
    console.log(data);
    fetch(`http://localhost:5005/api/data/client`,{
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(toSend)
    })
      .then(res => res.json())
      .then(result => {
        console.log(result);
      }).catch(er => {console.log(er)});

  }



  changeOrg(org: string) {
    this.setState({WhoAmI: org})

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
          {this.state.WhoAmI}
        </DropdownToggle>
        <DropdownMenu>
          
          {this.organizations.map(val => {return (
            <DropdownItem onClick={() => this.changeOrg(val)}> {val}</DropdownItem>
          )})}

        </DropdownMenu>
      </Dropdown>
    )
  }

  handleChange(event : React.ChangeEvent<HTMLInputElement>) {
    console.log(event.target.value);
    let curData = this.state.inputData;
    curData[event.target.name] = event.target.value;
    this.setState({...this.state, inputData : curData});
    // this.setState({...this.state, Pthis.state.inputData[event.target.name] : event.target.value})
    // this.inputData[event.target.name] = event.target.value;
  }

  render() {
    return (
        <header className="App-header">
            <Row className="">
                <Input placeholder="Naam" name="Naam"onChange={this.handleChange} />
                <Input placeholder="BSN" name="BSN" onChange={this.handleChange}/>
                <Input placeholder="Date of birth" name="Birth_Date" onChange={this.handleChange} />
            </Row>
            <Row>
              {this.DisplayDropdown()}
            </Row>
            <Row>
              <Col>
              {this.state.WhoAmI == "OM" ?  //OM
               <>
                <Input placeholder="Antecedenten_ZSM" name="Antecedenten_ZSM" onChange={this.handleChange} />
                <Input placeholder="Sepots_ZSM" name="Sepots_ZSM" onChange={this.handleChange} />
                <Input placeholder="Antecedenten_Radicalen" name="Antecedenten_Radicalen" onChange={this.handleChange} />
                <Input placeholder="Sepots_Radicalen" name="Sepots_Radicalen" onChange={this.handleChange} />
                <Input placeholder="OnderzoekRad_Radicalen" name="OnderzoekRad_Radicalen" onChange={this.handleChange} />
                <Input placeholder="Antecedenten_LokalePGA" name="Antecedenten_LokalePGA" onChange={this.handleChange} />
                <Input placeholder="LopendeDossiers_Detentie" name="LopendeDossiers_Detentie" onChange={this.handleChange} />
              </>: 
                this.state.WhoAmI == "Politie" ? //Politie
                 <>
                    <Input placeholder="Antecedenten_Radicalen" name="Antecedenten_Radicalen" onChange={this.handleChange} />
                    <Input placeholder="Antecedenten_LokalePGA" name="Antecedenten_LokalePGA" onChange={this.handleChange} />
                    <Input placeholder="Antecedenten_ZSM" name="Antecedenten_ZSM" onChange={this.handleChange} />
                    <Input placeholder="Antecedenten_Detentie" name="Antecedenten_Detentie" onChange={this.handleChange} />
                    <Input placeholder="Aanhoudingen_Radicalen" name="Aanhoudingen_Radicalen" onChange={this.handleChange} />
                    <Input placeholder="Aanhoudingen_Detentie" name="Aanhoudingen_Detentie" onChange={this.handleChange} />
                    <Input placeholder="Aanhoudingen_ZSM" name="Aanhoudingen_ZSM" onChange={this.handleChange} />
                    <Input placeholder="ISDMaatregel_ZSM" name="ISDMaatregel_ZSM" onChange={this.handleChange} />
                    <Input placeholder="ISDMaatregel_Radicalen" name="ISDMaatregel_Radicalen" onChange={this.handleChange} />
                </>: 
                this.state.WhoAmI == "Gemeente" ?  // Gemeente
                 <>
                  <Input placeholder="BezitUitkering_ZSM" name="BezitUitkering_ZSM" onChange={this.handleChange} />
                  <Input placeholder="MeldingenRad_Radicalen" name="MeldingenRad_Radicalen" onChange={this.handleChange} />
                  <Input placeholder="BezitUitkering_LokalePGA" name="BezitUitkering_LokalePGA" onChange={this.handleChange} />
                  <Input placeholder="ZitInGroepsAanpak_LokalePGA" name="ZitInGroepsAanpak_LokalePGA" onChange={this.handleChange} />
                  <Input placeholder="BezitUitkering_Detentie" name="BezitUitkering_Detentie" onChange={this.handleChange} />
                  <Input placeholder="IdBewijs_Detentie" name="IdBewijs_Detentie" onChange={this.handleChange} />

                </>:
                this.state.WhoAmI == "Reclassering" ? //reclassering
                 <> 
                  <Input placeholder="LopendTraject_ZSM" name="LopendTraject_ZSM" onChange={this.handleChange} />
                  <Input placeholder="LaatsteGesprek_ZSM" name="LaatsteGesprek_ZSM" onChange={this.handleChange} />
                  <Input placeholder="LopendTraject_Radicalen" name="LopendTraject_Radicalen" onChange={this.handleChange} />
                  <Input placeholder="LaatsteGesprek_Radicalen" name="LaatsteGesprek_Radicalen" onChange={this.handleChange} />
                  <Input placeholder="LopendTraject_Detentie" name="LopendTraject_Detentie" onChange={this.handleChange} />
                  <Input placeholder="LaatsteGesprek_Detentie" name="LaatsteGesprek_Detentie" onChange={this.handleChange} />
                </>: <></>
              }
              {this.state.role !== "kies uw organisatie" ?  <Button onClick={this.uploadDocument}>Add</Button> :<></>}
              </Col>
              </Row>
        }
        </header>
    );
  }
}

export default AddDocument;
