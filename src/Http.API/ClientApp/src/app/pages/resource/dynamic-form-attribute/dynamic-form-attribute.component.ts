import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ResourceAttributeDefineItemDto } from 'src/app/share/models/resource-attribute-define/resource-attribute-define-item-dto.model';
import { AttributeControlService } from './attribute-control.service';

@Component({
  selector: 'app-dynamic-form-attribute',
  templateUrl: './dynamic-form-attribute.component.html',
  styleUrls: ['./dynamic-form-attribute.component.css']
})
export class DynamicFormAttributeComponent implements OnInit {
  form: FormGroup;
  @Input() defines!: ResourceAttributeDefineItemDto[];
  constructor(
    private attributeControlSrv: AttributeControlService,
  ) {
    this.form = this.attributeControlSrv.attributeFormGroup;
  }
  isValid(name: string) { return this.form.controls[name].valid; }
  ngOnInit(): void {
    this.form = this.attributeControlSrv.attributeFormGroup;
  }
}
