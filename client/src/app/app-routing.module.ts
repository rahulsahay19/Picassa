import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { PostPictureComponent } from './post-picture/post-picture.component';
import { AuthGuardService } from './services/auth-guard.service';
import { ListPicturesComponent } from './list-pictures/list-pictures.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'post', component: PostPictureComponent, canActivate: [AuthGuardService] },
  { path: 'pictures', component: ListPicturesComponent, canActivate: [AuthGuardService] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
