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
import { ContactListFormComponent } from './contact-lists/contact-list-form/contact-list-form.component';
import { ContactListsPageComponent } from './contact-lists/contact-lists-page/contact-lists-page.component';
import { ContactListsTableComponent } from './contact-lists/contact-lists-table/contact-lists-table.component';

@NgModule({
  declarations: [
    ContactFormComponent,
    ContactsTableComponent,
    ContactsPageComponent,
    ContactListFormComponent,
    ContactListsPageComponent,
    ContactListsTableComponent,
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
