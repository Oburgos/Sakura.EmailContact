import {
  AfterViewInit,
  Component,
  ElementRef,
  OnInit,
  ViewChild,
} from '@angular/core';
import 'grapesjs/dist/css/grapes.min.css';
// @ts-ignore
import grapesJS from 'grapesjs';
// @ts-ignore
import grapesJSMJML from 'grapesjs-mjml';

@Component({
  selector: 'app-email-template-builder',
  templateUrl: './email-template-builder.component.html',
  styleUrls: ['./email-template-builder.component.scss'],
})
export class EmailTemplateBuilderComponent implements OnInit, AfterViewInit {
  @ViewChild('gjs', { static: true }) gjs!: ElementRef;

  constructor() {}

  ngOnInit(): void {}

  ngAfterViewInit(): void {
    this.crearControl();
  }

  crearControl(): void {
    this.gjs.nativeElement.innerHTML =
      '<mjml><mj-body><mj-section><mj-column></mj-column></mj-section></mj-body></mjml>';

    grapesJS.init({
      fromElement: 1,
      container: '#gjs',
      avoidInlineStyle: false,
      plugins: [grapesJSMJML],
      pluginsOpts: {
        [grapesJSMJML]: {
          /* ...options */
        },
      },
    });
  }
}
