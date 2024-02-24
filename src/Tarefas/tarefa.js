
// Cards de Tasks
/*const conteudoModal = `
    <div id="modal" class="modal">
        <div class="modal-dialog modal-dialog-centered">
            <div class= "containerTask">
                <h1 class="CreateH1">Nova Tarefa</h1>
                <div class="inputBox">
                    <label for="tarefaInput">Adicione a sua tarefa:</label>
                    <section class="input">
                        <input type="text" id="tarefaInput" placeholder="O que você vai fazer?" maxlength="22">
                        <button type="button" id="btnAdicionar">+</button>
                    </section>
                </div>

                <div class="btnAcao">
                    <button class="addTask" id="addTask" type="button">Adicionar Tarefa</button>
                    <button class="cancelar" id="cancelar" type="button">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
      
`
*/

const btnTarefa = document.getElementById("btnTarefa")
const modal = document.querySelector("dialog")
const btnCancelar = document.getElementById('cancelar')

btnTarefa.onclick = function (){
    modal.showModal()
};

btnCancelar.onclick = function (){
    modal.close()
}

