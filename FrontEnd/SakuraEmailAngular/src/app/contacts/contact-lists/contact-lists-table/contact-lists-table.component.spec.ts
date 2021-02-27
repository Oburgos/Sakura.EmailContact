import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactListsTableComponent } from './contact-lists-table.component';

describe('ContactListsTableComponent', () => {
  let component: ContactListsTableComponent;
  let fixture: ComponentFixture<ContactListsTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContactListsTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactListsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
