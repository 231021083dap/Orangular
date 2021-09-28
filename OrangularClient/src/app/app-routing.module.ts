import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BasketPageComponent } from './basket-page/basket-page.component';
import { CategoryPageComponent } from './category-page/category-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { SearchPageComponent } from './search-page/search-page.component';
<<<<<<< HEAD
import { ProductComponent } from './admin/product/product.component';
=======
import { UserComponent } from './admin/user/user.component';

>>>>>>> 2b52267aa313599aac918da69251eb50125e023d

const routes: Routes = [
  {path: 'categories', component: CategoryPageComponent},
  {path: 'search', component: SearchPageComponent},
  {path: 'login', component: LoginPageComponent},
  {path: 'product', component: ProductPageComponent},
  {path: 'basket', component: BasketPageComponent},
<<<<<<< HEAD
  {path: 'admin', component: AdminPanelComponent},
  {path: 'admin/product', component: ProductComponent}
=======
  {path: 'admin/user', component: UserComponent}
>>>>>>> 2b52267aa313599aac918da69251eb50125e023d
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
