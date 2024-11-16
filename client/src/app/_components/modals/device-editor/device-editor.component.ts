import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Device } from 'src/app/_models/device';
import { DevicesService } from 'src/app/_services/devices.service';

@Component({
  selector: 'app-device-editor',
  templateUrl: './device-editor.component.html',
  styleUrls: ['./device-editor.component.css']
})
export class DeviceEditorComponent {
  @Input() deviceData?: Device;
  @Input() title!: string;
  @Input() closeBtnName!: string;
  @Input() submitBtnName!: string;

  @Output() deviceEdited = new EventEmitter<void>();

  deviceForm!: FormGroup;

  constructor(public bsModalRef: BsModalRef, private devicesService: DevicesService) {}

  ngOnInit(): void {
    this.deviceForm = new FormGroup({
      brand: new FormControl(this.deviceData?.brand ?? '', [Validators.required, Validators.minLength(2)]),
      manufacturer: new FormControl(this.deviceData?.manufacturer ?? '', [Validators.required, Validators.minLength(2)]),
      model: new FormControl(this.deviceData?.modelName ?? '', [Validators.required, Validators.minLength(2)]),
      operatingSystem: new FormControl(this.deviceData?.operatingSystem ?? '', [Validators.required, Validators.minLength(2)])
    });
  }

  onSubmit() {
    if (this.deviceForm.valid) {
      
      const formValues = this.deviceForm.value;

      const device: Device = {
        id: this.deviceData?.id ?? 0,
        brand: formValues.brand,
        manufacturer: formValues.manufacturer,
        modelName: formValues.model,
        operatingSystem: formValues.operatingSystem
      };

      if (this.deviceData == null)
        this.addDevice(device);
      else
        this.editDevice(device);

      this.bsModalRef.hide();
    }
  }

  addDevice(device: Device) {
    this.devicesService.addDevice(device).subscribe( response => {
      this.deviceEdited.emit();
    });
  }

  editDevice(device: Device) {
    this.devicesService.editDevice(device).subscribe( response => {
      this.deviceEdited.emit();
    });
  }
}
