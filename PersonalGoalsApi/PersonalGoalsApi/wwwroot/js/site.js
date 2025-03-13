const uri = 'api/User';

document.getElementById(logIn).addEventListener("submit", async function logIn(event) {
    event.preventDefault();
    const username = document.getElementById("user").value ;
    const password = document.getElementById("pass").value ;


    try{
        const response = await fetch("https://localhost:5001/api/user", {
            method : "Post",
            headers : {"Content-Type" : "aplication/json"},
            body: JSON.stringify({username, password})
        });
        
    }
})