import { consultantConstants } from '../_constants';

const initialState = {};

export function user(state = initialState, action) {
  switch (action.type) {
    case consultantConstants.SEARCH_REQUEST_REQUEST:
    case consultantConstants.SEARCH_REQUEST_FAILURE: 
    case consultantConstants.CREATE_STATE_REQUEST:
    case consultantConstants.CREATE_STATE_SUCCESS:
    case consultantConstants.CREATE_STATE_FAILURE:
    case consultantConstants.UPDATE_STATE_REQUEST:
    case consultantConstants.UPDATE_STATE_SUCCESS:
    case consultantConstants.UPDATE_STATE_FAILURE:
    case consultantConstants.CREATE_SERVICE_REQUEST:
    case consultantConstants.CREATE_SERVICE_SUCCESS:
    case consultantConstants.CREATE_SERVICE_FAILURE:
    case consultantConstants.UPDATE_SERVICE_REQUEST:
    case consultantConstants.UPDATE_SERVICE_SUCCESS:
    case consultantConstants.UPDATE_SERVICE_FAILURE:
    case consultantConstants.CREATE_CHAT_REQUEST:
    case consultantConstants.CREATE_CHAT_SUCCESS:
    case consultantConstants.CREATE_CHAT_FAILURE:
        return {};
    case consultantConstants.SEARCH_REQUEST_SUCCESS:
        return { requests : action.requests };
    default:
        return state
  }
}