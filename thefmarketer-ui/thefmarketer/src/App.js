import React from 'react';
import { Route } from 'react-router';
import { connect } from 'react-redux';
import { ConnectedRouter, push } from 'react-router-redux'
import { history } from './_helpers';
import { alertActions } from './_actions';
import { PrivateRoute } from './_components';
import { LoginPage } from './login';
import { HomePage } from './home';

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
