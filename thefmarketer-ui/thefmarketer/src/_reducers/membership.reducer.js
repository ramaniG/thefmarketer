import { membershipConstants } from '../_constants';

const initialState = {};

export function membership(state = initialState, action) {
  switch (action.type) {
    case membershipConstants.MEMBER_ADDUSER_REQUEST:
    case membershipConstants.MEMBER_ADDUSER_FAILURE:
    case membershipConstants.MEMBER_GETUSERS_REQUEST:
    case membershipConstants.MEMBER_GETUSERS_FAILURE:
    case membershipConstants.MEMBER_DELETEUSER_REQUEST:
    case membershipConstants.MEMBER_DELETEUSER_SUCCESS:
    case membershipConstants.MEMBER_DELETEUSER_FAILURE:
    case membershipConstants.MEMBER_UPDATEUSER_REQUEST:
    case membershipConstants.MEMBER_UPDATEUSER_SUCCESS:
    case membershipConstants.MEMBER_UPDATEUSER_FAILURE:
      return {};
    case membershipConstants.MEMBER_ADDUSER_SUCCESS:
      return { user : action.user };
    case membershipConstants.MEMBER_GETUSERS_SUCCESS:
      return { users : action.users };
    default:
      return state
  }
}