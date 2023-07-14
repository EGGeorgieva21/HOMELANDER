
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
        .then(res => {
            if (res.ok) {
                if (username == "" || password == "" || email == "") {
                    console.log("fill all spaces");
                }
                else if (password != cPassword) {
                    console.log("password and confirm password should be the same");
                }
                else {
                    console.log("Success...");
                    window.location.href = "login.html";
                }
            }
            else
            {
                console.log("Not successful");
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
