import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';

class MenuUser extends React.Component {
    render() {
        const { user } = this.props;
        return (
        <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
            <a class="navbar-brand" href="#">Fixed navbar</a>
            <button class="navbar-toggler collapsed" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
            <div class="navbar-collapse collapse" id="navbarCollapse" style="">
              <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                  <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="#">Link</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link disabled" href="#">Disabled</a>
                </li>
              </ul>
            </div>
        </nav>
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

const menuUser = connect(mapStateToProps)(MenuUser);
export { menuUser as MenuUser };
