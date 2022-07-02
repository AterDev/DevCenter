import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ResourceAttributeDefineItemDto } from 'src/app/share/models/resource-attribute-define/resource-attribute-define-item-dto.model';

@Injectable()
export class AttributeControlService {
  constructor() { }

  toFormGroup(attributes: ResourceAttributeDefineItemDto[]) {
    const group: any = {};

    attributes.forEach(attribute => {
      group[attribute.name] = attribute.required ? new FormControl(attribute.value || null, Validators.required)
        : new FormControl(attribute.value || null);
    });
    return new FormGroup(group);
  }
}
