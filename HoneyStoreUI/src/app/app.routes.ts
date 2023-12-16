import { Routes, mapToCanActivate } from '@angular/router';
import { AboutUsComponent, AdminProductListComponent, AdminUserListComponent, LoginComponent, OrderComponent, PanelComponent, PrivacyPolicyComponent, ProductContainerComponent, ProductDetailComponent, RegisterComponent } from './components';

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
      path: 'order',
      component: OrderComponent
    },
    {
      path: 'about-us',
      component: AboutUsComponent
    },
    {
      path: 'privacy-policy',
      component: PrivacyPolicyComponent
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
