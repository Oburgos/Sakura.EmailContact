import {
  AfterViewInit,
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import 'grapesjs/dist/css/grapes.min.css';
// @ts-ignore
import grapesJS from 'grapesjs';
// @ts-ignore
import grapesJSMJML from 'grapesjs-mjml';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-email-template-builder',
  templateUrl: './email-template-builder.component.html',
  styleUrls: ['./email-template-builder.component.scss'],
})
export class EmailTemplateBuilderComponent
  implements OnInit, AfterViewInit, OnDestroy {
  @ViewChild('gjs', { static: true }) gjs!: ElementRef;
  grapes: any = {};
  constructor() {}

  ngOnDestroy(): void {
    localStorage.removeItem('gjs-components');
    this.grapes.destroy();
  }

  ngOnInit(): void {}

  checkInfo() {
    let html = this.grapes.runCommand('mjml-get-code');
    let mjml = this.grapes.getHtml();
    console.log(html, mjml);
  }

  ngAfterViewInit(): void {
    this.crearControl();
  }

  crearControl(): void {
    localStorage.removeItem('gjs-components');
    this.gjs.nativeElement.innerHTML = `
    <mjml>
       <mj-body>
           <mj-section>
              <mj-column>
                <mj-button id="iu1o">Button</mj-button>
              </mj-column>
           </mj-section>
        </mj-body>
     </mjml>`;

    this.grapes = grapesJS.init({
      fromElement: 1,
      container: '#gjs',
      avoidInlineStyle: false,
      plugins: [grapesJSMJML],
      assetManager: {
        upload: environment.Api + '/api/common/images/upload',
        uploadName: 'files',
        credentials: 'omit',
      },
      pluginsOpts: {
        [grapesJSMJML]: {},
      },
    });
  }
}
