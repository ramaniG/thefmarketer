
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
            console.log(output);
            // login successful if there's a jwt token in the response
            if (output) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                var token = output.token;
                var user = output.user;

                localStorage.setItem('user', JSON.stringify(user));
                localStorage.setItem('token', JSON.stringify(token));
            }

            return user;
        }
    );
}

function logout() {
    // remove user from local storage to log user out
    var token = JSON.parse(localStorage.getItem('token'));
    if (token) {
        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ Token : token })
        };
    
        return fetch(BASE_URL + '/logout/', requestOptions)
            .then(response => {
                console.log(response);
                if (!response.ok || response.status !== 200) {
                    return Promise.reject(response.statusText);
                }

                localStorage.removeItem('token');
                localStorage.removeItem('user');
        });
    }     
}
