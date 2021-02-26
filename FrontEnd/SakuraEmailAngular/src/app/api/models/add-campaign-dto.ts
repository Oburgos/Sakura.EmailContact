/* tslint:disable */
/* eslint-disable */
import { AddEventDto } from './add-event-dto';
export interface AddCampaignDto {
  contactLists?: null | Array<number>;
  emailTemplateId: number;
  events?: null | Array<AddEventDto>;
  name: string;
}
