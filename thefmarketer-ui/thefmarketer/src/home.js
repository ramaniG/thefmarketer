import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { AccountToggler } from './_components';
import { consultantActions } from './_actions';

class HomePage extends React.Component {
  constructor(props) {
      super(props);
      const { dispatch } = this.props;

      this.state = {
          service: '',
          location: '',
          name: '',
          rating: 0
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
      const { service, location, name, rating } = this.state;
      const { dispatch } = this.props;
      console.log('Clicked');

      dispatch(consultantActions.search(service, location, name, rating));
  }

  render() {
      const { user } = this.props;
      const { service, location, name, rating } = this.state;
      return (
        <div className="main">
          <div className="row">
            < AccountToggler />
          </div>
          <div className="row">
          <h3>Search for Services</h3>
          <div className="icon-addon addon-sm">
            <select className="form-control" name="service" onChange={this.handleChange} value={service}>
              <option value="">Select Service</option>
              <option value="FP">Financial Planner</option>
              <option value="LP">Life Insurance</option>
              <option value="IN">Investments</option>
              <option value="TF">Trust Fund</option>
              <option value="WW">Will Writing</option>
            </select>
            <span className="glyphicon glyphicon-briefcase"></span>
          </div>
          <div className="icon-addon addon-sm">
            <select className="form-control" name="location" onChange={this.handleChange} value={location}>
              <option value="">Select Location</option>
              <option value="JH">Johor</option>
              <option value="KH">Kedah</option>
              <option value="KN">Kelantan</option>
              <option value="KL">Kuala Lumpur</option>
              <option value="LA">Labuan</option>
              <option value="ME">Melaka</option>
              <option value="NS">Negeri Sembilan</option>
              <option value="PH">Pahang</option>
              <option value="PK">Perak</option>
              <option value="PL">Perlis</option>
              <option value="PG">Pulau Pinang</option>
              <option value="PJ">Putrajaya</option>
              <option value="SA">Sabah</option>
              <option value="SK">Sarawak</option>
              <option value="SL">Selangor</option>
              <option value="TE">Terengganu</option>
            </select>
            <span className="glyphicon glyphicon-map-marker" style={{ paddingTop: 42 }}></span>
          </div>
          <div className="icon-addon addon-lg">
            <input type="text" placeholder="eg: John" className="form-control" name="name"  onChange={this.handleChange} value={name}/>
            <label className="glyphicon glyphicon-user"  style={{ paddingTop: 76 }}></label>
          </div>
          <button type="submit" className="btn-block btn btn-primary" onClick={this.handleSubmit}>Search</button>
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

const connectedHomePage = connect(mapStateToProps)(HomePage);
export { connectedHomePage as HomePage };
//export { HomePage };
