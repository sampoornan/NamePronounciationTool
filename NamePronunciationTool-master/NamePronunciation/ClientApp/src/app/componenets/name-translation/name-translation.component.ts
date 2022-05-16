import { Component, OnInit } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';

@Component({
  selector: 'app-name-translation',
  templateUrl: './name-translation.component.html',
  styleUrls: ['./name-translation.component.scss']
})
export class NameTranslationComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  selectedTabChange(event: MatTabChangeEvent){
    
  }

}
