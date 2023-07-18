function createCV() {

    
    var fullName = document.getElementById("fullName").value;
    var email = document.getElementById("email").value;
    var phoneNumber = document.getElementById("phoneNumber").value;
    var address = document.getElementById("address").value;
    var institution = document.getElementById("institution").value;
    var courseName = document.getElementById("courseName").value;
    var startDateEducation = document.getElementById("startDateEducation").value;
    var endDateEducation = document.getElementById("endDateEducation").value;
    var company = document.getElementById("company").value;
    var jobTitle = document.getElementById("jobTitle").value;
    var startDateJob = document.getElementById("startDateJob").value;
    var endDateJob = document.getElementById("endDateJob").value;
    var certName = document.getElementById("certName").value;
    var certStartDate = document.getElementById("certStartDate").value;
    var certEndDate = document.getElementById("certEndDate").value;


    var languages = [];
    languages = document.getElementById("languages").value;
    

    fetch('link here for later '), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'text/plain'
        },
        body: JSON.stringify({
            "FullName": fullName,
            "Email": email,
            "Phone": phoneNumber,
            "Address": address,
            "Institution": institution,
            "Course": courseName,
            "FromDate": startDateEducation,
            "ToDate": endDateEducation,
            "Company": company,
            "JobTitle": jobTitle,
            "FromDateJob": startDateJob,
            "ToDateJob": endDateJob,
            "CertificateName": certName,
            "IssuedDate": certStartDate,
            "ExpirationDate": certEndDate,

            //lists
            "languages": languages
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