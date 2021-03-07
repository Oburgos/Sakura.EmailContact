import { SelectionModel } from '@angular/cdk/collections';
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ContactListDto } from 'src/app/api/models';
import { ContactsService } from 'src/app/api/services';

@Component({
  selector: 'app-contact-lists-table',
  templateUrl: './contact-lists-table.component.html',
  styleUrls: ['./contact-lists-table.component.scss'],
})
export class ContactListsTableComponent implements OnInit {
  displayedColumns: string[] = ['select', 'id', 'name'];
  data: ContactListDto[] = [];
  constructor(private contactsService: ContactsService) {}

  async ngOnInit() {
    this.load();
  }

  async load() {
    this.data = await this.contactsService
      .apiContactsListsGet$Json()
      .toPromise();

    this.dataSource.data = this.data;
  }

  selection = new SelectionModel<ContactListDto>(true, []);
  dataSource = new MatTableDataSource<ContactListDto>(this.data);

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected()
      ? this.selection.clear()
      : this.dataSource.data.forEach((row) => this.selection.select(row));
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: ContactListDto): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row `;
  }
}
