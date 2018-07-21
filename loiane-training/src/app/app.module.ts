import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MeuPrimeiro2Component } from './meu-primeiro2/meu-primeiro2.component';
import { MeuPrimeiroComponent } from './meu-primeiro/meu-primeiro.component';
import { CursosModule } from './cursos/cursos.module';
import { DataBindingComponent } from './data-binding/data-binding.component';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InputPropertyComponent } from './input-property/input-property.component';
import { OutputPropertyComponent } from './output-property/output-property.component';
import { CicloComponent } from './ciclo/ciclo.component';
import { DiretivasComponent } from './diretivas/diretivas.component';
import { NgifComponent } from './diretivas/ngif/ngif.component';
import { SwitchComponent } from './diretivas/switch/switch.component';
import { NgClassComponent } from './diretivas/ng-class/ng-class.component';
import { NgstyleComponent } from './diretivas/ngstyle/ngstyle.component';
import { ElvisComponent } from './elvis/elvis.component';
import { FundoAmareloDirective } from './shared/fundo-amarelo.directive';
import { DiretivasCustomComponent } from './diretivas-custom/diretivas-custom.component';
import { HighlightMouseDirective } from './shared/highlight-mouse.directive';
@NgModule({
  declarations: [
    AppComponent,
    MeuPrimeiro2Component,
    MeuPrimeiroComponent,
    DataBindingComponent,
    InputPropertyComponent,
    OutputPropertyComponent,
    CicloComponent,
    DiretivasComponent,
    NgifComponent,
    SwitchComponent,
    NgClassComponent,
    NgstyleComponent,
    ElvisComponent,
    FundoAmareloDirective,
    DiretivasCustomComponent,
    HighlightMouseDirective

  ],
  imports: [
    BrowserModule,
    CursosModule,
    TooltipModule.forRoot(),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
