import { Component, OnInit } from '@angular/core';
import { ContactListDto } from 'src/app/api/models';
import { ContactsService } from 'src/app/api/services';

@Component({
  selector: 'app-contact-lists-table',
  templateUrl: './contact-lists-table.component.html',
  styleUrls: ['./contact-lists-table.component.scss'],
})
export class ContactListsTableComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'action'];
  expandedElement: any = {};
  data: ContactListDto[] = [];
  constructor(private contactsService: ContactsService) {}

  ngOnInit(): void {
    this.load();
  }

  async load() {
    this.data = await this.contactsService
      .apiContactsListsGet$Json()
      .toPromise();
  }
}
