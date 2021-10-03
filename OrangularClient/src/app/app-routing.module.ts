import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BasketPageComponent } from './basket-page/basket-page.component';
import { CategoryPageComponent } from './category-page/category-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { SearchPageComponent } from './search-page/search-page.component';
import { ProductComponent } from './admin/product/product.component';
import { UserComponent } from './admin/user/user.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { CategoryComponent } from './admin/category/category.component';
import { HomePageComponent } from './home-page/home-page.component';
import { NewuserPageComponent } from './newuser-page/newuser-page.component';

const routes: Routes = [
  {path: 'category/:categoryName', component: CategoryPageComponent},
  {path: 'search', component: SearchPageComponent},
  {path: 'login', component: LoginPageComponent},
  {path: 'profile', component: ProfilePageComponent},
  {path: 'product/:productName', component: ProductPageComponent},
  {path: 'basket', component: BasketPageComponent},
  {path: 'admin/product', component: ProductComponent},
  {path: 'admin/user', component: UserComponent},
  {path: "admin/category", component: CategoryComponent},
  {path: "", component: HomePageComponent},
  {path: "newuser", component: NewuserPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
