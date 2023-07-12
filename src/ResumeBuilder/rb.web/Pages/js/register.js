//this baby fetches data fr u
fetch('url here', {
    method: 'POST',
    headers:
    {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify({
        
        name: 'user 1'
    })
}).then(res => {
        if (res.ok) {
            console.log("sucess...")
        } else {
            console.log("not succesful")
        }
        return res.json() //log response?
})
.then(data => console)
.catch(error => console.log("Error bby"))










async function getapi(url)
{
const api_url = "https://localhost:7294/User/RegisterUser";
let Res = fetch(api_url);
    const response = await Res;


    var data = await response.json();

    console.log(data);
    if (response) {
        hideloader();
    }
    show(data);
}
getapi(api_url); //why call function??




function showPassword() {
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
