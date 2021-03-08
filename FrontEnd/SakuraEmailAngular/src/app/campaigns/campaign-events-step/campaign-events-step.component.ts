import { Component, OnInit, ViewChild } from '@angular/core';
import { NgxMaterialTimepickerComponent } from 'ngx-material-timepicker';

@Component({
  selector: 'app-campaign-events-step',
  templateUrl: './campaign-events-step.component.html',
  styleUrls: ['./campaign-events-step.component.scss'],
})
export class CampaignEventsStepComponent implements OnInit {
  @ViewChild('timePicker', { static: true })
  timePicker!: NgxMaterialTimepickerComponent;

  startDate = new Date();
  constructor() {}

  ngOnInit(): void {
    this.timePicker.open();
  }
}
