export interface MenuItem {
  title: string;
  icon: string;
  options: Array<MenuItemLink>;
}

export interface MenuItemLink {
  title: string;
  icon: string;
  link: string;
}
