import { authConstant } from '../_constants';
import { authService } from '../_services';
import { alertActions } from './';
import { history } from '../_helpers';

export const authAction = {
    login,
    logout
};

function login(username, password) {
    return dispatch => {
        dispatch(request({ username }));

        authService.login(username, password)
            .then(
                user => {
                    dispatch(success(user.user, user.token));
                    if (user.user.userType === "Consultant") history.push("consultant_home");
                    else if (user.user.userType === "User") history.push("user_home");
                    else history.push('/');
                },
                error => {
                    dispatch(failure(error));
                    dispatch(alertActions.error(error));
                }
            );
    };

    function request(user, token) { return { type: authConstant.LOGIN_REQUEST, user, token } }
    function success(user) { return { type: authConstant.LOGIN_SUCCESS, user } }
    function failure(error) { return { type: authConstant.LOGIN_FAILURE, error } }
}

function logout() {
    authService.logout();
    return { type: authConstant.LOGOUT_SUCCESS };
}
