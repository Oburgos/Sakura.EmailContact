import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { MenuComponent } from './shared/menu/menu.component';
import { PageLayoutComponent } from './shared/page-layout/page-layout.component';
import { HttpClientModule } from '@angular/common/http';
import { ApiModule } from './api/api.module';
import { environment } from 'src/environments/environment';

@NgModule({
  declarations: [AppComponent, MenuComponent, PageLayoutComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    ApiModule.forRoot({ rootUrl: environment.Api }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
