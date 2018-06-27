
const BASE_URL = 'http://localhost:58863/api/user/';

export const userService = {
    searchconsultant,
    createrequest,
    updaterequest,
    completerequest,
    searchrequest,
    addchat
};

function searchconsultant(Token, MinRating, MaxRating, Name, State, Service) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Token, MinRating, MaxRating, Name, State, Service })
    };

    return fetch(BASE_URL + '/searchconsultant/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        })
        .then(output => {
            if (output) {
                var consultants = output;
            }

            return consultants;
        });
}

function createrequest(Token, Message, Service, ConsultantId) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Token, Message, Service, ConsultantId })
    };

    return fetch(BASE_URL + '/createrequest/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }
        });
}

function updaterequest(Token, RequestId, IsActive) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Token, RequestId, IsActive })
    };

    return fetch(BASE_URL + '/updaterequest/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }
        });
}

function completerequest(Token, RequestId, Star, Message, IsPublic) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Token, RequestId, Star, Message, IsPublic })
    };

    return fetch(BASE_URL + '/completerequest/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }
        });
}

function searchrequest(Token, Name, Service) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Token, Name, Service })
    };

    return fetch(BASE_URL + '/searchrequest/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        })
        .then(output => {
            if (output) {
                var requests = output;
            }

            return requests;
        });
}

function addchat(Token, Message, RequestId) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Token, Message, RequestId })
    };

    return fetch(BASE_URL + '/chat/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }
        });
}