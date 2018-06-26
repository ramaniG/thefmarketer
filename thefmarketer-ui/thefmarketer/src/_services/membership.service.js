
const BASE_URL = 'http://localhost:58863/api/membership/';

export const membershipService = {
    adduser,
    getusers,
    deleteuser,
    updateuser
};

function adduser(FirstName, LastName, Email, Contact, Email2, Contact2, AuthType, Password, ShowEmail, ShowContact, ContactOpt, ContactOpt2, UserType) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ FirstName, LastName, Email, Contact, Email2, Contact2, AuthType, Password, ShowEmail, ShowContact, ContactOpt, ContactOpt2, UserType })
    };

    return fetch(BASE_URL, requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        })
        .then(output => {
            if (output) {
                var user = output;
            }

            return user;
        });
}

function getusers(Token) {
    const requestOptions = {
        method: 'GET',
        headers: { Token }
    };

    return fetch(BASE_URL, requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        })
        .then(output => {
            if (output) {
                var users = output;
            }

            return users;
        });
}

function deleteuser(Token, Id) {
    const requestOptions = {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Token, Id })
    };

    return fetch(BASE_URL, requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }
        });
}

function updateuser(Token, CredentialId, FirstName, LastName, Email, Contact, Email2, Contact2, AuthType, Password, ShowEmail, ShowContact, ContactOpt, ContactOpt2, NumberOfTry, Verified) {
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Token, CredentialId, FirstName, LastName, Email, Contact, Email2, Contact2, AuthType, Password, ShowEmail, ShowContact, ContactOpt, ContactOpt2, NumberOfTry, Verified })
    };

    return fetch(BASE_URL, requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }
        });
}