var btnLogin = document.getElementById("btnLogin");

btnLogin.addEventListener("click", function(event) {
    event.preventDefault();
    console.log("Botão de login clicado");
    login();
});


async function login(){
    let email = document.getElementById("email-input").value;
    let senha = document.getElementById("senha-input").value;
    
    let credentials = {
        email: email,
        password: senha
    };

    try {
        const response = await fetch('https://apiprojetotodo.azurewebsites.net/api/Usuario/Login', {
            method: 'POST',
            headers: {
                'accept': 'text/plain',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(credentials)
        });

        if (response.ok) {
            try {
                const valid = await response.json();
                console.log('Usuário logado:', valid);
                alert("Certo")

                sessionStorage.setItem('token', valid.token)
            } 
            catch (error) {
                console.error('Erro ao processar resposta da API. Erro ao analisar JSON:', error);
                alert("erro")
            }
        } else {
            console.error('Erro ao fazer login:', response.statusText);
            alert("erro")
        }
    } catch (error) {
        console.error('Erro ao processar requisição:', error);
    }
}
