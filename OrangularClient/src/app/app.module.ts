import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './_navigation/header/header.component';
import { FooterComponent } from './_navigation/footer/footer.component';
import { CategoryPageComponent } from './category-page/category-page.component';
import { SearchPageComponent } from './search-page/search-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { BasketPageComponent } from './basket-page/basket-page.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { UserComponent } from './admin/user/user.component';
import { ProductComponent } from './admin/product/product.component';
import { ProductDetailComponent } from './product-page/product-detail/product-detail.component';
//import { ProductEditComponent } from './product-page/product-edit/product-edit.component';

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
    ProductDetailComponent,
    // ProductEditComponent
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
