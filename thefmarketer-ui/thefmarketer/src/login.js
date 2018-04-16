import React from 'react';
import { connect } from 'react-redux';
import { userActions } from './_actions';

class LoginPage extends React.Component {
    constructor(props) {
        super(props);
        const { dispatch } = this.props;

        // reset login status
        dispatch(userActions.logout());

        this.state = {
            email: '',
            password: '',
            submitted: false
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(e) {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    }

    handleSubmit(e) {
        e.preventDefault();

        this.setState({ submitted: true });
        const { email, password } = this.state;
        const { dispatch } = this.props;
        if (email && password) {
            dispatch(userActions.login(email, password));
        }
    }

    render() {
        const { loggingIn } = this.props;
        const { email, password, submitted } = this.state;
        return (
          <div class="main">
            <h3>Sign In</h3>
            <button type="submit" class="btn-block btn btn-primary">Facebook</button>
            <form onSubmit={this.handleSubmit}>
              <div class="login-or">
                <hr class="hr-or" />
                <span class="span-or">or</span>
              </div>
              <input type="text" class="form-control" id="inputUsernameEmail" value={email} placeholder="Email" onChange={this.handleChange} />
              <input type="password" class="form-control" id="inputPassword" value={password} placeholder="Password" onChange={this.handleChange} />
              <button type="submit" class="btn-block btn btn-primary">Log In</button>
              <a href="#">Forgot password?</a>
            </form>
          </div>
        );
    }
}

function mapStateToProps(state) {
    const { loggingIn } = state.authentication;
    return {
        loggingIn
    };
}

const connectedLoginPage = connect(mapStateToProps)(LoginPage);
export { connectedLoginPage as LoginPage };
