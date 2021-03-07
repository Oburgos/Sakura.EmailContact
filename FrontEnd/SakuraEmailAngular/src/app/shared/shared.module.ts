import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PageLayoutComponent } from './page-layout/page-layout.component';
import { MaterialModule } from '../material/material.module';
import { AutoCompleteComponent } from './auto-complete/auto-complete.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [PageLayoutComponent, AutoCompleteComponent],
  imports: [
    CommonModule,
    MaterialModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
  ],
  exports: [PageLayoutComponent, AutoCompleteComponent, MatAutocompleteModule],
})
export class SharedModule {}
