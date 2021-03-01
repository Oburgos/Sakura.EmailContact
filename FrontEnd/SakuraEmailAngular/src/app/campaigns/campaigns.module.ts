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

@NgModule({
  declarations: [CampaignFormComponent, CampaignsPageComponent],
  imports: [
    CommonModule,
    SharedModule,
    CampaignsRoutingModule,
    MatStepperModule,
    ReactiveFormsModule,
    MaterialModule,
    EmailTemplatesModule,
  ],
})
export class CampaignsModule {}
