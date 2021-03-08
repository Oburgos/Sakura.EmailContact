import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CampaignEventsStepComponent } from './campaign-events-step.component';

describe('CampaignEventsStepComponent', () => {
  let component: CampaignEventsStepComponent;
  let fixture: ComponentFixture<CampaignEventsStepComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CampaignEventsStepComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CampaignEventsStepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
