import React from 'react';
import { connect } from 'react-redux';
import { ConnectedRouter, push } from 'react-router-redux'
import { history } from './_helpers';
import { alertActions } from './_actions';
import { LoginPage } from './login';
import { HomePage } from './home';
import { PrivateRoute } from './_components';
import { Route } from 'react-router';

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
        return (
          <ConnectedRouter history={history}>
            <div>
              <PrivateRoute exact path="/" component={HomePage}/>
              <Route path="/login" component={LoginPage}/>
            </div>
          </ConnectedRouter>
        );
    }
}

function mapStateToProps(state) {
    const { alert } = state;
    return {
        alert
    };
}

const connectedApp = connect(mapStateToProps)(App);
export { connectedApp as App };
