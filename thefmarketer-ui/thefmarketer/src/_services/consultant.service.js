
const BASE_URL = 'http://localhost:58863/api/consultant/';

export const consultantService = {
    searchrequest,
    addstate,
    addservice,
    updatestate,
    updateservice,
    addchat
};

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

function addstate(token, state, location) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token, state, location })
    };

    return fetch(BASE_URL + '/state/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}

function addservice(token, service, company, licenseActive, registrationNo, activeSince, yearsOfExp, clientScale, proof) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token, service, company, licenseActive, registrationNo, activeSince, yearsOfExp, clientScale, proof })
    };

    return fetch(BASE_URL + '/service/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}

function updatestate(token, coverageId, state, location, isDeleted) {
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token, coverageId, state, location, isDeleted })
    };

    return fetch(BASE_URL + '/state/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        });
}

function updateservice(token, serviceId, service, company, licenseActive, registrationNo, activeSince, yearsOfExp, clientScale, proof, isDeleted) {
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ token, serviceId, service, company, licenseActive, registrationNo, activeSince, yearsOfExp, clientScale, proof, isDeleted })
    };

    return fetch(BASE_URL + '/service/', requestOptions)
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