import { NgModule } from '@angular/core';
import { ResourceRoutingModule } from './resource-routing.module';
import { ShareModule } from 'src/app/share/share.module';
import { ComponentsModule } from 'src/app/components/components.module';
import { IndexComponent } from './index/index.component';
import { DetailComponent } from './detail/detail.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { DynamicFormAttributeComponent } from './dynamic-form-attribute/dynamic-form-attribute.component';
import { AttributeControlService } from './dynamic-form-attribute/attribute-control.service';

@NgModule({
  declarations: [IndexComponent, DetailComponent, AddComponent, EditComponent, DynamicFormAttributeComponent],
  imports: [
    ComponentsModule,
    ShareModule,
    ResourceRoutingModule
  ],
  providers: [AttributeControlService]
})
export class ResourceModule { }
