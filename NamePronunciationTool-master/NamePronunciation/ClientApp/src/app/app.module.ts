import { NgModule } from '@angular/core';
import { BrowserModule, BrowserTransferStateModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { EmployeeComponent } from './componenets/employee/employee.component';
import { EmployeeModule } from './componenets/employee/employee.module';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AdminComponent } from './componenets/admin/admin.component';
import { NameTranslationComponent } from './componenets/name-translation/name-translation.component';
import { NameTranslationModule } from './componenets/name-translation/name-translation.module';
import { MatTabsModule } from '@angular/material/tabs';
import { AdminModule } from './componenets/admin/admin.module';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import {MatTableModule} from '@angular/material/table';

@NgModule({
  declarations: [
    AdminComponent,
    EmployeeComponent,
    NameTranslationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,

    MatTabsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatSelectModule,
    MatTableModule,


    NameTranslationModule,
    ReactiveFormsModule,
    AdminModule,
    EmployeeModule
  ],
  providers: [],
  bootstrap: [NameTranslationComponent]
})
export class AppModule { }
