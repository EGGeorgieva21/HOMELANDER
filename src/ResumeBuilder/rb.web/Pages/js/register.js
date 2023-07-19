
//this baby fetches data fr u
function register() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    var cPassword = document.getElementById("cPassword").value;
    var email = document.getElementById("email").value;

    fetch('https://localhost:7294/User/RegisterUser', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'text/plain'
        },
        body: JSON.stringify({
            "username": username,
            "password": password,
            "email": email
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
            console.log(data);
            localStorage.setItem('token', data.token)
            window.location.href = "main.html";
        }).catch(function (err) {
            console.warn('Something went wrong.', err);
        })
    }


function showPassword() {
    let id = document.getElementById('password');
    let bam = document.getElementById('cPassword');
    if (id.type === "password") {
        id.type = "text";
        bam.type = "text";
    }
    else {
        id.type = "password";
        bam.type = "password";
    }
}
