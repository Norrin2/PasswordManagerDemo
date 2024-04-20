import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { PasswordCardComponent } from "./components/password-card/password-card.component";
import { PasswordCardFormComponent } from "./components/password-card-form/password-card-form.component";
import { MatIconModule } from '@angular/material/icon'
import { MatButtonModule } from '@angular/material/button'
import { MatCardModule } from '@angular/material/card'
import { MatInputModule } from '@angular/material/input'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClipboardModule } from "@angular/cdk/clipboard";

@NgModule({
    declarations: [
        AppComponent,
        PasswordCardFormComponent,
        PasswordCardComponent
    ],
    providers: [],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        MatIconModule,
        MatButtonModule,
        MatCardModule,
        MatInputModule,
        BrowserAnimationsModule,
        ClipboardModule
    ]
})
export class AppModule { }
