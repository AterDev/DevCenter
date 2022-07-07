import { NgModule } from '@angular/core';
import { RoleRoutingModule } from './role-routing.module';
import { ShareModule } from 'src/app/share/share.module';
import { ComponentsModule } from 'src/app/components/components.module';
import { IndexComponent } from './index/index.component';
import { DetailComponent } from './detail/detail.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { ResourceComponent } from './resource/resource.component';

@NgModule({
  declarations: [IndexComponent, DetailComponent, AddComponent, EditComponent, ResourceComponent],
  imports: [
    ComponentsModule,
    ShareModule,
    RoleRoutingModule
  ]
})
export class RoleModule { }
