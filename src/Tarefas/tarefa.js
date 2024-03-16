//Modal
const btnTarefa = document.getElementById("btnTarefa")
const modal = document.querySelector("dialog")
const btnCancelar = document.getElementById('cancelar')

btnTarefa.onclick = function (){
    modal.showModal()
};

btnCancelar.onclick = function (){
    modal.close()
}

//Tarefas
async function novaTask(){
    let novaTarefa = document.getElementById('tarefaInput').value;
    let categoria = document.querySelectorAll('.option span');
    let idTask = categoria.id

    let apiUrl = 'https://apiprojetotodo.azurewebsites.net/api/Tarefa'

    let token = sessionStorage.getItem(token);

    let dados = {
        ID: 0,
        Nome: 'Exemplo',
        Descricao: 'Exemplo de descrição',
        Status: '0', 
        UsuarioID: 11
    };


    try {
        let response = await fetch(apiUrl, {
            method: 'POST',
            headers: {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dados)
        });

        if (!response.ok) {
            throw new Error(`Erro ao tentar criar tarefa: ${response.statusText}`);
        }

        
    } catch (error) {
        console.error('Erro ao tentar criar tarefa: ', error);
    }
}

function editarTarefa(){
    let editTarefa = document.getElementById('editar')

    editTarefa.addEventListener("click", ()=>{
        //Abre o adicionar tarefa com os dados da tarefa para editar
        // Salva com as novas alterações
    })
}

function concluirTarefa(){
    let concTarefa = document.getElementById('concluido');
    let tarefaConcluida = document.querySelectorAll('.dinamicTask span')

    concTarefa.addEventListener("click", ()=>{
        tarefaConcluida.forEach(tarefa => {
            // Faz um risco no meio da descrição
        })

    })
}

function excluirTarefa(){
    let excTarefa = document.getElementById('excluir')

    excTarefa.addEventListener("click", ()=>{
        //Exclui a tarefa no banco e na visulização

    })
}




