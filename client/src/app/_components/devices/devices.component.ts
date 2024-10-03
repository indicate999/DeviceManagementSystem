import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DevicesService } from 'src/app/_services/devices.service';
import { Device } from 'src/app/_models/device';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit{


  devices: Device[] = [];

  constructor(private devicesService: DevicesService) {}

  ngOnInit(): void {
    this.devicesService.getDevices().subscribe((data: Device[]) => {
      this.devices = data;
    });
  }
}



