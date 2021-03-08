import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CampaignFormComponent } from './campaign-form/campaign-form.component';
import { CampaignsPageComponent } from './campaigns-page/campaigns-page.component';
import { SharedModule } from '../shared/shared.module';
import { CampaignsRoutingModule } from './campaigns-routing.module';
import { MatStepperModule } from '@angular/material/stepper';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../material/material.module';
import { EmailTemplatesModule } from '../email-templates/email-templates.module';
import { ContactListsTableComponent } from './contact-lists-table/contact-lists-table.component';
import { MatTableModule } from '@angular/material/table';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { CampaignEventsStepComponent } from './campaign-events-step/campaign-events-step.component';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';

@NgModule({
  declarations: [
    CampaignFormComponent,
    CampaignsPageComponent,
    ContactListsTableComponent,
    CampaignEventsStepComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    CampaignsRoutingModule,
    MatStepperModule,
    ReactiveFormsModule,
    MaterialModule,
    EmailTemplatesModule,
    MatTableModule,
    SweetAlert2Module,
    NgxMaterialTimepickerModule,
  ],
})
export class CampaignsModule {}
