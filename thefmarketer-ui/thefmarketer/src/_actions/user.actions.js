import { userConstants } from '../_constants';
import { userService } from '../_services';
import { alertActions } from './';
import { history } from '../_helpers';

export const userActions = {
    searchconsultant,
    createrequest,
    updaterequest,
    completerequest,
    searchrequest,
    addchat
};

function searchconsultant(Token, MinRating, MaxRating, Name, State, Service) {
    return dispatch => {
        dispatch(request());

        userService.searchconsultant(Token, MinRating, MaxRating, Name, State, Service)
            .then(
                consultants => {
                    dispatch(success(consultants));
                    history.push('/consultants');
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
    };

    function request() { return { type: userConstants.SEARCH_CONSULTANT_REQUEST } }
    function success(consultants) { return { type: userConstants.SEARCH_CONSULTANT_SUCCESS, consultants } }
    function failure(error) { return { type: userConstants.SEARCH_CONSULTANT_FAILURE, error } }
}

function createrequest(Token, Message, Service, ConsultantId) {
    return dispatch => {
        dispatch(request());

        userService.createrequest(Token, Message, Service, ConsultantId)
            .then(
                requests => {
                    dispatch(success(requests));
                    history.push('/requests');
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
    };

    function request() { return { type: userConstants.CREATE_REQUEST_REQUEST } }
    function success(requests) { return { type: userConstants.CREATE_REQUEST_SUCCESS, requests } }
    function failure(error) { return { type: userConstants.CREATE_REQUEST_FAILURE, error } }
}

function updaterequest(Token, RequestId, IsActive) {
    return dispatch => {
        dispatch(request());

        userService.updaterequest(Token, RequestId, IsActive)
            .then(
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
        
        dispatch(success());
    };

    function request() { return { type: userConstants.UPDATE_REQUEST_REQUEST } }
    function success() { return { type: userConstants.UPDATE_REQUEST_SUCCESS } }
    function failure(error) { return { type: userConstants.UPDATE_REQUEST_FAILURE, error } }
}

function completerequest(Token, RequestId, Star, Message, IsPublic) {
    return dispatch => {
        dispatch(request());

        userService.completerequest(Token, RequestId, Star, Message, IsPublic)
            .then(
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
        
        dispatch(success());
    };

    function request() { return { type: userConstants.COMPLETE_REQUEST_REQUEST } }
    function success() { return { type: userConstants.COMPLETE_REQUEST_SUCCESS } }
    function failure(error) { return { type: userConstants.COMPLETE_REQUEST_FAILURE, error } }
}

function searchrequest(Token, Name, Service) {
    return dispatch => {
        dispatch(request());

        userService.searchrequest(Token, Name, Service)
            .then(
                requests => {
                    dispatch(success(requests));
                    history.push('/requests');
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
    };

    function request() { return { type: userConstants.SEARCH_REQUEST_REQUEST } }
    function success(requests) { return { type: userConstants.SEARCH_REQUEST_SUCCESS, requests } }
    function failure(error) { return { type: userConstants.SEARCH_REQUEST_FAILURE, error } }
}

function addchat(Token, Message, RequestId) {
    return dispatch => {
        dispatch(request());

        userService.addchat(Token, Message, RequestId)
            .then(
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );

        dispatch(success());
    };

    function request() { return { type: userConstants.CREATE_CHAT_REQUEST } }
    function success() { return { type: userConstants.CREATE_CHAT_SUCCESS } }
    function failure(error) { return { type: userConstants.CREATE_CHAT_FAILURE, error } }
}
