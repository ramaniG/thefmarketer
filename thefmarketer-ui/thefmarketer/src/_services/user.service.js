
const BASE_URL = 'http://localhost:58863/api/user/';

export const userService = {
    searchconsultant,
    createrequest,
    updaterequest,
    completerequest,
    searchrequest,
    addchat
};

function searchconsultant(token, minrating, maxrating, name, state, service) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token, minrating, maxrating, name, state, service })
    };

    return fetch(BASE_URL + '/searchconsultant/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}

function createrequest(token, message, service, consultantId) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token, message, service, consultantId })
    };

    return fetch(BASE_URL + '/createrequest/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}

function updaterequest(token, requestId, isActive) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token, requestId, isActive })
    };

    return fetch(BASE_URL + '/updaterequest/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}

function completerequest(token, requestId, star, message, isPublic) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token, requestId, star, message, isPublic })
    };

    return fetch(BASE_URL + '/completerequest/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}

function searchrequest(token, name, service) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token, name, service })
    };

    return fetch(BASE_URL + '/searchrequest/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}

function addchat(token, message, RequestId) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token, message, RequestId })
    };

    return fetch(BASE_URL + '/chat/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}