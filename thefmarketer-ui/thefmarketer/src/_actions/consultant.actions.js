import { consultantConstants } from '../_constants';
import { consultantService } from '../_services';
import { alertActions } from './';
import { history } from '../_helpers';

export const consultantActions = {
    search
};

function search(service, location, name, rating) {
    return dispatch => {
        dispatch(request());

        consultantService.search(service, location, name, rating)
            .then(
                consultants => {
                    dispatch(success(consultants));
                    history.push('/searchresult');
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
    };

    function request() { return { type: consultantConstants.SEARCH_REQUEST } }
    function success(consultants) { return { type: consultantConstants.SEARCH_SUCCESS, consultants } }
    function failure(error) { return { type: consultantConstants.SEARCH_FAILURE, error } }
}
