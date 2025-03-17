const uri = "api/users/login"

function LogIn(event) {
    event.preventDefault();

    let user = document.getElementById('user').value
    let pass = document.getElementById('pass').value


    const login = async () => {
        const response = await fetch(uri, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ nickname: user, password: pass })
        });

        const data = await response.json();

        if (response.ok) {
            let mensaje = "✅ Inicio de sesión exitoso:"
            console.log(mensaje, data);
            document.getElementById("estado").textContent = mensaje
            window.location.href ="html/home.html"
        } else {
            let mensaje = "❌ Error:"
            console.log(mensaje, data.message);
            document.getElementById('estado').textContent = mensaje

        }
    };
    login()
}

document.getElementById("logIn").addEventListener("submit", LogIn)


