import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DevicesComponent } from './_components/devices/devices.component';

import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddDeviceModalComponent } from './_components/modals/add-device-modal/add-device-modal.component';
import { EditDeviceModalComponent } from './_components/modals/edit-device-modal/edit-device-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    DevicesComponent,
    AddDeviceModalComponent,
    EditDeviceModalComponent
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
