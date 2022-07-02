import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ResourceAttributeDefineItemDto } from 'src/app/share/models/resource-attribute-define/resource-attribute-define-item-dto.model';

@Component({
  selector: 'app-dynamic-form-attribute',
  templateUrl: './dynamic-form-attribute.component.html',
  styleUrls: ['./dynamic-form-attribute.component.css']
})
export class DynamicFormAttributeComponent implements OnInit {
  @Input() attribute!: ResourceAttributeDefineItemDto;
  @Input() form!: FormGroup;
  constructor() { }

  get isValid() { return this.form.controls[this.attribute.name].valid; }
  ngOnInit(): void {
  }

}
