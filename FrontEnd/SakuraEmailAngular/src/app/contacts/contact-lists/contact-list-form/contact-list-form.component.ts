import { SelectionModel } from '@angular/cdk/collections';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import {
  AddContactListDto,
  ContactDto,
  ContactListDto,
} from 'src/app/api/models';
import { ContactsService } from 'src/app/api/services';

@Component({
  selector: 'app-contact-list-form',
  templateUrl: './contact-list-form.component.html',
  styleUrls: ['./contact-list-form.component.scss'],
})
export class ContactListFormComponent implements OnInit {
  @Output() onCancel: EventEmitter<any> = new EventEmitter();
  @Output() onSave: EventEmitter<ContactListDto> = new EventEmitter();

  title = 'New List Of Contacts';
  form: FormGroup;
  isLoading: boolean = false;
  editMode: boolean = false;
  id: number = 0;

  setEditMode() {
    this.id = this.activatedRoute.snapshot.queryParamMap.get('id') as any;
    if (this.id == null) {
      return;
    }

    this.editMode = true;
    this.loadContactList();
  }

  async loadContactList() {
    let data = await this.contactsService
      .apiContactsListsIdGet$Json({ id: this.id })
      .toPromise();
    this.form.patchValue(data);
    let ids = data.contacts?.map((i) => i.id as number);
    let values = this.dataSource.data.filter((e) =>
      ids?.includes(e.id as number)
    );
    this.selection.select(...values);
  }

  constructor(
    private activatedRoute: ActivatedRoute,
    private builder: FormBuilder,
    private contactsService: ContactsService
  ) {
    this.form = builder.group({
      id: [0],
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(100),
        ],
      ],
    });
  }

  async ngOnInit() {
    await this.loadContacts();
    this.setEditMode();
  }

  async loadContacts() {
    this.data = await this.contactsService.apiContactsGet$Json().toPromise();
    this.dataSource.data = this.data;
  }

  getErrorMessage(controlName: string) {
    let control = this.form.controls[controlName];
    if (control.hasError('required')) {
      return 'Required field';
    }

    if (controlName == 'name' && control.hasError('maxLength')) {
      return 'The max length is 100';
    }

    if (controlName == 'name' && control.hasError('minLength')) {
      return 'The min length is 3';
    }

    return '';
  }

  async submit() {
    if (this.form.invalid) {
      return;
    }
    try {
      this.isLoading = true;
      let addDto: AddContactListDto = {
        name: this.form.controls.name.value,
        contactIds: [],
      };

      addDto.contactIds = this.selection.selected.map((e) => e.id as number);
      let response = await this.contactsService
        .apiContactsListsPost$Json({ body: addDto })
        .toPromise();

      console.log(response);
      this.isLoading = false;
      this.onSave.emit(response);
    } catch (error) {
      this.isLoading = false;

      console.warn(error);
    }
  }

  cancelClick() {
    this.onCancel.emit();
  }

  data: ContactDto[] = [];
  displayedColumns: string[] = ['select', 'name', 'email'];
  selection = new SelectionModel<ContactDto>(true, []);
  dataSource = new MatTableDataSource<ContactDto>(this.data);

  //https://material.angular.io/components/table/examples#table-selection
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
  checkboxLabel(row?: ContactDto): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row `;
  }
}
