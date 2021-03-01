import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-campaign-form',
  templateUrl: './campaign-form.component.html',
  styleUrls: ['./campaign-form.component.scss'],
})
export class CampaignFormComponent implements OnInit {
  templateForm: FormGroup;
  contactListsForm: FormGroup;
  campaignForm: FormGroup;

  constructor(private _formBuilder: FormBuilder) {
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

  ngOnInit() {}
}
