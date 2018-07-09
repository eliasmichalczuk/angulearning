import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-data-binding',
  templateUrl: './data-binding.component.html',
  styleUrls: ['./data-binding.component.css']
})
export class DataBindingComponent implements OnInit {

  url = 'http://www.loiane.com';
  urlImg = 'https://vignette.wikia.nocookie.net/twicenation/images/b/b9/Acuvue_Define_Twice_3.jpg/revision/latest?cb=20180416053523';
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
