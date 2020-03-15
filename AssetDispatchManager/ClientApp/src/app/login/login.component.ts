import { Component } from "@angular/core";
import { User } from "../login/user";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
    title: 'Log In';
    user: User = {
        username: 'Keegs',
        password: 'bloop2'
    }
}
