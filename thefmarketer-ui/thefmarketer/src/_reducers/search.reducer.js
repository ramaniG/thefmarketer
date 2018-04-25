import { consultantConstants } from '../_constants';

const initialState = {};

export function search(state = initialState, action) {
  switch (action.type) {
    case consultantConstants.SEARCH_REQUEST:
      return {};
    case consultantConstants.SEARCH_SUCCESS:
      return {
        consultants: action.consultants
      };
    case consultantConstants.SEARCH_FAILURE:
      return {};
    default:
      return state
  }
}
