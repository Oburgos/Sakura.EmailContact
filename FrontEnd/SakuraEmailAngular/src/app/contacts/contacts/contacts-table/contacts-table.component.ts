import { Component, OnInit } from '@angular/core';
import { ContactDto } from 'src/app/api/models';
import { ContactsService } from 'src/app/api/services';

@Component({
  selector: 'app-contacts-table',
  templateUrl: './contacts-table.component.html',
  styleUrls: ['./contacts-table.component.scss'],
})
export class ContactsTableComponent implements OnInit {
  displayedColumns: string[] = ['name', 'email'];
  data: ContactDto[] = [];
  constructor(private contactsService: ContactsService) {}

  ngOnInit(): void {
    this.load();
  }

  async load() {
    this.data = await this.contactsService.apiContactsGet$Json().toPromise();
  }
}
