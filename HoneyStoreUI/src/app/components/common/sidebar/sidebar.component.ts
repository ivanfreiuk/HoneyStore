import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTabsModule } from '@angular/material/tabs';
import { CartComponent } from '../../cart/cart/cart.component';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, MatTabsModule, CartComponent],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {

}
