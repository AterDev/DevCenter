import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DynamicFormAttributeComponent } from './dynamic-form-attribute.component';

describe('DynamicFormAttributeComponent', () => {
  let component: DynamicFormAttributeComponent;
  let fixture: ComponentFixture<DynamicFormAttributeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DynamicFormAttributeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DynamicFormAttributeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
