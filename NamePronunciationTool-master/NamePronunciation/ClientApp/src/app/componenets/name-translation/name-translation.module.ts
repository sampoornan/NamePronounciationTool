import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeModule } from '../employee/employee.module';
import { AdminModule } from '../admin/admin.module';
import { MatTabsModule } from '@angular/material/tabs';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { NameTranslationComponent } from './name-translation.component';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatTabsModule,
    MatFormFieldModule,
    MatInputModule,
    EmployeeModule,
    AdminModule
  ]
})
export class NameTranslationModule { }
