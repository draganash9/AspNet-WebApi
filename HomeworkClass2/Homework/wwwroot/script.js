let getAllUsersBtn = document.getElementById("btnAllUsres");
let getByIdBtn = document.getElementById("btnById");
let getAddUserBtn = document.getElementById("btnAdd");
let getByIdInput = document.getElementById("inputById");
let getFirstNameInput = document.getElementById("inputFirstName");
let getLastNameInput = document.getElementById("inputLastName");
let getAgeInput = document.getElementById("inputAge");

let port = "57030";

let getAllUsers = async () => {
    let url = "http://localhost:" + port + "/api/users";

    let response = await fetch(url);
    let data = await response.json();
    console.log(data);
};

let getUserById = async () => {
    let url = "http://localhost:" + port + "/api/users/" + getByIdInput.value;

    let response = await fetch(url);
    let data = await response.text();
    console.log(data);
};

let addUser = async () => {
    let url = "http://localhost:" + port + "/api/users";

    let user = { firstname: getFirstNameInput.value, lastname: getLastNameInput.value, age: getAgeInput.value  }
    await fetch(url, {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    });
};




getAllUsersBtn.addEventListener("click", getAllUsers);
getByIdBtn.addEventListener("click", getUserById);
getAddUserBtn.addEventListener("click", addUser);