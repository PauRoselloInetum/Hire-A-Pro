import { Component } from '@angular/core';
import { NgxLeafletModule } from 'ngx-leaflet';
import { LeafletModule } from '@bluehalo/ngx-leaflet';
import { tileLayer, latLng } from 'leaflet';

@Component({
  selector: 'app-map-screen-component',
  standalone: true,
  imports: [NgxLeafletModule, LeafletModule],
  templateUrl: './map-screen-component.component.html',
  styleUrl: './map-screen-component.component.css'
})
export class MapScreenComponent {
  options = {
    layers: [
      tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 18, attribution: '...' })
    ],
    zoom: 5,
    center: latLng(46.879966, -121.726909)
  };
}

