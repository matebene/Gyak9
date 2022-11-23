window.onload = function () {
    var faktorialis = function (n) {
        let er = 1;
        for (let i = 2; i <= n; i++){
            er = er * i
        }
        return er;
    }
    let n = 0;
    for (var sor = 0; sor < 10; sor++) {

        for (var oszlop = 0; oszlop <= sor; oszlop++) {
            var ujsor = document.createElement("div");
            ujsor.classList.add("sor");
            pascal.appendChild(ujsor);
            for (var oszlop = 0; oszlop <= sor; oszlop++) {
                let ertek = faktorialis(sor) / (faktorialis(oszlop) * faktorialis(sor - oszlop));
                var ujelem = document.createElement("div");
                ujelem.classList.add("elem");
                ujelem.innerHTML = ertek;
                ujsor.appendChild(ujelem);
            }
        }
}


}