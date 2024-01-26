const email = document.getElementById("email-input").value;
const senha = document.getElementById("senha-input").value;

var dados = {
    'email': email,
    'senha': senha
}

const apiUrl = 'https://localhost:7105/api/Usuario'

