
function showPassword() {
    debugger;
    let id = document.getElementById('password');
    if (id.type === "password") {
        id.type = "text";
    }
    else {
        id.type = "password";
    }
}