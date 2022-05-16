import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NameTranslationComponent } from './name-translation.component';

describe('NameTranslationComponent', () => {
  let component: NameTranslationComponent;
  let fixture: ComponentFixture<NameTranslationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NameTranslationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NameTranslationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
