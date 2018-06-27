
const BASE_URL = 'http://localhost:58863/api/admin/';

export const adminService = {
    searchconsultant,
    searchrequest,
    updaterequest
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
        })
        .then(output => {
            if (output) {
                var consultants = output;
            }

            return consultants;
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
        })
        .then(output => {
            if (output) {
                var requests = output;
            }

            return requests;
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
        });
}