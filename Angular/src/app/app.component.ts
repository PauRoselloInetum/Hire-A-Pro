import { Component } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from './auth.service';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { VerificationComponent } from './verification/verification.component';
import { HttpClientModule } from '@angular/common/http';
import { MapScreenComponent } from './map-screen-component/map-screen-component.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    LoginComponent,
    VerificationComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    HttpClientModule,
    MapScreenComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [AuthService],
})
export class AppComponent {
  loading: string = '';
  email: string = '';
  error: string = '';
  info: string = '';

  constructor(
    private authservice: AuthService,
    private cookieService: CookieService,
  ) {}

  ngOnInit() {
    this.authservice.email$.subscribe((email) => {
      this.email = email;
    });
    this.authservice.loading$.subscribe((loading) => {
      this.loading = loading;
    });
  }

  validateSession() {
    const session = this.cookieService.get('token');
    this.authservice.validateSession(session);
    this.error = this.authservice.error;
    this.info = this.authservice.info;
  }
}
