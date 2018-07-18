import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-ngstyle',
  templateUrl: './ngstyle.component.html',
  styleUrls: ['./ngstyle.component.css']
})
export class NgstyleComponent implements OnInit {

  ativo = false;

  mudarAtivo(){
    this.ativo=!this.ativo;
  }

  constructor() { }

  ngOnInit() {
  }

}
