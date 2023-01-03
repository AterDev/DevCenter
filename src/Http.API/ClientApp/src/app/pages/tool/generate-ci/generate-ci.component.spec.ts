import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenerateCIComponent } from './generate-ci.component';

describe('GenerateCIComponent', () => {
  let component: GenerateCIComponent;
  let fixture: ComponentFixture<GenerateCIComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GenerateCIComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GenerateCIComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
