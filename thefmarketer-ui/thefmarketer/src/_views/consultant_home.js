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
          <h3>REQUESTS</h3>
          <ul className="list-unstyled ul-request-list">
            <li className="shadow">
              <div className="row div-request">
                  <div class="col-3">
                    <img class="mr-3 rounded-circle img-profile" src="/img/profile-avatar.png" alt="Generic placeholder image" />
                  </div>
                  <div class="col-9">
                    <h6 class="text-left">User name</h6>
                    <div class="mt-0 mb-1 text-left">List-based media object</div>
                  </div>
              </div>
              <div className="row">
                  <div role="button" class="col div-button-yes"><span className="fa fa-check"></span></div>
                  <div role="button" class="col div-button-no"><span className="fa fa-times"></span></div>
              </div>
            </li>
            <li className="shadow">
              <div className="row div-request">
                  <div class="col-3">
                    <img class="mr-3 rounded-circle img-profile" src="/img/profile-avatar.png" alt="Generic placeholder image" />
                  </div>
                  <div class="col-9">
                    <h6 class="text-left">User name</h6>
                    <div class="mt-0 mb-1 text-left">List-based media object</div>
                  </div>
              </div>
              <div className="row">
                  <div role="button" class="col div-button-yes"><span className="fa fa-check"></span></div>
                  <div role="button" class="col div-button-no"><span className="fa fa-times"></span></div>
              </div>
            </li>
            <li className="shadow">
              <div className="row div-request">
                  <div class="col-3">
                    <img class="mr-3 rounded-circle img-profile" src="/img/profile-avatar.png" alt="Generic placeholder image" />
                  </div>
                  <div class="col-9">
                    <h6 class="text-left">User name</h6>
                    <div class="mt-0 mb-1 text-left">List-based media object</div>
                  </div>
              </div>
              <div className="row">
                  <div role="button" class="col div-button-yes"><span className="fa fa-check"></span></div>
                  <div role="button" class="col div-button-no"><span className="fa fa-times"></span></div>
              </div>
            </li>
          </ul>
          <button type="submit" className="btn-block btn btn-primary" onClick={this.handleSubmit}>Search</button>
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
