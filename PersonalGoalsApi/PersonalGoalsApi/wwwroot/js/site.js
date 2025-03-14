const uri = 'api/Users';

let user = document.getElementById("user").textContent
let pass = document.getElementById("pass").textContent

const item = {
    nickname: user,
    password: pass
}


    document.getElementById("logIn").addEventListener("submit", async function (event) {
        event.preventDefault()

        const response =  fetch(uri, {
            method: "POST",
            headers: {
                'Accept': "aplication/json",
                "Content-Type":"aplication/json"
            },
            body: JSON.stringify({
                item
            })
        })
        if (response.ok) {
            const data = await response.json()
            console.log("Usuario validado correctamente: ", data)
        } else {
            console.log("Error en la valiacion del usuario: ", response.status)
            alert("Credenciales incorrectas. Vuelva a intentarlo")
        }
    })
    fetch(uri)
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.error('unable get items', error))


