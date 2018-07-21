import { Directive, HostListener, ElementRef, Renderer } from '@angular/core';

@Directive({
  selector: '[highlightMouse]'
})
export class HighlightMouseDirective {

  @HostListener('mouseenter') onMouseOver(){
    this._renderer.setElementStyle(this._elementRef.nativeElement,
      'background-color', 'yellow');
  }

  constructor(private _elementRef: ElementRef,
              private _renderer: Renderer) { }

}
