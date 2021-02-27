import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactListsPageComponent } from './contact-lists-page.component';

describe('ContactListsPageComponent', () => {
  let component: ContactListsPageComponent;
  let fixture: ComponentFixture<ContactListsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContactListsPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactListsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
