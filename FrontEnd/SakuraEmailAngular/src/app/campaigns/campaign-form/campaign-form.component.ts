import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatStepper } from '@angular/material/stepper';
import { SwalComponent } from '@sweetalert2/ngx-sweetalert2';
import { ContactDto, ContactListDto } from 'src/app/api/models';
import { ContactsService } from 'src/app/api/services';
import { EmailTemplateBuilderComponent } from 'src/app/email-templates/email-template-builder/email-template-builder.component';
import { ContactListsTableComponent } from '../contact-lists-table/contact-lists-table.component';

@Component({
  selector: 'app-campaign-form',
  templateUrl: './campaign-form.component.html',
  styleUrls: ['./campaign-form.component.scss'],
})
export class CampaignFormComponent implements OnInit {
  @ViewChild('templateBuilder', { static: true })
  templateBuilder!: EmailTemplateBuilderComponent;

  @ViewChild('contactListTable', { static: true })
  contactListTable!: ContactListsTableComponent;

  @ViewChild('stepper', { static: true })
  stepper!: MatStepper;

  @ViewChild('infoSwal')
  public readonly infoSwal!: SwalComponent;

  templateForm: FormGroup;
  contactListsForm: FormGroup;
  campaignForm: FormGroup;
  contactLists: ContactListDto[] = [];

  constructor(
    private _formBuilder: FormBuilder,
    private contactsService: ContactsService
  ) {
    this.templateForm = this._formBuilder.group({
      subject: ['', Validators.required],
      html: ['', Validators.required],
      mjml: ['', Validators.required],
    });

    this.contactListsForm = this._formBuilder.group({
      contacts: ['', Validators.required],
    });

    this.campaignForm = this._formBuilder.group({
      name: ['', Validators.required],
      events: [[], Validators.required],
    });
  }

  tabTemplateNexClick() {
    let template = this.templateBuilder.getData();
    this.templateForm.controls.html.setValue(template.html);
    this.templateForm.controls.mjml.setValue(template.mjml);
    this.stepper.next();
  }

  tabContactListNexClick() {
    let lists = this.contactListTable.selection.selected;
    if (lists.length == 0) {
      this.infoSwal.fire();
      return;
    }
    this.contactListsForm.controls.contacts.setValue(lists);
    this.stepper.next();
  }

  async loadListsOfContacts() {
    this.contactLists = await this.contactsService
      .apiContactsListsGet$Json()
      .toPromise();
  }

  async ngOnInit() {
    await this.loadListsOfContacts();
    // this.templateForm.patchValue({
    //   contacts: 'Mary',
    // });
  }
}
