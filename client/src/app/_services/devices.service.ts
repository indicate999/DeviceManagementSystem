import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Device } from '../_models/device';

@Injectable({
  providedIn: 'root'
})
export class DevicesService {

  constructor(private http: HttpClient) { }

  getDevices() {
    return this.http.get<Device[]>('http://localhost:5272/api/devices');
  }
}
