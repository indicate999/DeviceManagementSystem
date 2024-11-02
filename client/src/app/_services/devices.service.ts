import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Device } from '../_models/device';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DevicesService {
  private apiUrl = 'http://localhost:5272/api/devices';
  
  constructor(private http: HttpClient) { }

  public getDevices(): Observable<Device[]> {
    return this.http.get<Device[]>(this.apiUrl);
  }

  public addDevice(device: Device): Observable<Device> {
    return this.http.post<Device>(this.apiUrl, device);
  }

  public editDevice(device: Device): Observable<Device> {
    return this.http.put<Device>(this.apiUrl, device);
  }

  public deleteDevice(id: number) {
    return this.http.delete<number>(`${this.apiUrl}/${id}`);
  }
}
