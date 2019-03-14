import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Home from '../pages/home.js';

export class CustomRouter extends Component {

    render() {
        return (
            <Router >
                <Switch>
                    <Route exact path='/' component={Home}></Route>
                </Switch>
            </Router>            
        );
    }
}