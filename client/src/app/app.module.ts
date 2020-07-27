import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { PostPictureComponent } from './post-picture/post-picture.component';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { ListPicturesComponent } from './list-pictures/list-pictures.component';
import { PictureDetailsComponent } from './picture-details/picture-details.component';
import { EditPictureComponent } from './edit-picture/edit-picture.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    PostPictureComponent,
    ListPicturesComponent,
    PictureDetailsComponent,
    EditPictureComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
