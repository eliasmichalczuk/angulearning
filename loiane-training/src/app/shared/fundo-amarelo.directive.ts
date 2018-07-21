import { Directive, ElementRef, Renderer2 } from '@angular/core';

@Directive({
  selector: '[fundoAmarelo]'
  //p'[fundoAmarelo]' para aplicar apenas para paragrafos, assim por diante
})
export class FundoAmareloDirective {

  constructor(private _elementRef: ElementRef
              //private _renderer: Renderer2
            ) {
    console.log(this._elementRef);
    this._elementRef.nativeElement.style.backgroundColor =  "yellow";
    // this._renderer.setElementStyle(this._elementRef.nativeElement,
    //   'background-color','yellow');
    }

}
