(function () {
const template1 = document.createElement('template');
template1.innerHTML = `
<style>
    @import url('https://fonts.googleapis.com/css?family=Roboto');
    #main {
        width: 100%;
    }
    #main:hover {
        cursor: pointer;
    }
    #main:hover>a #thumb img {
        opacity: 0.9;
        filter: saturate(2);
        transition: all 0.35s;

    }
    #toparea {
        background-color: rgb(56, 56, 56);
        box-shadow: inset 0px 0px 6px 2px #000;
        position: relative;
    }
    #thumb {
        width: 100%;
        display:block;
    }
    * {
        padding: 0;
        margin: 0;
    }
    a {
        text-decoration: none;
        color: black;
    }
    #colecao {
        margin-top: 6px;
    }
    h4 {
        font-family: 'Roboto', sans-serif;
        font-weight: 400;
        padding-top: 5px;
    }
    p {
        color: rgb(146, 146, 146);
        font-family: 'Roboto', sans-serif;
        font-size: 0.8rem;
        font-weight: 400;
        text-transform: none;
        line-height: 1rem;
    }
    #duration{
        position: absolute;
        top: 3px;
        right: 6px;
        background-color: black;
        color: white;
        padding: 2px 4px;
        font-size: 0.8rem;
        font-family: 'Roboto', sans-serif;
        border-radius: 3px;
    }
</style>
<div id="main">
    <a id="url" href="#">
        <div id="toparea">
            <img id="thumb" src="" />
            <div id="duration">5:02</div>
        </div>
        <h4 id="titulo">Venha pro Youtube</h4>
        <p id="collection">Youtube</p>
        <p id="views">Views: 12.342</p>
        <p id="data">Data: 3 meses</p>
    </a>
</div>
`;
const template2 = document.createElement('template');
template2.innerHTML = `
<style>
    @import url('https://fonts.googleapis.com/css?family=Roboto');
    #main {
        width: 100%;
    }
    #main:hover {
        cursor: pointer;
    }
    #main:hover>a #thumb img {
        opacity: 0.9;
        filter: saturate(2);
        transition: all 0.35s;

    }
    #sidearea {
        position: relative;
        width: 48%;

    }
    #info {
        width: 50%;
    }
    #thumb {
        width: 100%;
        display:block;
    }
    * {
        padding: 0;
        margin: 0;
    }
    a {
        text-decoration: none;
        color: black;
    }
    #colecao {
        margin-top: 6px;
    }
    h4 {
        font-family: 'Roboto', sans-serif;
        font-weight: 400;
        padding-top: 0px;
    }
    p {
        color: rgb(146, 146, 146);
        font-family: 'Roboto', sans-serif;
        font-size: 0.8rem;
        font-weight: 400;
        text-transform: none;
        line-height: 1rem;
    }
    #duration{
        position: absolute;
        top: 3px;
        right: 6px;
        background-color: black;
        color: white;
        padding: 2px 4px;
        font-size: 0.8rem;
        font-family: 'Roboto', sans-serif;
        border-radius: 3px;
    }
</style>
<div id="main">
    <a id="url" href="#" style="display:flex;justify-content: space-between ">
        <div id="sidearea" >
            <img id="thumb" src="" />
            <div id="duration">5:02</div>
        </div>
        <div id="info">
            <h4 id="titulo">Venha pro Youtube</h4>
            <p id="collection">Youtube</p>
            <p id="views">Views: 12.342</p>
            <p id="data">Data: 3 meses</p>
        </div>
    </a>
</div>
`;
class VideoCard extends HTMLElement{
    constructor(){
        super();
        //this.className += 'block';
        this.ExibirPreview = this.ExibirPreview.bind(this);
        this.ExibirThumb = this.ExibirThumb.bind(this);

    }
    ExibirPreview() {
        this.shadowRoot.querySelector("#thumb").setAttribute("src", "data/videos/" + this.getAttribute('hash') +"/preview.webp");
    }
    ExibirThumb() {
        this.shadowRoot.querySelector("#thumb").setAttribute("src", "data/videos/" + this.getAttribute('hash') +"/thumbnail.jpg");
    }
    connectedCallback(){
        var shadow = this.attachShadow({mode: 'open'});
        if(this.getAttribute('tipo')=='2'){shadow.appendChild(template2.content.cloneNode(true));}
        else {shadow.appendChild(template1.content.cloneNode(true));}
        shadow.querySelector("#titulo").innerHTML=this.getAttribute('titulo');
        var views =  toView(parseInt(this.getAttribute('views')));
        shadow.querySelector("#views").innerHTML=  views;
        shadow.querySelector("#url").setAttribute('href',"https://www.youtube.com/watch?v="+this.getAttribute('hash'));
        shadow.querySelector("#thumb").setAttribute("src", "data/videos/" + this.getAttribute('hash') +"/thumbnail.jpg");
        shadow.querySelector('#main').addEventListener("mouseover", this.ExibirPreview);
        shadow.querySelector('#main').addEventListener("mouseout", this.ExibirThumb);

        shadow.querySelector("#collection").innerHTML=this.getAttribute('collection');
        shadow.querySelector("#duration").innerHTML=this.getAttribute('duration');
        shadow.querySelector("#data").innerHTML=toDate(this.getAttribute('data'));
    }
    
}
window.customElements.define('video-card', VideoCard);
})();

function toDate(data){
    var datahoje = new Date();
    var datavideo = new Date(data);
    var difmins = Math.round((datahoje.getTime() - datavideo.getTime()) / 60000) ; // minutes

    if(difmins == 1){
        return "há " + difmins + " minuto"
    }
    if (difmins > 1 && difmins < 60){
        return "há " + difmins + " minutos"
    }
    if(difmins == 60 ){
        return "há " + Math.round(difmins/60) + " hora"
    }
    if(difmins > 60  && difmins < 60*24){
        return "há " + Math.round(difmins/60) + " horas"
    }
    if(difmins == 60*24 ){
        return "há " + Math.round(difmins/60/24) + " dia"
    }
    if(difmins > 60*24 && difmins < 60*24*7 ){
        return "há " + Math.round(difmins/60/24) + " dias"
    }
    if(difmins ==  60*24*7){
        return "há " + Math.round(difmins/60/24/7) + " semana"
    }
    if(difmins >  60*24*7 && difmins <60*24*30){
        return "há " +Math.round(difmins/60/24/7) + " semanas"
    }
    if(difmins ==  60*24*30){
        return "há " +Math.round(difmins/60/24/30) + " mês"
    }
    if(difmins > 60*24*30 && difmins <  60*24*30*12 + 5){
        return "há " +Math.round(difmins/60/24/30) + " meses"
    }
    if(difmins ==  60*24*30*12 + 5){
        return "há " +Math.round(difmins/60/24/30/12) + " ano"
    }
    if(difmins > 60*24*30*12 + 5 ){
        return "há " +Math.round(difmins/60/24/30/12) + " anos"
    }
}
function toView(num) {
    var tam = num.toString().length;
    if (tam < 4) {
        return "Views: " + num;
    }
    else if(tam >= 4 && tam < 7) {
        return "Views: " + Math.round(num / 1000).toString() + ' mil';
    }
    else if(tam >= 7 && tam < 10) {
        return "Views: " + Math.round(num / 1000000).toString() + ' mi';
    }
    else if(tam >= 10) {
        return "Views: " + Math.round(num / 1000000000).toString() + ' bi';
    }
}

