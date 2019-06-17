import React, { FormEvent } from "react";
import "../style/App.css";
import { Button, Row, Col,  Input } from "reactstrap";
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

interface InputData { 
  Naam : string,
  BSN : string,
  Birth_Date : string,
  Politie : PoliceType,
  Gemeente: GemeenteType,
  OM: OMType,
  Reclassering : ReclasseringType
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
        Politie:{},
        OM:{},
        Gemeente:{},
        Reclassering: {}
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
    let OM = data.OM;
    let Politie = data.Politie;
    let Reclassering = data.Reclassering;
    let Gemeente = data.Gemeente;
    OM.Naam = data.Naam;
    OM.BSN = data.BSN;
    OM.Birth_Date = data.Birth_Date;
    OM.WhoAmI = "OM";
    Politie.Naam = data.Naam;
    Politie.BSN = data.BSN;
    Politie.Birth_Date = data.Birth_Date;
    Politie.WhoAmI = "Politie";
    Reclassering.Naam = data.Naam;
    Reclassering.BSN = data.BSN;
    Reclassering.Birth_Date = data.Birth_Date;
    Reclassering.WhoAmI = "Reclassering";
    Gemeente.Naam = data.Naam;
    Gemeente.BSN = data.BSN;
    Gemeente.Birth_Date = data.Birth_Date;
    Gemeente.WhoAmI = "Gemeente";
    let newdata = {
      OM: OM,
      Politie: Politie,
      Reclassering: Reclassering,
      Gemeente: Gemeente     
    }

    console.log(newdata);
    console.log(JSON.stringify({newdata}));
    console.log("uploadDocument was called");
    console.log(data);
    fetch(`http://localhost:5005/api/data/client`,{
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({newdata})
    })
      .then(res => res.json())
      .then(result => {
        console.log(result);
        alert('Data opslag succesvol.')
        this.props.history.push('/');
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



  handleChange(event : React.ChangeEvent<HTMLInputElement>) {
    console.log(event.target);
    let curData = this.state.inputData;
    if(!(event.target.name=="Naam" || event.target.name=="BSN" || event.target.name=="Birth_Date")){
      let organisation = event.target.name.split("/")[0];
      curData[organisation][event.target.name.split("/")[1]] = event.target.value;
    }else{
      curData[event.target.name] = event.target.value;
    }
    this.setState({...this.state, inputData : curData});
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
            </Row>
            <Row style={{color:'white'}}>
              <Col>
               <> "OM" </>
               <>
                <Input placeholder="Antecedenten_ZSM" name="OM/Antecedenten_ZSM" onChange={this.handleChange} />
                <Input placeholder="Sepots_ZSM" name="OM/Sepots_ZSM" onChange={this.handleChange} />
                <Input placeholder="Antecedenten_Radicalen" name="OM/Antecedenten_Radicalen" onChange={this.handleChange} />
                <Input placeholder="Sepots_Radicalen" name="OM/Sepots_Radicalen" onChange={this.handleChange} />
                <Input placeholder="OnderzoekRad_Radicalen" name="OM/OnderzoekRad_Radicalen" onChange={this.handleChange} />
                <Input placeholder="Antecedenten_LokalePGA" name="OM/Antecedenten_LokalePGA" onChange={this.handleChange} />
                <Input placeholder="LopendeDossiers_Detentie" name="OM/LopendeDossiers_Detentie" onChange={this.handleChange} />
              </>
                 <>"Politie"</>
                 <>
                    <Input placeholder="Antecedenten_Radicalen" name="Politie/Antecedenten_Radicalen" onChange={this.handleChange} />
                    <Input placeholder="Antecedenten_LokalePGA" name="Politie/Antecedenten_LokalePGA" onChange={this.handleChange} />
                    <Input placeholder="Antecedenten_ZSM" name="Politie/Antecedenten_ZSM" onChange={this.handleChange} />
                    <Input placeholder="Antecedenten_Detentie" name="Politie/Antecedenten_Detentie" onChange={this.handleChange} />
                    <Input placeholder="Aanhoudingen_Radicalen" name="Politie/Aanhoudingen_Radicalen" onChange={this.handleChange} />
                    <Input placeholder="Aanhoudingen_Detentie" name="Politie/Aanhoudingen_Detentie" onChange={this.handleChange} />
                    <Input placeholder="Aanhoudingen_ZSM" name="Politie/Aanhoudingen_ZSM" onChange={this.handleChange} />
                    <Input placeholder="ISDMaatregel_ZSM" name="Politie/ISDMaatregel_ZSM" onChange={this.handleChange} />
                    <Input placeholder="ISDMaatregel_Radicalen" name="Politie/ISDMaatregel_Radicalen" onChange={this.handleChange} />
                </>
                 <> "Gemeente" </>
                 <>
                  <Input placeholder="BezitUitkering_ZSM" name="Gemeente/BezitUitkering_ZSM" onChange={this.handleChange} />
                  <Input placeholder="MeldingenRad_Radicalen" name="Gemeente/MeldingenRad_Radicalen" onChange={this.handleChange} />
                  <Input placeholder="BezitUitkering_LokalePGA" name="Gemeente/BezitUitkering_LokalePGA" onChange={this.handleChange} />
                  <Input placeholder="ZitInGroepsAanpak_LokalePGA" name="Gemeente/ZitInGroepsAanpak_LokalePGA" onChange={this.handleChange} />
                  <Input placeholder="BezitUitkering_Detentie" name="Gemeente/BezitUitkering_Detentie" onChange={this.handleChange} />
                  <Input placeholder="IdBewijs_Detentie" name="Gemeente/IdBewijs_Detentie" onChange={this.handleChange} />

                </>
                 <> "Reclassering"</>
                 <> 
                  <Input placeholder="LopendTraject_ZSM" name="Reclassering/LopendTraject_ZSM" onChange={this.handleChange} />
                  <Input placeholder="LaatsteGesprek_ZSM" name="Reclassering/LaatsteGesprek_ZSM" onChange={this.handleChange} />
                  <Input placeholder="LopendTraject_Radicalen" name="Reclassering/LopendTraject_Radicalen" onChange={this.handleChange} />
                  <Input placeholder="LaatsteGesprek_Radicalen" name="Reclassering/LaatsteGesprek_Radicalen" onChange={this.handleChange} />
                  <Input placeholder="LopendTraject_Detentie" name="Reclassering/LopendTraject_Detentie" onChange={this.handleChange} />
                  <Input placeholder="LaatsteGesprek_Detentie" name="Reclassering/LaatsteGesprek_Detentie" onChange={this.handleChange} />
                </>
              
              {this.state.role !== "kies uw organisatie" ?  <Button onClick={this.uploadDocument}>Add</Button> :<></>}
              </Col>
              </Row>
        }
        </header>
    );
  }
}

export default AddDocument;
