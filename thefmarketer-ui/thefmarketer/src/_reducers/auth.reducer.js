import { authConstant } from '../_constants';

let user = JSON.parse(localStorage.getItem('user'));
let token = JSON.parse(localStorage.getItem('token'));
const initialState = user ? { loggedIn: true, user, token } : {};

export function auth(state = initialState, action) {
  switch (action.type) {
    case authConstant.LOGIN_REQUEST:
      return {
        loggingIn: true,
        user: action.user,
        token: action.token
      };
    case authConstant.LOGIN_SUCCESS:
      return {
        loggedIn: true,
        user: action.user
      };
    case authConstant.LOGIN_FAILURE:
      return {};
    case authConstant.LOGOUT:
      return {};
    default:
      return state
  }
}
