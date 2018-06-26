import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';

class AccountToggler extends React.Component {
    render() {
        const { user } = this.props;
        return (
          <div className="toggler">
            <div id="effect" className="container">
              <a href="#">
                <div className="thumbnail">
                  <img src="/img/profile-avatar.png" className="img-circle" width="100" height="100" />
                  <div className="caption">
                    <h3>{user.firstName + " " + user.lastName}</h3>
                  </div>
                </div>
              </a>
              <p><a href="#">Request List <span className="badge">10</span></a></p>
              <p><a href="#">How it Works</a></p>
              <p><a href="#">Settings</a></p>
              <p><a href="#">Help</a></p>
              <p><a href="#">Term & Conditions</a></p>
              <p><Link to="/login"><span className="glyphicon glyphicon-log-out"></span> Logout</Link></p>
            </div>
          </div>
        );
    }
}

function mapStateToProps(state) {
    const { auth } = state;
    const { user } = auth;
    return {
        user
    };
}

const accountToggler = connect(mapStateToProps)(AccountToggler);
export { accountToggler as AccountToggler };
