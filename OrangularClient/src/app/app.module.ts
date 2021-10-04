import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HomePageComponent } from './home-page/home-page.component';
import { HeaderComponent } from './_global/header/header.component';
import { FooterComponent } from './_global/footer/footer.component';

import { CategoryPageComponent } from './category-page/category-page.component';
import { CategoryComponent } from './admin/category/category.component';

import { ProductPageComponent } from './product-page/product-page.component';
import { ProductComponent } from './admin/product/product.component';

import { SearchPageComponent } from './search-page/search-page.component';
import {BasketPageComponent} from './basket-page/basket-page.component';

import { LoginPageComponent } from './login-page/login-page.component';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { NewuserPageComponent } from './newuser-page/newuser-page.component';
import { UserComponent } from './admin/user/user.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { OrderViewComponent } from './admin/order-view/order-view.component';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    CategoryPageComponent,
    SearchPageComponent,
    LoginPageComponent,
    RegistrationPageComponent,
    BasketPageComponent,
    ProductPageComponent,
    UserComponent,
    ProductComponent,
    CategoryComponent,
    ProfilePageComponent,
    HomePageComponent,
    NewuserPageComponent,
    OrderViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }