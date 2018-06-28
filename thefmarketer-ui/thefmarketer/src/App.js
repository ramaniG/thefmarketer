import React from 'react';
import { connect } from 'react-redux';
import { ConnectedRouter, push } from 'react-router-redux'
import { history } from './_helpers';
import { alertActions } from './_actions';
import { LoginPage } from './login';
import { HomePage } from './home';
import { PrivateRoute } from './_components';
import { Route } from 'react-router';
import 'bootstrap';

class App extends React.Component {
    constructor(props) {
        super(props);
        const { dispatch } = this.props;
        // this line is required to work on plunker because the app preview runs on a subfolder url
        dispatch(push('/'));

        history.listen((location, action) => {
            // clear alert on location change
            dispatch(alertActions.clear());
            console.log(location);
            console.log(action);
            
        });
    }

    render() {
        const { user } = this.props;
        var isUser = (user) ? ((user.userType == 'User') ? true : false) : true;
        return (
          <ConnectedRouter history={history}>
            <div className={(isUser) ? 'container background-red' : 'container background-blue'}>
              <Route path="/login" component={LoginPage}/>
              <PrivateRoute exact path="/" component={HomePage}/>
            </div>
          </ConnectedRouter>
        );
    }
}

function mapStateToProps(state) {
    const { alert, auth } = state;
    const { user } = auth;
    return {
        alert, user
    };
}

const connectedApp = connect(mapStateToProps)(App);
export { connectedApp as App };
