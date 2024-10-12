import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DevicesService } from 'src/app/_services/devices.service';
import { Device } from 'src/app/_models/device';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { AddModalComponent } from '../modals/add-modal/add-modal.component';
import { AddDeviceModalComponent } from '../modals/add-device-modal/add-device-modal.component';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit{

  devices: Device[] = [];
  bsModalRef: BsModalRef<AddDeviceModalComponent> = new BsModalRef<AddDeviceModalComponent>();

  constructor(private devicesService: DevicesService, private modalService: BsModalService) {}

  ngOnInit(): void {
    this.loadDevices();
  }

  loadDevices(): void {
    this.devicesService.getDevices().subscribe((data: Device[]) => {
      this.devices = data;
    });
  }
 
  openAddDeviceModal() {
    this.bsModalRef = this.modalService.show(AddDeviceModalComponent);

    this.bsModalRef.content!.deviceAdded.subscribe(() => {
      this.loadDevices();
    });
  }
}



