import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

//feature module imports
import { AuthModule } from './auth/auth.module';
import { HeaderComponent } from './shared/components/header/header.component';

import { AdminModule } from './admin/admin.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    AdminModule //To test design
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
