//CALENDARIO
const dataAtual = document.querySelector(".dataAtual"),
tagDias = document.querySelector(".dias"),
prevNextIcones = document.querySelectorAll(".icones span");


// Pegando as datas atuais
let data = new Date(),
anoAtual = data.getFullYear(),
mesAtual = data.getMonth();

const meses = ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"]

const gerarCalendario = () =>{
    let primeiroDiaDoMes = new Date(anoAtual, mesAtual, 1).getDay();
    let ultimoDiaDoMes = new Date(anoAtual, mesAtual + 1, 0).getDate();
    let ultimoDia = new Date(anoAtual, mesAtual, ultimoDiaDoMes).getDay();
    let ultimoDiaDoMesPassado = new Date(anoAtual, mesAtual, 0).getDate();
    let liTag = "";

    for (let i = primeiroDiaDoMes; i > 0; i--) {
        liTag += `<li class="inativo">${ultimoDiaDoMesPassado - i + 1}</li>`; //Previa dos dias dos meses anteriores 
    }

    
    for (let i = 1; i <= ultimoDiaDoMes; i++) {
        let hoje = (i === data.getDate() && mesAtual === data.getMonth() && anoAtual === data.getFullYear()) ? "ativo" : "";
        liTag += `<li class="${hoje}">${i}</li>`; //Marca o dia atual
    }
    
    

    for (let i = ultimoDia + 1; i <= 6; i++) {
        liTag += `<li class="inativo">${i - ultimoDia}</li>`; // Prévia dos dias dos meses posteriores
    }
    

    dataAtual.innerHTML = `${meses[mesAtual]} ${anoAtual}`;
    tagDias.innerHTML = liTag
}

gerarCalendario();

Array.from(prevNextIcones).forEach(icone => {
    icone.addEventListener("click", () => {
        mesAtual = icone.id === "voltar" ? mesAtual - 1 : mesAtual + 1;

        if (mesAtual < 0) {
            anoAtual--;
            mesAtual = 11; // Dezembro
        } else if (mesAtual > 11) {
            anoAtual++;
            mesAtual = 0; // Janeiro
        }

        data = new Date(anoAtual, mesAtual);
        gerarCalendario();
    });
});

