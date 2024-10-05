import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DevicesService } from 'src/app/_services/devices.service';
import { Device } from 'src/app/_models/device';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { AddModalComponent } from '../modals/add-modal/add-modal.component';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit{

  devices: Device[] = [];
  bsModalRef: BsModalRef<AddModalComponent> = new BsModalRef<AddModalComponent>();

  constructor(private devicesService: DevicesService, private modalService: BsModalService) {}

  ngOnInit(): void {
    this.devicesService.getDevices().subscribe((data: Device[]) => {
      this.devices = data;
    });
  }

  openAddModal() {
    const initialState: ModalOptions = {
      initialState: {
        title: 'Add device'
      }
    }
    this.bsModalRef = this.modalService.show(AddModalComponent, initialState);
    this.bsModalRef.content!.closeBtnName = 'Close';
  }
}



