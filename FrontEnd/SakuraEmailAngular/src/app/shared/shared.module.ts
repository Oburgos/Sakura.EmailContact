import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PageLayoutComponent } from './page-layout/page-layout.component';
import { MaterialModule } from '../material/material.module';

@NgModule({
  declarations: [PageLayoutComponent],
  imports: [CommonModule, MaterialModule],
  exports: [PageLayoutComponent],
})
export class SharedModule {}
