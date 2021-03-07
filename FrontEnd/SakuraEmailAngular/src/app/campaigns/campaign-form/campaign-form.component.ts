import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatStepper } from '@angular/material/stepper';
import { EmailTemplateBuilderComponent } from 'src/app/email-templates/email-template-builder/email-template-builder.component';

@Component({
  selector: 'app-campaign-form',
  templateUrl: './campaign-form.component.html',
  styleUrls: ['./campaign-form.component.scss'],
})
export class CampaignFormComponent implements OnInit {
  @ViewChild('templateBuilder', { static: true })
  templateBuilder!: EmailTemplateBuilderComponent;

  @ViewChild('stepper', { static: true })
  stepper!: MatStepper;

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

  tabContactNexClick() {
    let template = this.templateBuilder.getData();
    this.templateForm.controls.html.setValue(template.html);
    this.templateForm.controls.mjml.setValue(template.mjml);
    this.stepper.next();
  }

  ngOnInit() {
    this.templateForm.patchValue({
      contacts: 'Mary',
    });
  }
}
