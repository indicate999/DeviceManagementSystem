import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string = "fff";

  devices: Device[] = [
    { brand: "Apple", manufacturer: "Apple Inc.", modelName: "MacBook Pro", operatingSystem: "macOS" },
    { brand: "Dell", manufacturer: "Dell Technologies", modelName: "XPS 13", operatingSystem: "Windows 11" },
    { brand: "HP", manufacturer: "Hewlett-Packard", modelName: "Spectre x360", operatingSystem: "Windows 11" },
    { brand: "Lenovo", manufacturer: "Lenovo Group", modelName: "ThinkPad X1 Carbon", operatingSystem: "Windows 11" },
    { brand: "Microsoft", manufacturer: "Microsoft", modelName: "Surface Laptop 4", operatingSystem: "Windows 11" },
    { brand: "Asus", manufacturer: "ASUSTeK Computer Inc.", modelName: "ZenBook 14", operatingSystem: "Windows 11" },
    { brand: "Acer", manufacturer: "Acer Inc.", modelName: "Swift 3", operatingSystem: "Windows 11" },
    { brand: "Apple", manufacturer: "Apple Inc.", modelName: "iMac 24\"", operatingSystem: "macOS" },
    { brand: "Sony", manufacturer: "Sony Corporation", modelName: "PlayStation 5", operatingSystem: "Custom OS" },
    { brand: "Microsoft", manufacturer: "Microsoft", modelName: "Xbox Series X", operatingSystem: "Custom OS" },
    { brand: "Nintendo", manufacturer: "Nintendo", modelName: "Switch", operatingSystem: "Custom OS" },
    { brand: "Alienware", manufacturer: "Dell Technologies", modelName: "Alienware m15", operatingSystem: "Windows 11" },
    { brand: "Razer", manufacturer: "Razer Inc.", modelName: "Razer Blade 15", operatingSystem: "Windows 11" },
    { brand: "MSI", manufacturer: "MSI", modelName: "MSI GS66", operatingSystem: "Windows 11" },
    { brand: "Gigabyte", manufacturer: "Gigabyte Technology", modelName: "Aero 15", operatingSystem: "Windows 11" },
    { brand: "Samsung", manufacturer: "Samsung Electronics", modelName: "Galaxy Book Pro", operatingSystem: "Windows 11" },
    { brand: "Apple", manufacturer: "Apple Inc.", modelName: "Mac Mini", operatingSystem: "macOS" },
    { brand: "Valve", manufacturer: "Valve Corporation", modelName: "Steam Deck", operatingSystem: "SteamOS" },
    { brand: "LG", manufacturer: "LG Electronics", modelName: "Gram 17", operatingSystem: "Windows 11" },
    { brand: "HP", manufacturer: "Hewlett-Packard", modelName: "Omen 15", operatingSystem: "Windows 11" }
  ];
  
}

type Device = {
  brand: string;
  manufacturer: string;
  modelName: string;
  operatingSystem: string;
};
