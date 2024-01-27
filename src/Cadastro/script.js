var btnCadastrar = document.getElementById("btnCadastrar");

btnCadastrar.addEventListener("click", Cadastro);

async function Cadastro() {
    let nome = document.getElementById("nome").value;
    let email = document.getElementById("email").value;
    let senha = document.getElementById("senha").value;

    // Verificar inputs vazios
    if (!nome || !email || !senha) {
        alert('Por favor, preencha todos os campos.');
        return;
    }

    // Objeto com os dados do cadastro
    let dadosCad = {
        id: 0,
        nome: String(nome),
        email: String(email),
        password: String(senha)
    };

    // Requisição à API usando o método fetch
    try {
        const resposta = await fetch('https://sua-api.com/api/usuario/cadastrar', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dadosCad)
        });

        if (resposta.ok) {
            try {
                const usuarioCadastrado = await resposta.json();
                console.log('Usuário cadastrado:', usuarioCadastrado);
            } catch (error) {
                console.error('Erro ao processar resposta da API. Erro ao analisar JSON:', error);
            }
        } else {
            console.error('Erro ao cadastrar:', resposta.statusText);
        }
    } catch (error) {
        console.error('Erro ao processar requisição:', error);
    }
}