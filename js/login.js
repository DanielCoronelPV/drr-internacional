function togglePassword() {
    const passwordInput = document.getElementById("password");
    const toggleBtn = document.querySelector(".toggle-password");
    if (passwordInput.type === "password") {
        passwordInput.type = "text";
        toggleBtn.textContent = "Ocultar";
    } else {
        passwordInput.type = "password";
        toggleBtn.textContent = "Mostrar";
    }
}

document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();
    const username = document.getElementById("username").value.trim();
    const password = document.getElementById("password").value.trim();

    if (username && password) {
        alert(`Intentando iniciar sesión con:\nUsuario: ${username}\nContraseña: ${password}`);
        // Aquí puedes enviar los datos al backend con fetch/AJAX
    } else {
        alert("Por favor, complete todos los campos.");
    }
});