import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainContainerComponent, PanelComponent, ProductContainerComponent, AdminUserListComponent, AboutUsComponent, OrderComponent, PrivacyPolicyComponent } from './components';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, 
    MainContainerComponent, 
    ProductContainerComponent,
    PanelComponent,
    AboutUsComponent,
    PrivacyPolicyComponent,
    OrderComponent,
    AdminUserListComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'HoneyStoreUI';
}
