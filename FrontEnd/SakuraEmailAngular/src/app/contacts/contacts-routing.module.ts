import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContactListsPageComponent } from './contact-lists/contact-lists-page/contact-lists-page.component';
import { ContactsPageComponent } from './contacts/contacts-page/contacts-page.component';

const routes: Routes = [
  {
    path: '',
    component: ContactsPageComponent,
  },
  {
    path: 'lists',
    component: ContactListsPageComponent,
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ContactsRoutingModule {}
