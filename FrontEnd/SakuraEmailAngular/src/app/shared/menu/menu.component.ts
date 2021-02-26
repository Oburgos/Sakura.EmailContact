import { Component, OnInit } from '@angular/core';
import { MenuItem } from './menu-item.model';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent implements OnInit {
  menu: MenuItem[] = [
    {
      title: 'Contacts',
      icon: 'contacts',
      options: [
        {
          icon: 'group_add',
          title: 'Lists',
          link: '',
        },
      ],
    },
    {
      title: 'Campaigns',
      icon: 'mark_email_read',
      options: [
        {
          icon: 'subject',
          title: 'All',
          link: '',
        },
        {
          icon: 'schedule_send',
          title: 'New',
          link: '',
        },
      ],
    },
  ];
  constructor() {}

  ngOnInit(): void {}
}
