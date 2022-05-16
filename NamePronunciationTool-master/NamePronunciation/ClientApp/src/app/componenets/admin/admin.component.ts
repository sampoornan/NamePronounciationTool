import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  
  displayedColumns: string[] = ['employeeId', 'employeeName', 'path'];
  dataSource = ELEMENT_DATA;

  constructor() { }

  ngOnInit(): void {

   
  }

  txtEditToggle(event: any){
      
  }

  Save(){
    
  }

}


export interface EmployeeData {
  employeeId: number;
  employeeName: string;
  path: string;
}

const ELEMENT_DATA: EmployeeData[] = [
  {employeeId: 1, employeeName: 'Madhu', path: "../local/voice1"},
  {employeeId: 2, employeeName: 'Sampoorna', path: '../local/voice2'},
  {employeeId: 3, employeeName: 'Sadhana', path: '../local/voice3'}
];


