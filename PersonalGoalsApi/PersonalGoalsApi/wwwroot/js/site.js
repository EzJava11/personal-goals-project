document.getElementById("loginButton").addEventListener("click", async (event) {
    event.preventDefault(); // Prevenir que el formulario se envíe y recargue la página

    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    try {
        const response = await fetch("https://localhost:7239/api/User", { // Asegura que el puerto es el correcto
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ username, password })
        })

        const data = await response.json();

        if (response.ok) {
            console.log("Inicio de sesión exitoso");
            localStorage.setItem("token", data.token); // Guardar token en Local Storage
            window.location.href = "home.html"; // Redirigir al usuario
        } else {
            alert("Error: " + data.message);
        }
    } catch (error) {
        console.error("Error en la solicitud:", error);
        alert("Hubo un error en la conexión con el servidor.");
    }
});
