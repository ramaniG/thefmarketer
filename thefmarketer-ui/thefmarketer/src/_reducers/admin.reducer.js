import { adminConstant } from '../_constants';

const initialState = {};

export function admin(state = initialState, action) {
  switch (action.type) {
    case adminConstant.SEARCH_CONSULTANT_REQUEST:
    case adminConstant.SEARCH_CONSULTANT_FAILURE:
    case adminConstant.SEARCH_REQUEST_REQUEST:
    case adminConstant.SEARCH_REQUEST_FAILURE:
    case adminConstant.UPDATE_REQUEST_REQUEST:
    case adminConstant.UPDATE_REQUEST_SUCCESS:
    case adminConstant.UPDATE_REQUEST_FAILURE:
      return {};
    case adminConstant.SEARCH_CONSULTANT_SUCCESS:
      return { consultants : action.consultants };
    case adminConstant.SEARCH_REQUEST_SUCCESS:
      return { requests : action.requests };
    default:
      return state
  }
}