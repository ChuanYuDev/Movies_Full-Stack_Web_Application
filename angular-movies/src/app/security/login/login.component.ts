import {Component, inject} from '@angular/core';
import {SecurityService} from "../security.service";
import {Router} from "@angular/router";
import {UserCredentialsDto} from "../security.models";
import {extractIdentityErrors} from "../../shared/functions/extractErrors";
import {DisplayErrorsComponent} from "../../shared/components/display-errors/display-errors.component";
import {AuthenticationFormComponent} from "../authentication-form/authentication-form.component";

@Component({
    selector: 'app-login',
    imports: [DisplayErrorsComponent, AuthenticationFormComponent],
    templateUrl: './login.component.html',
    styleUrl: './login.component.css'
})
export class LoginComponent {
    securityService = inject(SecurityService);
    router = inject(Router);
    errors: string[] = [];

    login(userCredentialsDto: UserCredentialsDto) {
        this.securityService.login(userCredentialsDto).subscribe({
            next: () => {
                this.router.navigate(["/"]);
            },

            error: err => {
                this.errors = extractIdentityErrors(err);
            }
        });
    }
}
