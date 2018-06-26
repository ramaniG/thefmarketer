import { adminConstant } from '../_constants';
import { adminService } from '../_services';
import { alertActions } from './';
import { history } from '../_helpers';

export const consultantActions = {
    searchconsultant,
    searchrequest,
    updaterequest
};

function searchconsultant(token, minrating, maxrating, name, state, service) {
    return dispatch => {
        dispatch(request());

        adminService.searchconsultant(token, minrating, maxrating, name, state, service)
            .then(
                consultants => {
                    dispatch(success(consultants));
                    history.push('/searchconsultant');
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
    };

    function request() { return { type: adminConstant.SEARCH_CONSULTANT_REQUEST } }
    function success(consultants) { return { type: adminConstant.SEARCH_CONSULTANT_SUCCESS, consultants } }
    function failure(error) { return { type: adminConstant.SEARCH_CONSULTANT_FAILURE, error } }
}

function searchrequest(token, name, service) {
    return dispatch => {
        dispatch(request());

        adminService.searchrequest(token, name, service)
            .then(
                requests => {
                    dispatch(success(requests));
                    history.push('/searchrequest');
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
    };

    function request() { return { type: adminConstant.SEARCH_REQUEST_REQUEST } }
    function success(requests) { return { type: adminConstant.SEARCH_REQUEST_SUCCESS, requests } }
    function failure(error) { return { type: adminConstant.SEARCH_REQUEST_FAILURE, error } }
}

function updaterequest(token, requestId, isActive) {
    return dispatch => {
        dispatch(request());

        adminService.updaterequest(token, requestId, isActive)
            .then(
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );

        dispatch(success());
    };

    function request() { return { type: adminConstant.UPDATE_REQUEST_REQUEST } }
    function success() { return { type: adminConstant.UPDATE_REQUEST_SUCCESS } }
    function failure(error) { return { type: adminConstant.UPDATE_REQUEST_FAILURE, error } }
}