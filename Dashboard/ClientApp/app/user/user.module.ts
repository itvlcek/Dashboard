import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from '../components/auth/login.component';
import { AuthGuard } from '../services/auth.guard';
 
import { UserService } from './user.service'
import { UserProfile } from './user.profile'    
 
@NgModule({
    imports: [
        RouterModule.forChild([
            { path: 'login', component: LoginComponent }
        ])
    ],
    declarations: [
        LoginComponent
    ],
    providers: [
        UserService,
        AuthGuard,
        UserProfile
    ]
})
export class UserModule { }