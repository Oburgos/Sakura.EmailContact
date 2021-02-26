import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactFormComponent } from './contacts/contact-form/contact-form.component';
import { ContactsTableComponent } from './contacts/contacts-table/contacts-table.component';
import { ContactsPageComponent } from './contacts/contacts-page/contacts-page.component';
import { ContactsRoutingModule } from './contacts-routing.module';
import { SharedModule } from '../shared/shared.module';
import { MaterialModule } from '../material/material.module';
import { MatTableModule } from '@angular/material/table';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ContactFormComponent,
    ContactsTableComponent,
    ContactsPageComponent,
  ],
  imports: [
    CommonModule,
    ContactsRoutingModule,
    SharedModule,
    MaterialModule,
    MatTableModule,
    ReactiveFormsModule,
  ],
})
export class ContactsModule {}
