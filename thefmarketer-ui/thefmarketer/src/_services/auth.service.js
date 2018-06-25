
const BASE_URL = 'http://localhost:58863/api/auth/';

export const authService = {
    login,
    logout
};

function login(email, password) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password })
    };

    return fetch(BASE_URL + '/login/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        })
        .then(output => {
            // login successful if there's a jwt token in the response
            if (output) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                all = JSON.stringify(output);
                credential = all.credentialUser.credential;
                token = all.securityToken;

                if (credential.AuthType == 0) {
                    user = all.credentialUser.user;
                } else if (credential.AuthType == 1) {
                    user = all.credentialUser.consultant;
                } else if (credential.AuthType == 2) {
                    user = all.credentialUser.admin;
                }

                localStorage.setItem('user', JSON.stringify(user));
                localStorage.setItem('credential', JSON.stringify(credential));
                localStorage.setItem('token', JSON.stringify(token));
            }

            return user;
        }
    );
}

function logout(token) {
    // remove user from local storage to log user out
    localStorage.removeItem('user');
    localStorage.removeItem('credential');
    localStorage.removeItem('token');

    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token })
    };

    return fetch(BASE_URL + '/logout/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}
