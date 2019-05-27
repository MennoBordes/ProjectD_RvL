import React from "react";
import "../style/App.css";
import { Button, Row, Col, Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from "reactstrap";

interface props {

}

interface state {
  dropdownOpen : boolean,
  selected:string
}

class Login extends React.Component<props, state> {


  organizations = [
    "Openbaar Ministerie",
    "Politie",
    "Gemeente",
    "Reclassering"
  ]

  constructor(props: any){
    super(props);
    this.toggle = this.toggle.bind(this);
    this.state = {
      dropdownOpen: false,
      selected: "kies uw organisatie"

    }
  }

  toggle() {
    this.setState(prevState => ({
      dropdownOpen: !prevState.dropdownOpen,
    }));
  }

  changeOrg(org: string) {
    this.setState({selected: org})
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

          <Row>
            <Col>Press the button to log in.</Col>
          </Row>
          <hr />
          <Row>
            <Col sm={{size: 12}} >
            {this.DisplayDropdown()}
            </Col>
          </Row>
          <hr />

          <Row>
            <Col sm={{size:12}}>
              <Button onClick={() => {}}  size="lg" color="success" outline block>
                  Login
              </Button>
            </Col>
          </Row>
        </header>
    );
  }
}

export default Login;
