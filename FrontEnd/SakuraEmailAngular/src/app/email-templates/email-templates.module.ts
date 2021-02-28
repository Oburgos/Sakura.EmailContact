import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmailTemplateBuilderComponent } from './email-template-builder/email-template-builder.component';

@NgModule({
  declarations: [EmailTemplateBuilderComponent],
  imports: [CommonModule],
  exports: [EmailTemplateBuilderComponent],
})
export class EmailTemplatesModule {}
