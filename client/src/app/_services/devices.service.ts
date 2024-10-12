import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Device } from '../_models/device';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DevicesService {

  constructor(private http: HttpClient) { }

  public getDevices(): Observable<Device[]> {
    return this.http.get<Device[]>('http://localhost:5272/api/devices');
  }

  public addDevice(device: Device): Observable<Device> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Device>('http://localhost:5272/api/devices', device, { headers });//.subscribe(response => {
     //console.log(response);
    //}); 
  }
}
