

function showPassword() {
    debugger;
    let id = document.getElementById('Password');
    let bam = document.getElementById('CPassword');
    if (id.type === "password") {
        id.type = "text";
        bam.type = "text";
    } 
    else {
        id.type = "password";
        bam.type = "password";    
  }
}
