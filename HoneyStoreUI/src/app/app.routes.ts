import { Routes, mapToCanActivate } from '@angular/router';
import { AuthGuard } from '../app/quards'
import { AdminProductListComponent, AdminUserListComponent, LoginComponent, PanelComponent, ProductContainerComponent, ProductDetailComponent, RegisterComponent } from './components';

export const routes: Routes = [
    {
        path: '',
        component: ProductContainerComponent,
        // canActivate: [AuthGuard]
        
      },
    {
        path: 'products',
        component: ProductContainerComponent
    },
    {
        path: 'detail/:id',
        component: ProductDetailComponent
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'register',
        component: RegisterComponent
        //canActivate: mapToCanActivate([AuthGuard])
    },
    {
        path: 'panel',
        component: PanelComponent,
        children: [
           {
             path: 'products',
             component: AdminProductListComponent
           },
           {
            path: 'users',
            component: AdminUserListComponent
          }
        //   {
        //     path: 'edit-book',
        //     component: EditBookComponent
        //   },
        //   {
        //     path: 'product-list',
        //     component: BooksMainPageComponent
        //   },
    
        ]
      },
  // otherwise redirect to home
 // { path: '**', redirectTo: '/home', pathMatch: 'full' }
];
