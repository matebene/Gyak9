var viccek;
function letöltés() {
    fetch('/jokes.json')
        .then(response => response.json())
        .then(data =>letöltésBefejeződött(data))
};
function letöltésBefejeződött(d) {
    console.log("Sikeres letöltés");
    console.log(d);
    viccek = d;
    let ide = document.getElementById("ide");
    for (var i = 0; i < viccek.length; i++) {
        let elem = document.createElement("li");
        elem.innerHTML = viccek[i].text;
        ide.appendChild(elem);
    }
}
window.onload = function () {
    letöltés();
};