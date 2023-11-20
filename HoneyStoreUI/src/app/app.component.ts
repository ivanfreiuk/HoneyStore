import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainContainerComponent, PanelComponent, ProductContainerComponent, AdminUserListComponent } from './components';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, 
    MainContainerComponent, 
    ProductContainerComponent,
    PanelComponent,
    AdminUserListComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'HoneyStoreUI';
}
