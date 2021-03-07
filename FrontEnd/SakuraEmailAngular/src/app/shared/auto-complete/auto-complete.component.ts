import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';

export interface User {
  name: string;
}

@Component({
  selector: 'app-auto-complete',
  templateUrl: './auto-complete.component.html',
  styleUrls: ['./auto-complete.component.scss'],
})
export class AutoCompleteComponent implements OnInit {
  private currentValue: any;

  @Input() control: AbstractControl = new FormControl();

  internalControl = new FormControl();
  @Input() propertyValue: string = '';
  @Input() displayProperty: string = '';

  @Input() label: string = 'example';
  @Input() class: string = '';
  @Input() placeholder: string = 'example';

  @Input() options: any[] = [];
  filteredOptions: Observable<any[]>;
  constructor() {
    this.filteredOptions = this.internalControl.valueChanges.pipe(
      startWith(''),
      map((value) =>
        typeof value === 'string' ? value : value[this.displayProperty]
      ),
      map((name) => (name ? this._filter(name) : this.options.slice()))
    );

    this.internalControl.valueChanges.subscribe((e) => {
      this.currentValue = this.options.find(
        (i) => i[this.displayProperty] == e
      );

      if (!this.currentValue) {
        this.control.setValue(null);
        return;
      }

      if (this.propertyValue == '') {
        this.control.setValue(this.currentValue);
      } else {
        this.control.setValue(this.currentValue[this.propertyValue]);
      }
    });
  }

  ngOnInit() {
    this.control.valueChanges.subscribe((v) => {
      console.log(v);

      if (!this.currentValue) {
        return;
      }

      if (this.currentValue[this.propertyValue] != v) {
        this.setExternalControlValue();
      }
    });

    this.setExternalControlValue();
  }

  setExternalControlValue() {
    if (!this.control.value || !this.options.length) {
      return;
    }

    this.currentValue = this.options.find(
      (i) => i[this.propertyValue] == this.control.value
    );

    this.internalControl.setValue(this.currentValue[this.displayProperty]);
  }

  private _filter(name: string): User[] {
    const filterValue = name.toLowerCase();
    return this.options.filter(
      (option) =>
        option[this.displayProperty].toLowerCase().indexOf(filterValue) === 0
    );
  }
}
