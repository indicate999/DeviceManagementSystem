import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DevicesService } from 'src/app/_services/devices.service';
import { Device } from 'src/app/_models/device';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { AddDeviceModalComponent } from '../modals/add-device-modal/add-device-modal.component';
import { EditDeviceModalComponent } from '../modals/edit-device-modal/edit-device-modal.component';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit{

  devices: Device[] = [];
  addDeviceBsModalRef: BsModalRef<AddDeviceModalComponent> = new BsModalRef<AddDeviceModalComponent>();
  editDeviceBsModalRef: BsModalRef<EditDeviceModalComponent> = new BsModalRef<EditDeviceModalComponent>();

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
    this.addDeviceBsModalRef = this.modalService.show(AddDeviceModalComponent);

    this.addDeviceBsModalRef.content!.deviceAdded.subscribe(() => {
      this.loadDevices();
    });
  }

  openEditDeviceModal(deviceID: number) {
    const initialState = { deviceData: this.devices[deviceID]};

    this.editDeviceBsModalRef = this.modalService.show(EditDeviceModalComponent, { initialState });

    this.editDeviceBsModalRef.content!.deviceEditted.subscribe(() => {
      this.loadDevices();
    });
  }
}



