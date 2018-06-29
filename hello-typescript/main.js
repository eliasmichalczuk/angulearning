var minhaVar = 'minha variavel';
function minhaFunc(x, y) {
    return x + y;
}
//es6
var num = 2;
var PI = 3.14;
var numeros = [1, 2, 3];
numeros.map(function (valor) {
    return valor * 2;
});
numeros.map(function (valor) {
    valor * 2;
});
//ou
numeros.map(function (valor) { return valor * 2; }); //es6
//transpieler ex: babel transpiler ec6 em vanilla js
var Matematica = /** @class */ (function () {
    function Matematica() {
    }
    Matematica.prototype.soma = function (x, y) {
        return x + y;
    };
    return Matematica;
}());
var n1 = 'sdssd';
n1 = 4;
