import { membershipConstants } from '../_constants';
import { membershipService } from '../_services';
import { alertActions } from './';

export const userActions = {
    adduser,
    getusers,
    deleteuser,
    updateuser
};

function adduser(FirstName, LastName, Email, Contact, Email2, Contact2, AuthType, Password, ShowEmail, ShowContact, ContactOpt, ContactOpt2, UserType) {
    return dispatch => {
        dispatch(request());

        membershipService.adduser(FirstName, LastName, Email, Contact, Email2, Contact2, AuthType, Password, ShowEmail, ShowContact, ContactOpt, ContactOpt2, UserType)
            .then(
                user => {
                    dispatch(success(user));
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
    };

    function request() { return { type: membershipConstants.MEMBER_ADDUSER_REQUEST } }
    function success(user) { return { type: membershipConstants.MEMBER_ADDUSER_SUCCESS, user } }
    function failure(error) { return { type: membershipConstants.MEMBER_ADDUSER_FAILURE, error } }
}

function getusers(Token) {
    return dispatch => {
        dispatch(request());

        membershipService.getusers(Token)
            .then(
                users => {
                    dispatch(success(users));
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
    };

    function request() { return { type: membershipConstants.MEMBER_GETUSERS_REQUEST } }
    function success(user) { return { type: membershipConstants.MEMBER_GETUSERS_SUCCESS, user } }
    function failure(error) { return { type: membershipConstants.MEMBER_GETUSERS_FAILURE, error } }
}

function deleteuser(Token, Id) {
    return dispatch => {
        dispatch(request());

        membershipService.deleteuser(Token, Id)
            .then(
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
        
        dispatch(success());
    };

    function request() { return { type: membershipConstants.MEMBER_DELETEUSER_REQUEST } }
    function success() { return { type: membershipConstants.MEMBER_DELETEUSER_SUCCESS } }
    function failure(error) { return { type: membershipConstants.MEMBER_DELETEUSER_FAILURE, error } }
}

function updateuser(Token, CredentialId, FirstName, LastName, Email, Contact, Email2, Contact2, AuthType, Password, ShowEmail, ShowContact, ContactOpt, ContactOpt2, NumberOfTry, Verified) {
    return dispatch => {
        dispatch(request());

        membershipService.updateuser(Token, CredentialId, FirstName, LastName, Email, Contact, Email2, Contact2, AuthType, Password, ShowEmail, ShowContact, ContactOpt, ContactOpt2, NumberOfTry, Verified)
            .then(
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
        
        dispatch(success());
    };

    function request() { return { type: membershipConstants.MEMBER_UPDATEUSER_REQUEST } }
    function success() { return { type: membershipConstants.MEMBER_UPDATEUSER_SUCCESS } }
    function failure(error) { return { type: membershipConstants.MEMBER_UPDATEUSER_FAILURE, error } }
}