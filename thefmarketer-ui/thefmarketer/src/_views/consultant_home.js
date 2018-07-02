import React from 'react';
import { connect } from 'react-redux';
import { consultantActions } from '../_actions';

class ConsultantHomePage extends React.Component {
  constructor(props) {
      super(props);
      const { dispatch, token } = this.props;

      dispatch(consultantActions.searchrequest(token, "", ""));

      this.handleChange = this.handleChange.bind(this);
      this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(e) {
      const { name, value } = e.target;
      this.setState({ [name]: value });
  }

  handleSubmit(e) {
      e.preventDefault();
      const { service, location, name, rating } = this.state;
      const { dispatch } = this.props;
      console.log('Clicked');

      dispatch(consultantActions.search(service, location, name, rating));
  }

  render() {
      const { user } = this.props;
      return (
        <div className="main">
          <div className="row">
          <h3>Search for Services</h3>
          <div className="icon-addon addon-sm">
            <span className="glyphicon glyphicon-briefcase"></span>
          </div>
          <div className="icon-addon addon-sm">
            <span className="glyphicon glyphicon-map-marker" style={{ paddingTop: 42 }}></span>
          </div>
          <div className="icon-addon addon-lg">
            <label className="glyphicon glyphicon-user"  style={{ paddingTop: 76 }}></label>
          </div>
          <button type="submit" className="btn-block btn btn-primary" onClick={this.handleSubmit}>Search</button>
          </div>
        </div>
      );
  }
}

function mapStateToProps(state) {
    const { auth, consultant } = state;
    const { user, token } = auth;
    const { requests } = consultant;
    return {
        user, token, requests
    };
}

const connectedConsultantHomePage = connect(mapStateToProps)(ConsultantHomePage);
export { connectedConsultantHomePage as ConsultantHomePage };
