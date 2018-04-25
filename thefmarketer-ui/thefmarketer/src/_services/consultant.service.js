
export const consultantService = {
    search
};

function search(service, location, name, rating) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ service, location, name, rating })
    };

    localStorage.removeItem('consultants');

    return fetch('http://127.0.0.1:8000/search/', requestOptions)
        .then(response => {
            console.log(response);
            if (!response.ok || response.status !== 200) {
                return Promise.reject(response.statusText);
            }

            return response.json();
        })
        .then(consultants => {
            // login successful if there's a jwt token in the response
            if (consultants) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('consultants', JSON.stringify(consultants));
            }

            return consultants;
        });
}
