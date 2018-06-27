
const BASE_URL = 'http://localhost:58863/api/consultant/';

export const consultantService = {
    searchrequest,
    addstate,
    addservice,
    updatestate,
    updateservice,
    addchat
};

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

function addstate(Token, State, Location) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Token, State, Location })
    };

    return fetch(BASE_URL + '/state/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }
        });
}

function addservice(Token, Service, Company, LicenseActive, RegistrationNo, ActiveSince, YearsOfExp, ClientScale, Proof) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Token, Service, Company, LicenseActive, RegistrationNo, ActiveSince, YearsOfExp, ClientScale, Proof })
    };

    return fetch(BASE_URL + '/service/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }
        });
}

function updatestate(Token, CoverageId, State, Location, IsDeleted) {
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Token, CoverageId, State, Location, IsDeleted })
    };

    return fetch(BASE_URL + '/state/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }
        });
}

function updateservice(Token, ServiceId, Service, Company, LicenseActive, RegistrationNo, ActiveSince, YearsOfExp, ClientScale, Proof, IsDeleted) {
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Token, ServiceId, Service, Company, LicenseActive, RegistrationNo, ActiveSince, YearsOfExp, ClientScale, Proof, IsDeleted })
    };

    return fetch(BASE_URL + '/service/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }
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