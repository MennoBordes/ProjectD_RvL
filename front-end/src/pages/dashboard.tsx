import React from "react";
import "../style/dashboard.css";
import {
  Button,
  Row,
  Col,
  Nav,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  Collapse,
  NavItem,
  NavLink,
  Card,
  CardBody,
  CardTitle,
  CardSubtitle,
  CardText,
  CardColumns
} from "reactstrap";

interface props {}

interface state {
  isOpen: boolean;
  role: number;
}

class Dashboard extends React.Component<props, state> {
  organizations = [
    "Openbaar Ministerie",
    "Politie",
    "Gemeente",
    "Reclassering"
  ];

  constructor(props: any) {
    super(props);
    this.state = {
      isOpen: false,
      role: 1
    };
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

  getAvailableDocuments() {
    //below is for testing
    let list = Array(100);
    list.fill(1,0)
    console.log(list);
    return(
        list.map((content, index) => {
          return this.displayDocument("titel", "ondertitel")
        })
    )
  }

  displayDocument(title: string, subTitle: string) {
    return (
      <Card xs={{size: 12}} outline color="success">
        <CardBody>
          <CardTitle>{title}</CardTitle>
          <CardSubtitle>{subTitle}</CardSubtitle>
          <Button color="success" outline>display</Button>
        </CardBody>
      </Card>
    );
  }

  displayNavbar() {
    return (
      <Navbar color="light" light expand="md">
        <NavbarBrand href="/">
          Logged in as: {this.organizations[this.state.role]}
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
