import { consultantConstants } from '../_constants';
import { consultantService } from '../_services';
import { alertActions } from './';

export const consultantActions = {
    searchrequest,
    addstate,
    addservice,
    updatestate,
    updateservice,
    addchat
};

function searchrequest(Token, Name, Service) {
    return dispatch => {
        dispatch(request());

        consultantService.searchrequest(Token, Name, Service)
            .then(
                requests => {
                    dispatch(success(requests));
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
    };

    function request() { return { type: consultantConstants.SEARCH_REQUEST_REQUEST } }
    function success(requests) { return { type: consultantConstants.SEARCH_REQUEST_SUCCESS, requests } }
    function failure(error) { return { type: consultantConstants.SEARCH_REQUEST_FAILURE, error } }
}

function addstate(Token, State, Location) {
    return dispatch => {
        dispatch(request());

        consultantService.addstate(Token, State, Location)
            .then(
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );

        dispatch(success());
    };

    function request() { return { type: consultantConstants.CREATE_STATE_REQUEST } }
    function success() { return { type: consultantConstants.CREATE_STATE_SUCCESS } }
    function failure(error) { return { type: consultantConstants.CREATE_STATE_FAILURE, error } }
}

function addservice(Token, Service, Company, LicenseActive, RegistrationNo, ActiveSince, YearsOfExp, ClientScale, Proof) {
    return dispatch => {
        dispatch(request());

        consultantService.addservice(Token, Service, Company, LicenseActive, RegistrationNo, ActiveSince, YearsOfExp, ClientScale, Proof)
            .then(
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );

        dispatch(success());
    };

    function request() { return { type: consultantConstants.CREATE_SERVICE_REQUEST } }
    function success() { return { type: consultantConstants.CREATE_SERVICE_SUCCESS } }
    function failure(error) { return { type: consultantConstants.CREATE_SERVICE_FAILURE, error } }
}

function updatestate(Token, CoverageId, State, Location, IsDeleted) {
    return dispatch => {
        dispatch(request());

        consultantService.updatestate(Token, CoverageId, State, Location, IsDeleted)
            .then(
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );

        dispatch(success());
    };

    function request() { return { type: consultantConstants.UPDATE_STATE_REQUEST } }
    function success() { return { type: consultantConstants.UPDATE_STATE_SUCCESS } }
    function failure(error) { return { type: consultantConstants.UPDATE_STATE_FAILURE, error } }
}

function updateservice(Token, ServiceId, Service, Company, LicenseActive, RegistrationNo, ActiveSince, YearsOfExp, ClientScale, Proof, IsDeleted) {
    return dispatch => {
        dispatch(request());

        consultantService.updateservice(Token, ServiceId, Service, Company, LicenseActive, RegistrationNo, ActiveSince, YearsOfExp, ClientScale, Proof, IsDeleted)
            .then(
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );

        dispatch(success());
    };

    function request() { return { type: consultantConstants.UPDATE_SERVICE_REQUEST } }
    function success() { return { type: consultantConstants.UPDATE_SERVICE_SUCCESS } }
    function failure(error) { return { type: consultantConstants.UPDATE_SERVICE_FAILURE, error } }
}

function addchat(Token, Message, RequestId) {
    return dispatch => {
        dispatch(request());

        consultantService.addchat(Token, Message, RequestId)
            .then(
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );

        dispatch(success());
    };

    function request() { return { type: consultantConstants.CREATE_CHAT_REQUEST } }
    function success() { return { type: consultantConstants.CREATE_CHAT_SUCCESS } }
    function failure(error) { return { type: consultantConstants.CREATE_CHAT_FAILURE, error } }
}
