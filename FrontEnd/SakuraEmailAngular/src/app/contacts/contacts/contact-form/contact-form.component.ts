import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { ContactsService } from 'src/app/api/services';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.scss'],
})
export class ContactFormComponent implements OnInit {
  form: FormGroup;
  isLoading: boolean = false;
  apiError?: string;

  constructor(
    private builder: FormBuilder,
    private contactsService: ContactsService,
    public dialogRef: MatDialogRef<ContactFormComponent>
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
      email: [
        '',
        [Validators.required, Validators.email, Validators.maxLength(100)],
      ],
    });
  }

  async submit() {
    if (this.form.invalid) {
      return;
    }

    try {
      this.apiError = undefined;

      let body = {
        body: this.form.getRawValue(),
      };

      this.isLoading = true;

      let response = await this.contactsService
        .apiContactsPost$Json(body)
        .toPromise();

      this.dialogRef.close(response);
    } catch (error) {
      this.isLoading = false;
      this.apiError = error.error.message;
      console.warn(error);
    }
  }

  ngOnInit(): void {}

  getErrorMessage(controlName: string) {
    let control = this.form.controls[controlName];
    if (control.hasError('required')) {
      return 'Required field';
    }

    if (controlName == 'email' && control.hasError('email')) {
      return 'Not a valid email';
    }

    if (controlName == 'email' && control.hasError('maxLength')) {
      return 'The max length is 100';
    }

    if (controlName == 'name' && control.hasError('maxLength')) {
      return 'The max length is 100';
    }

    if (controlName == 'name' && control.hasError('minLength')) {
      return 'The min length is 3';
    }

    return '';
  }
}
