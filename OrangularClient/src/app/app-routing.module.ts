import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BasketPageComponent } from './basket-page/basket-page.component';
import { CategoryPageComponent } from './category-page/category-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { SearchPageComponent } from './search-page/search-page.component';
import { ProductComponent } from './admin/product/product.component';
import { UserComponent } from './admin/user/user.component';
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
import { ProfilePageComponent } from './profile-page/profile-page.component';
>>>>>>> c80d4d7f0af2939cb7646a293995410547021010
=======
>>>>>>> 0fbac8d49a5c9e64132c05dfe2d286d579d56b34

import { CategoryComponent } from './admin/category/category.component';

const routes: Routes = [
  {path: 'categories', component: CategoryPageComponent},
  {path: 'search', component: SearchPageComponent},
  {path: 'login', component: LoginPageComponent},
  {path: 'profile', component: ProfilePageComponent},
  {path: 'product', component: ProductPageComponent},
  {path: 'basket', component: BasketPageComponent},
  {path: 'admin/product', component: ProductComponent},
  {path: 'admin/user', component: UserComponent},
  {path: "admin/category", component: CategoryComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
