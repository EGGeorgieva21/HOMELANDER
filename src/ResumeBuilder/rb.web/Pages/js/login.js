
function login() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    fetch('https://localhost:7294/User/LoginUser', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'text/plain'

        },
        body: JSON.stringify({
            "username": username,
            "password": password,
        })
    })
        .then(res => {
            if (res.ok) {
                console.log("Success...");
                localStorage.setItem('token', res.data)
                window.location.href = "main.html";
            } else {
                console.log("Not successful");
                window.alert("Invalid login details");
            }
            return res.json();
        })
        .then(data => {
            console.log(data);
        })
        .catch(error => {
            console.log("Error:", error);
        });
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


