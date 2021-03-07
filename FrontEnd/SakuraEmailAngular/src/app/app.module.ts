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
import { SharedModule } from './shared/shared.module';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';

@NgModule({
  declarations: [AppComponent, MenuComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    SharedModule,
    SweetAlert2Module.forRoot(),
    ApiModule.forRoot({ rootUrl: environment.Api }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
