import React from "react";
import "../style/App.css";
import { Button, Row, Col, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from "reactstrap";
import { Location, History } from "history";
import { Link } from "react-router-dom";
import {PoliceType, GemeenteType, OMType, ReclasseringType} from '../types';


type doc = PoliceType | GemeenteType | OMType | ReclasseringType

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
          <p style={{color: 'white'}}>Geboorte datum: {this.state.block.Geb_Datum}</p>
          <hr style={{color: 'white'}}/>

          {
            this.state.block.WhoAmI === "Gemeente" ? 
            <>
            <p style={{color: 'white'}}>BezitUitkering_Detentie: {(this.state.block.BezitUitkering_Detentie == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>BezitUitkering_LokalePGA: {(this.state.block.BezitUitkering_LokalePGA == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>BezitUitkering_ZSM : {(this.state.block.BezitUitkering_ZSM == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>IdBewijs_Detentie : {this.state.block.IdBewijs_Detentie}</p>
            <p style={{color: 'white'}}>MeldingenRad_Radicalen : {this.state.block.MeldingenRad_Radicalen}</p>
            <p style={{color: 'white'}}>ZitInGroepsAanpak_LokalePGA : {this.state.block.ZitInGroepsAanpak_LokalePGA}</p>
            </> : 
            this.state.block.WhoAmI === "OM" ?
            <>
            <p style={{color: 'white'}}>Antecedenten Radicalen OGR: {this.state.block.Antecedenten_LokalePGA}</p>
            <p style={{color: 'white'}}>Antecedenten Lokale PGA OGR: {this.state.block.Antecedenten_Radicalen}</p>
            <p style={{color: 'white'}}>Antecedenten_ZSM : {this.state.block.Antecedenten_ZSM}</p>
            <p style={{color: 'white'}}>LopendeDossiers_Detentie : {this.state.block.LopendeDossiers_Detentie}</p>
            <p style={{color: 'white'}}>OnderzoekRad_Radicalen : {this.state.block.OnderzoekRad_Radicalen}</p>
            <p style={{color: 'white'}}>Sepots_Radicalen : {this.state.block.Sepots_Radicalen}</p>
            <p style={{color: 'white'}}>Sepots_ZSM : {this.state.block.Sepots_ZSM}</p>
            </>
            :
            this.state.block.WhoAmI === "Politie" ?
            <>
            <p style={{color: 'white'}}>Antecedenten Radicalen OGR: {(this.state.block.Aanhoudingen_Detentie == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>Antecedenten Lokale PGA OGR: {(this.state.block.Aanhoudingen_Radicalen == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>Aanhoudingen_ZSM : {(this.state.block.Aanhoudingen_ZSM == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>Antecedenten_Detentie : {this.state.block.Antecedenten_Detentie}</p>
            <p style={{color: 'white'}}>Antecedenten_LokalePGA : {this.state.block.Antecedenten_LokalePGA}</p>
            <p style={{color: 'white'}}>Antecedenten_Radicalen : {this.state.block.Antecedenten_Radicalen}</p>
            <p style={{color: 'white'}}>Antecedenten_ZSM : {this.state.block.Antecedenten_ZSM}</p>
            <p style={{color: 'white'}}>ISDMaatregel_Radicalen : {this.state.block.ISDMaatregel_Radicalen}</p>
            <p style={{color: 'white'}}>ISDMaatregel_ZSM : {this.state.block.ISDMaatregel_ZSM}</p>

            </>:
            this.state.block.WhoAmI === "Reclassering" ?
            <>
            <p style={{color: 'white'}}>Antecedenten Radicalen OGR: {(this.state.block.LaatsteGesprek_Detentie == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>Antecedenten Lokale PGA OGR: {(this.state.block.LaatsteGesprek_Radicalen == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>LaatsteGesprek_ZSM : {(this.state.block.LaatsteGesprek_ZSM== 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>LopendTraject_Detentie : {this.state.block.LopendTraject_Detentie}</p>
            <p style={{color: 'white'}}>LopendTraject_Radicalen : {this.state.block.LopendTraject_Radicalen}</p>
            <p style={{color: 'white'}}>LopendTraject_ZSM : {this.state.block.LopendTraject_ZSM}</p>
            </>
            :<></>
          }
            {/* <p style={{color: 'white'}}>Antecedenten Radicalen OGR: {(this.state.block.Antecedenten_Radicalen_OGR == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>Antecedenten Lokale PGA OGR: {(this.state.block.Antecedenten_LokalePGA_OGR == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>Antecedenten Detentie: {(this.state.block.Antecedenten_Detentie == 'True') ? 'ja' : 'nee'}</p>
            <p style={{color: 'white'}}>Antecedenten Detentie: {(this.state.block.Antecedenten_Detentie == 'True') ? 'ja' : 'nee'}</p> */}



        </div>
            :<></>
      }
        <Button onClick={this.props.history.goBack} >Terug</Button>
      
        </header>
    );
  }
}

export default DocumentDisplay;
