import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DevicesComponent } from './_components/devices/devices.component';

import { ModalModule } from 'ngx-bootstrap/modal';
import { AddModalComponent } from './_components/modals/add-modal/add-modal.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddDeviceModalComponent } from './_components/modals/add-device-modal/add-device-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    DevicesComponent,
    AddModalComponent,
    AddDeviceModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
