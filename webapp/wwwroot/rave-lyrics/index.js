var quadro = document.getElementById("app");
var lapis = quadro.getContext('2d');
var MX = quadro.height;
var MY = quadro.width;
var CX = (MX / 2);
var CY = (MY / 2);
var modos = ["center", "spread"];
var angle = 0;

function desenhar(event) {
  /* captura a tecla pressionada */
  let tecla = event.key;
  /* Escreve a tecla na caixa de texto */
  /* Limpa a tela do canvas */
  if(tecla == " "){
    lapis.fillStyle = '#000';
    lapis.fillRect(0, 0, MY, MX);
  }
  /* seleciona um modo aleatório */
  // let modo = (Math.random() * modos.length);
  /* gera um tamanho aleatório válido */
  let size = ((Math.random() * 128) + 128);
  /* gera coordenada aleatória válida */
  let posX = (Math.random() * (MX - size));
  let posY = (Math.random() * (MY - size));
  //let posX = MX / 2;
  //let posY = MY / 2;
  /* gera uma cor aleatória */
  let cor = Math.random() * 360;
  let inv = (cor >= 180) ? (cor - 180) : (cor + 180);
  /* gira ou não a letra  */
  // let grau = (Math.random() * 24);
  // lapis.rotate((Math.PI / 180) * grau);
  /* desenha a letra pressionada*/
  lapis.fillStyle = `hsl(${cor}, 100%, 50%)`;
  lapis.font = `${size}px arial`;
  lapis.textAlign = "center";
  lapis.fillText(tecla, posX, posY); // argumentos (tecla, posX,posY)
  /* limpa tela preta */
  // lapis.fillStyle = '#000';
  // lapis.fillRect(0, 0, MY, MX);
  /*, gira a letra */
  // lapis.translate(CX, CY);
  // lapis.rotate(angle * (Math.PI / 180));
  // context.translate(-CX, -CY);
  /* desenha em negativo */
  // lapis.fillStyle = `hsl(${inv}, 100%, 50%)`;
  // lapis.fillText(tecla, posX, posY); // (tecla, posX,posY +(size/2))
  /* linhas horizontais e verticais no centro */
  // lapis.strokeStyle = '#FFF';
  // lapis.beginPath();
  // lapis.moveTo(0, CY);
  // lapis.lineTo(MX, CY);
  // lapis.stroke();
  // lapis.beginPath();
  // lapis.moveTo(CX, 0);
  // lapis.lineTo(CX, MY);
  // lapis.stroke();
  angle++;
}

document.addEventListener("keypress", desenhar);
