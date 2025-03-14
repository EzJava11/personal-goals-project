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
            console.log("✅ Inicio de sesión exitoso:", data);
            window.location.href ="html/home.html"
        } else {
            console.log("❌ Error:", data.message);
        }
    };
    login()
}

document.getElementById("logIn").addEventListener("submit", LogIn)


