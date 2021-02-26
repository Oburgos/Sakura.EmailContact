/* tslint:disable */
/* eslint-disable */
import { ContactListDto } from './contact-list-dto';
import { EventDto } from './event-dto';
export interface CampaignDto {
  contactLists?: null | Array<ContactListDto>;
  events?: null | Array<EventDto>;
  id?: number;
  name?: null | string;
}
