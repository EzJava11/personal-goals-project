const uri = "../api/users"

function SignIn(event) {
    event.preventDefault()
    const item = {
        email : document.getElementById("email").value,
        nickname : document.getElementById("user").value,
        password : document.getElementById("pass").value
    }

    const signIn = async () => {
        const response = await fetch(uri, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(item)
        })
        const data = await response.json()

        if (response.ok) {
            let mensaje = "✅ Inicio de sesión exitoso:"
            console.log(mensaje, data);
            document.getElementById("status").textContent = mensaje
            alert("Creacion de usuario exitosa")
            window.location.href = "../index.html"
            
        } else {
            let mensaje = "❌ Error: credenciales no validas"
            console.log(mensaje, data.message);
            document.getElementById("status").textContent = mensaje

        }
    }
    signIn()
    //Funciona el registro, pero hay que hacer la verificacion de duplicado de usuario y correo
}
document.getElementById("signIn").addEventListener("submit", SignIn)
