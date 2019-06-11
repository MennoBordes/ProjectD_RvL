import React from "react";
import "../style/dashboard.css";
import {  Link } from "react-router-dom";
import {
  Button,
  Row,
  Col,
  Nav,
  Navbar,
  NavbarBrand,
  Collapse,
  NavItem,
  NavLink,
  Card,
  CardBody,
  CardTitle,
  CardSubtitle,
  CardColumns
} from "reactstrap";

interface props {
  match : any
}

interface state {
  isOpen: boolean;
  role: string;
  data: any;
}

type doc = {
  Antecedenten_Radicalen_OGR: string
  Antecedenten_LokalePGA_OGR: string
  Antecedenten_ZSM_OGR: string
  Antecedenten_Detentie: string
  Naam: string
  BSN: string
  Geb_datum: string
}

class Dashboard extends React.Component<props, state> {
  organizations = [
    "OM",
    "Politie",
    "Gemeente",
    "Reclassering"
  ];

  constructor(props: any) {
    super(props);
    this.state = {
      isOpen: false,
      role: this.props.match.params.id,
      data: null
    };
    
    this.getDocuments()
  }

  render() {
    return (
      <div className="App">
        {this.displayNavbar()}
        <header className="App-header">
          <Row className="cards">
            <Col sm={{size:10, offset: 1}} xs={{size:12}}>
              <CardColumns>
                
                {/* {this.displayDocument("title", "onderTitel")} */}
                {this.getAvailableDocuments()}
              </CardColumns>
            </Col>
          </Row>
        </header>
      </div>
    );
  }


  getPort () {
    switch(this.state.role){
      case "OM": return 4001
      case "Politie": return 4001
      case "Gemeente": return 4003  
      case "Reclassering": return 4004  
    }
  }

  getDocuments() {
    console.log("getDocuments was called");
    fetch(`http://localhost:${this.getPort()}/api/data/getdecryptednode`)
      .then(res => res.json())
      .then(result => {
        console.log(result);
        this.setState({ data: result })})

  }

  getAvailableDocuments() {
    console.log(this.state.data);
    if(this.state.data == null) return <></>
    return(
        this.state.data.node.CHAIN_COPY.map((content : any) => {
          return this.displayDocument(content.data[this.state.role], content.created_by)
        })
    )
  }

  displayDocument(data : doc, created_by : string) {
    return (
      <Card xs={{size: 12}} outline color="success">
        <CardBody>
          <CardTitle>{data.Naam}</CardTitle>
          <CardSubtitle>{created_by}</CardSubtitle>
          <Link to={{
            pathname: '/document',
            state: {
              block: data
            }
          }}>
          <Button color="success" outline>display</Button>
          </Link>
        </CardBody>
      </Card>
    );
  }

  displayNavbar() {
    return (
      <Navbar color="light" light expand="md">
        <NavbarBrand href="/">
          Logged in as: {this.state.role}
        </NavbarBrand>
        {/* <NavbarToggler onClick={this.toggle} /> */}
        <Collapse isOpen={this.state.isOpen} navbar>
          <Nav className="ml-auto" navbar>
            <NavItem>
              <NavLink href="/components/">Components</NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="https://github.com/reactstrap/reactstrap">
                log out
              </NavLink>
            </NavItem>
          </Nav>
        </Collapse>
      </Navbar>
    );
  }
}

export default Dashboard;
