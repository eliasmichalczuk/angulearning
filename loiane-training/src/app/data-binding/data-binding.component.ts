import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-data-binding',
  templateUrl: './data-binding.component.html',
  styleUrls: ['./data-binding.component.css']
})
export class DataBindingComponent implements OnInit {

  valorInicial = 10;
  url = 'http://www.loiane.com';
  urlImg = 'https://images.pexels.com/photos/257360/pexels-photo-257360.jpeg?auto=compress&cs=tinysrgb&h=350';
  cursoAngular = true;
  nomeDoCurso: string = 'Angular';
  valorAtual:string="";
  valorSalvo:string="";
  nome:string="";
  getValor(){
    return 1;
  }

  botaoClicado(){
    alert('botao clicado');
  }

  salvarValor(valor){
    this.valorSalvo=valor;
  }

  onKeyUp(evento: KeyboardEvent){
      console.log();
      this.valorAtual = ((<HTMLInputElement>evento.target).value);

  }
  getCurtirCurso(){
    return true;
  }
  constructor() { }

  ngOnInit() {
  }

}
