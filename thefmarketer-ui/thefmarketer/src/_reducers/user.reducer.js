import { userConstants } from '../_constants';

const initialState = {};

export function user(state = initialState, action) {
  switch (action.type) {
    case userConstants.SEARCH_CONSULTANT_REQUEST:
    case userConstants.SEARCH_CONSULTANT_FAILURE:
    case userConstants.SEARCH_REQUEST_REQUEST: 
    case userConstants.SEARCH_REQUEST_FAILURE:
    case userConstants.CREATE_REQUEST_REQUEST:
    case userConstants.CREATE_REQUEST_FAILURE:
    case userConstants.UPDATE_REQUEST_REQUEST:
    case userConstants.UPDATE_REQUEST_SUCCESS:
    case userConstants.UPDATE_REQUEST_FAILURE:
    case userConstants.COMPLETE_REQUEST_REQUEST:
    case userConstants.COMPLETE_REQUEST_SUCCESS:
    case userConstants.COMPLETE_REQUEST_FAILURE:
    case userConstants.CREATE_CHAT_REQUEST:
    case userConstants.CREATE_CHAT_SUCCESS:
    case userConstants.CREATE_CHAT_FAILURE:
        return {};
    case userConstants.SEARCH_REQUEST_SUCCESS:
        return { requests : action.requests };
    case userConstants.SEARCH_CONSULTANT_SUCCESS:
        return { consultants : action.consultants };
    case userConstants.CREATE_REQUEST_SUCCESS:
        return { request : action.requests };
    default:
        return state
  }
}