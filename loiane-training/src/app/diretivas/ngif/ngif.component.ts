import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-ngif',
  templateUrl: './ngif.component.html',
  styleUrls: ['./ngif.component.css']
})
export class NgifComponent implements OnInit {

  cursos: string[] =["Angular"];

  mostrarCursos = false;

  onMostrarCursos(){
    this.mostrarCursos = !this.mostrarCursos;
  }

  constructor() { }

  ngOnInit() {
  }

}
