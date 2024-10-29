import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Device } from 'src/app/_models/device';
import { DevicesService } from 'src/app/_services/devices.service';

@Component({
  selector: 'app-add-device-modal',
  templateUrl: './add-device-modal.component.html',
  styleUrls: ['./add-device-modal.component.css']
})
export class AddDeviceModalComponent implements OnInit {
  @Output() deviceAdded = new EventEmitter<void>();

  title = 'Add device';
  closeBtnName = 'Close';
  deviceForm!: FormGroup;

  constructor(public bsModalRef: BsModalRef, private devicesService: DevicesService) {}

  ngOnInit(): void {
    this.deviceForm = new FormGroup({
      brand: new FormControl('', [Validators.required, Validators.minLength(3)]),
      manufacturer: new FormControl('', [Validators.required, Validators.minLength(2)]),
      model: new FormControl('', [Validators.required, Validators.minLength(2)]),
      operatingSystem: new FormControl('', [Validators.required, Validators.minLength(2)])
    });
  }

  onSubmit() {
    if (this.deviceForm.valid) {
      

      const formValues = this.deviceForm.value;

      const device: Device = {
        brand: formValues.brand,
        manufacturer: formValues.manufacturer,
        modelName: formValues.model,
        operatingSystem: formValues.operatingSystem
      };

      this.addDevice(device);

      this.bsModalRef.hide();
    }
  }

  addDevice(device: Device) {
    this.devicesService.addDevice(device).subscribe( response => {
      this.deviceAdded.emit();
    });
  }
}
