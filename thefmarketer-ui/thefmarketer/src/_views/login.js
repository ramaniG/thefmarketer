import React from 'react';
import { connect } from 'react-redux';
import { authAction } from '../_actions';

class LoginPage extends React.Component {
    constructor(props) {
        super(props);
        const { dispatch } = this.props;

        // reset login status
        dispatch(authAction.logout());

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
            dispatch(authAction.login(email, password));
        }
    }

    render() {
        const { loggingIn } = this.props;
        const { email, password, submitted } = this.state;
        return (
          <div className="main">
            <h3><img src='/img/LOGO_LOOK.png' width='180px'/></h3>
            <button type="submit" className="btn-block btn btn-primary" style={{marginTop:100}}>Facebook</button>
            <form onSubmit={this.handleSubmit} >
                <div className="login-or">
                    <hr className="hr-or" />
                    <span className="span-or">or</span>
                </div>
                <div className="input-group mb-2 mr-sm-2">
                    <div className="input-group-prepend">
                        <div className="input-group-text"><span className="fas fa-at"></span></div>
                    </div>
                    <input type="text" className="form-control" name="email" value={email} placeholder="Email" onChange={this.handleChange} />
                </div>
                <div className="input-group mb-2 mr-sm-2">
                    <div className="input-group-prepend">
                        <div className="input-group-text"><span className="fas fa-key"></span></div>
                    </div>
                    <input type="password" className="form-control" name="password" value={password} placeholder="Password" onChange={this.handleChange} />
                </div>
                <button type="submit" className="btn-block btn btn-primary">Log In</button>
                <a href="#">Forgot password?</a>
            </form>
          </div>
        );
    }
}

function mapStateToProps(state) {
    const { loggingIn } = state.auth;
    return {
        loggingIn
    };
}

const connectedLoginPage = connect(mapStateToProps)(LoginPage);
export { connectedLoginPage as LoginPage };
