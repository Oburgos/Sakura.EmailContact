import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-contact-lists-page',
  templateUrl: './contact-lists-page.component.html',
  styleUrls: ['./contact-lists-page.component.scss'],
})
export class ContactListsPageComponent implements OnInit {
  showForm = false;
  editMode = false;
  constructor(private activatedRoute: ActivatedRoute) {
    let id = this.activatedRoute.snapshot.queryParamMap.get('id');
    if (id != null) {
      this.showForm = true;
    }
  }

  ngOnInit(): void {}
}
