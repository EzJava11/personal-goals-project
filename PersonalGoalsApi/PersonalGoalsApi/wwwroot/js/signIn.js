const uri = "../api/users"

function SignIn(event) {
    event.preventDefault()

    //let email = document.getElementById("email").value
    //let user = document.getElementById("user").value
    //let pass = document.getElementById("pass").value
    const item = {
        email : document.getElementById("email").value,
        nickname : document.getElementById("user").value,
        password : document.getElementById("pass").value
    }

    const signIn = async () => {
        const response = await fetch(uri, {
            method: 'POST',
            headers: {
                /*"Accept" : "aplication/json",*/
                "Content-Type": "application/json"
            },
            body: JSON.stringify(item)
        })
        const data = await response.json()

        if (response.ok) {
            console.log("Registro satisfactorio", data)
        }
        else {
            console.log("Error", data.message)
        }
    }
    signIn()
    //Funciona el registro, pero hay que hacer la verificacion de duplicado de usuario y correo
}
document.getElementById("signIn").addEventListener("submit", SignIn)
