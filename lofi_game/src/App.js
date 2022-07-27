import React, {Component} from "react";
import PrivateRoute from './PrivateRoute';
import Login from './component/Login';
import { API_AUTH } from './constants';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';

class App extends Component {
  state = {
    loggedIn : false,
    token : null
  }

  login = (d) => {
    fetch(API_AUTH, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(d)
    })
    .then(res => {
      if (res.status === 400) {
          throw new Error('There was an error');
      }
      return res.json();
    })
    .then(json => {
      if(json.token === undefined) return;
      localStorage.setItem('token', json.token);
      this.setState({
        username: json.user.username,
        loggedIn: true,
        token: json.token
      });
    })
    .catch(ex => {
      console.log(ex);
    });
  }

  render() {
    return (
      <Router>
          <Switch>
            <Route path="/Login">
              <Login isLoggedIn={this.state.loggedIn} login={this.login}/>
            </Route>
            <PrivateRoute path="/" isLoggedIn={this.state.loggedIn} token={this.state.token} />
          </Switch>
      </Router>
    );
  }
}

export default App;