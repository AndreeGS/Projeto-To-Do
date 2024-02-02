
form.addEventListener('submit', (e) =>{
    e.preventDefault();
})

var btnLogin = document.getElementById("btnLogin");

btnLogin.addEventListener("click", login());

async function login(){
    let email = document.getElementById("email-input").value;
    let senha = document.getElementById("senha-input").value;
    
    var credentials = {
        email: email,
        password: senha
    }

    try {
        const answer = await fetch('https://apiprojetotodo.azurewebsites.net/api/Usuario/Login', {
            method: 'GET',
            headers: {
                'accept': 'text/plain',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(credentials)
        });

        if (answer.ok) {
            try {
                const valid = await resposta.json();
                console.log('Usuário logado:', valid);
            } 
            catch (error) {
                console.error('Erro ao processar resposta da API. Erro ao analisar JSON:', error);
            }
        } else {
            console.error('Erro ao fazer login:', resposta.statusText);
        }
    } catch (error) {
        console.error('Erro ao processar requisição:', error);
    }
}