//this baby fetches data fr u

function register() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    var cPassword = document.getElementById("cPassword").value;
    var email = document.getElementById("email").value;


    console.log(username);
    console.log(password);
    console.log(email);

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
            // This is the JSON from our response
            console.log(data);
            localStorage.setItem('token', data.token)
            window.location.href = "main.html";
        }).catch(function (err) {
            // There was an error
            console.warn('Something went wrong.', err);
        })
    }


//async function getapi(url)
//{
//const api_url = "https://localhost:7294/User/RegisterUser";
//let Res = fetch(api_url);
//    const response = await Res;


//    var data = await response.json();

//    console.log(data);
//    if (response) {
//        hideloader();
//    }
//    show(data);
//}
//getapi(api_url); //why call function??




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
