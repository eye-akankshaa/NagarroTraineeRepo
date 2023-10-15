//1.teacher signup validation
function validateForm() {
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;

    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    var passwordPattern = /^(?=.[A-Z])(?=.\d)(?=.[@$!%?&])[A-Za-z\d@$!%*?&]{8,15}$/;

    if (!emailPattern.test(email)) {
        alert("Please enter a valid email address.");
        event.preventDefault();
        return false;
    }

    if (!passwordPattern.test(password)) {
        event.preventDefault();
        alert("Password must be 8-15 characters long and contain at least one uppercase letter and one special character.");
        return false;
    }
    return true;
   
}

//2. teacher login form validation
const urlParams = new URLSearchParams(window.location.search);
// Check if the 'error' parameter is present
const errorType = urlParams.get('error');
if (errorType === 'wrongPassword') {
    setTimeout(function() {
        alert("Wrong password!");
    }, 200);

}
else if (errorType === 'teacherNotFound') {
    setTimeout(function() {
        alert("Teacher Record Not Found!");
    }, 200);

}

//3. teacher add record
function validateFormAddrec() {
    var roll = document.getElementById("roll").value;
    var name = document.getElementById("name").value;
    var dob = document.getElementById("dob").value;
    var score = document.getElementById("score").value;
    var isValid = true;

    // Validation for RollNo (positive integer)
    if (isNaN(roll) || roll <= 0) {
        document.getElementById("rollError").textContent = "Please enter a valid positive Roll Number.";
        isValid = false;
    } else {
        document.getElementById("rollError").textContent = "";
    }

    // Validation for Name (only alphabetic characters and spaces)
    if (!/^[A-Za-z ]+$/.test(name)) {
        document.getElementById("nameError").textContent = "Name must contain only alphabetic characters and spaces.";
        isValid = false;
    } else {
        document.getElementById("nameError").textContent = "";
    }

    // Validation for DateOfBirth (not empty)
    if (dob === "") {
        document.getElementById("dobError").textContent = "Please enter a valid Date of Birth.";
        isValid = false;
    } else {
        document.getElementById("dobError").textContent = "";
    }

    // Validation for Score (positive integer)
    if (isNaN(score) || score < 0) {
        document.getElementById("scoreError").textContent = "Please enter a valid positive Score.";
        isValid = false;
    } else {
        document.getElementById("scoreError").textContent = "";
    }

    return isValid;
}

//4.teacher edit record validation
function validateFormeditRec() {
    var name = document.getElementById("name").value;
    var roll = document.getElementById("roll").value;
    var dob = document.getElementById("dob").value;
    var score = document.getElementById("score").value;

    // Validation for Name (only alphabetic characters and spaces)
    if (!/^[A-Za-z ]+$/.test(name)) {
        alert("Name must contain only alphabetic characters and spaces.");
        return false;
    }

    // Validation for RollNo (positive integer)
    if (isNaN(roll) || roll <= 0) {
        alert("Please enter a valid Roll Number.");
        return false;
    }

    // Validation for DateOfBirth (not empty)
    if (dob === "") {
        alert("Please enter a valid Date of Birth.");
        return false;
    }

    // Validation for Score (positive integer)
    if (!/^[0-9]+$/.test(score)) {
        alert("Score must contain only numeric characters.");
        return false;
    }

    return true;
}
//5. student login form validation
function validateFormStudent() {
    var roll = document.getElementById("roll").value;
    var name = document.getElementById("name").value;

    // Validation for Rollno (positive integer)
    if (isNaN(roll) || roll <= 0) {
        alert("Please enter a valid Roll Number.");
        return false;
    }

    // Validation for blank name
    if (name === "") {
        alert("Please enter a valid .");
        return false;
    }

    return true;
}