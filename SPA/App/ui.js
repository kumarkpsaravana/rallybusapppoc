// Select DOM elements to work with
const signInButton = document.getElementById('signIn');
const signUpButton = document.getElementById('signup');
const signOutButton = document.getElementById('signOut')
// const titleDiv = document.getElementById('title-div');
const welcomeDiv = document.getElementById('welcome-div');
const tableDiv = document.getElementById('table-div');
const tableBody = document.getElementById('table-body-div');
const editProfileButton = document.getElementById('editProfileButton');
const VerifyEmailButton = document.getElementById('VerifyEmailButton');
const callApiButton = document.getElementById('callApiButton');
const callClerkButton = document.getElementById('callClerkButton');
const response = document.getElementById("response");
const label = document.getElementById('label');
const roles = document.getElementById('roles');
const emailVerifiedText = document.getElementById('emailVerifiedText');



function welcomeUser(username) {
    label.classList.add('d-none');
    roles.classList.remove('d-none');
    roles.innerText = "Roles : " + localStorage.getItem("roles");
    emailVerifiedText.innerText = "Email Verified : " + localStorage.getItem("emailVerified");
    emailVerifiedText.classList.remove('d-none');

    if(localStorage.getItem("emailVerified") == "true"){
        VerifyEmailButton.classList.add('d-none');
    }
    else{
        VerifyEmailButton.classList.remove('d-none');
    }

    signInButton.classList.add('d-none');
    signUpButton.classList.add('d-none');
    signOutButton.classList.remove('d-none');
    // titleDiv.classList.add('d-none');
    editProfileButton.classList.remove('d-none');
    
    welcomeDiv.classList.remove('d-none');
    welcomeDiv.innerHTML = `Welcome ${username}!`
    callApiButton.classList.remove('d-none');
    callClerkButton.classList.remove('d-none');
}

function logMessage(s) {
    response.appendChild(document.createTextNode('\n' + s + '\n'));
}