import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ContactFormComponent } from '../contact-form/contact-form.component';
import { ContactsTableComponent } from '../contacts-table/contacts-table.component';

@Component({
  selector: 'app-contacts-page',
  templateUrl: './contacts-page.component.html',
  styleUrls: ['./contacts-page.component.scss'],
})
export class ContactsPageComponent implements OnInit {
  @ViewChild(ContactsTableComponent) table!: ContactsTableComponent;

  constructor(public dialog: MatDialog) {}

  ngOnInit(): void {}

  openAddContactDialog() {
    const dialogRef = this.dialog.open(ContactFormComponent);
    dialogRef.afterClosed().subscribe((result) => {
      if (result == null) {
        return;
      }

      this.refreshContacts();
    });
  }

  refreshContacts() {
    this.table.load();
  }
}
