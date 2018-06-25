
const BASE_URL = 'http://localhost:58863/api/membership/';

export const membershipService = {
    adduser,
    getusers,
    deleteuser,
    updateuser
};

function adduser(firstName, lastName, email, contact, email2, contact2, authType, password, showEmail, showContact, contactOpt, contactOpt2, userType) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ firstName, lastName, email, contact, email2, contact2, authType, password, showEmail, showContact, contactOpt, contactOpt2, userType })
    };

    return fetch(BASE_URL, requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}

function getusers(token) {
    const requestOptions = {
        method: 'GET',
        headers: { 'Token' : token }
    };

    return fetch(BASE_URL, requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}

function deleteuser(token, id) {
    const requestOptions = {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token, id })
    };

    return fetch(BASE_URL, requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}

function updateuser(token, credentialId, firstName, lastName, email, contact, email2, contact2, authType, password, showEmail, showContact, contactOpt, contactOpt2, numberOfTry, verified) {
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token, credentialId, firstName, lastName, email, contact, email2, contact2, authType, password, showEmail, showContact, contactOpt, contactOpt2, numberOfTry, verified })
    };

    return fetch(BASE_URL, requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}