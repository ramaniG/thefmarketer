import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { userActions } from './_actions';

class HomePage extends React.Component {
    componentDidMount() {
        //this.props.dispatch(userActions.getAll());
    }

    handleDeleteUser(id) {
        //return (e) => this.props.dispatch(userActions.delete(id));
    }

    render() {

        return (
            <div className="col-md-6 col-md-offset-3">

                <p>Youre logged in with React!!</p>
                <h3>All registered users:</h3>
                <p>
                    <Link to="/login">Logout</Link>
                </p>
            </div>
        );
    }
}

function mapStateToProps(state) {

}

const connectedHomePage = connect(mapStateToProps)(HomePage);
//export { connectedHomePage as HomePage };
export { HomePage };
