import { Component, OnInit } from '@angular/core';
import { DevicesService } from 'src/app/_services/devices.service';
import { Device } from 'src/app/_models/device';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { DeviceEditorComponent } from '../modals/device-editor/device-editor.component';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit{

  devices: Device[] = [];
  deviceBsModalRef: BsModalRef<DeviceEditorComponent> = new BsModalRef<DeviceEditorComponent>();

  constructor(private devicesService: DevicesService, private modalService: BsModalService) {}

  ngOnInit(): void {
    this.loadDevices();
  }

  loadDevices(): void {
    this.devicesService.getDevices().subscribe((data: Device[]) => {
      this.devices = data;
    });
  }
 
  openAddDeviceEditor() {
    const initialState = { title: "Add device", closeBtnName: "Cancel", submitBtnName: "Add" };

    this.openDeviceEditor(initialState);
  }

  openUpdateDeviceEditor(deviceID: number) {
    const initialState = { deviceData: this.devices[deviceID],
      title: "Edit device", closeBtnName: "Cancel", submitBtnName: "Save" };

    this.openDeviceEditor(initialState);
  }

  openDeviceEditor(initialState: any) {
    this.deviceBsModalRef = this.modalService.show(DeviceEditorComponent, { initialState } );

    this.deviceBsModalRef.content!.deviceEdited.subscribe(() => {
      this.loadDevices();
    });
  }

  deleteDevice(device: Device, event: Event) {
    event.stopPropagation();
    this.devicesService.deleteDevice(device.id).subscribe( response => {
      this.loadDevices();
    });
  }
}



