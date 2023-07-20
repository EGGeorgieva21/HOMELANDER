
function login() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    fetch('https://localhost:7294/User/LoginUser', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'text/plain',
            'Authorization': 'token'
        },
        body: JSON.stringify({
            "username": username,
            "password": password,
        })
    })
    .then(function (response) {
            // The API call was successful!
            if (response.ok) {
                return response.json();
            } else {
                return Promise.reject(response);
            }
        }).then(function (data) {
            // This is the JSON from our response
            console.log(data);
            localStorage.setItem('token', data.token)
            window.location.href = "main.html";
        }).catch(function (err) {
            // There was an error
            console.warn('Something went wrong.', err);
        })
}

function showPassword() {
    let id = document.getElementById('password');
    if (id.type === "password") {
        id.type = "text";
    }
    else {
        id.type = "password";
    }
}


