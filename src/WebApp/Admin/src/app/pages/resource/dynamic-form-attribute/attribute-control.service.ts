import { Attribute, Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ResourceAttributeDefineItemDto } from 'src/app/share/models/resource-attribute-define/resource-attribute-define-item-dto.model';
import { ResourceAttributeAddDto } from 'src/app/share/models/resource-attribute/resource-attribute-add-dto.model';
import { ResourceAttribute } from 'src/app/share/models/resource-attribute/resource-attribute.model';

@Injectable()
export class AttributeControlService {
  attributeFormGroup: FormGroup = new FormGroup({});
  defines: ResourceAttributeDefineItemDto[] = [];
  constructor() { }

  buildAttributeForm(attributes: ResourceAttributeDefineItemDto[]): void {
    this.defines = attributes;
    attributes.forEach(attribute => {
      this.attributeFormGroup.addControl(attribute.name, attribute.required ? new FormControl(attribute.value || null, Validators.required)
        : new FormControl(attribute.value || null));
    });

  }

  getAttributes(): ResourceAttributeAddDto[] {
    let res = [];
    let formValue = this.attributeFormGroup.value;
    const keys = Object.keys(formValue);

    for (const key of keys) {
      let define = this.defines.find((val) => val.name === key);
      if (define) {
        let attribute: ResourceAttributeAddDto = {
          displayName: define?.displayName,
          name: define.name,
          value: formValue[key],
          sort: 0,
        }
        res.push(attribute);
      };
    }
    return res;
  }
}
