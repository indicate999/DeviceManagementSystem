import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Device } from 'src/app/_models/device';
import { DevicesService } from 'src/app/_services/devices.service';

@Component({
  selector: 'app-edit-device-modal',
  templateUrl: './edit-device-modal.component.html',
  styleUrls: ['./edit-device-modal.component.css']
})
export class EditDeviceModalComponent implements OnInit {
  @Input() deviceData!: Device;
  //@Input() deviceId!: number;
  @Output() deviceEditted = new EventEmitter<void>();

  title = 'Edit device';
  closeBtnName = 'Close';
  editDeviceForm!: FormGroup;

  constructor(public bsModalRef: BsModalRef, private devicesService: DevicesService) {}

  ngOnInit(): void {
    this.editDeviceForm = new FormGroup({
      brand: new FormControl(this.deviceData.brand, [Validators.required, Validators.minLength(3)]),
      manufacturer: new FormControl(this.deviceData.manufacturer, [Validators.required, Validators.minLength(2)]),
      model: new FormControl(this.deviceData.modelName, [Validators.required, Validators.minLength(2)]),
      operatingSystem: new FormControl(this.deviceData.operatingSystem, [Validators.required, Validators.minLength(2)])
    });

    this.editDeviceForm.valueChanges.subscribe(() => {
      var formValues = this.editDeviceForm.value;
      if (formValues.brand == this.deviceData.brand && formValues.manufacturer == this.deviceData.manufacturer
        && formValues.model == this.deviceData.modelName && formValues.operatingSystem == this.deviceData.operatingSystem
      ) {
        this.editDeviceForm.markAsPristine();
      }
    });
  }

  onSubmit() {
    if (this.editDeviceForm.valid) {
      const formValues = this.editDeviceForm.value;

      const device: Device = {
        id: this.deviceData.id,
        brand: formValues.brand,
        manufacturer: formValues.manufacturer,
        modelName: formValues.model,
        operatingSystem: formValues.operatingSystem
      };

      this.editDevice(device);

      this.bsModalRef.hide();
    }
  }

  editDevice(device: Device) {
    this.devicesService.editDevice(device).subscribe( response => {
      this.deviceEditted.emit();
    });
  }
}
