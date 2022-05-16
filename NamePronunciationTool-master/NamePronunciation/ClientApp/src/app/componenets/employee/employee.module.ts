import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeComponent } from './employee.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,

    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatSelectModule
  ]
})
export class EmployeeModule { }
