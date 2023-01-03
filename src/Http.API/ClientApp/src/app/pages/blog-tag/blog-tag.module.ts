import { NgModule } from '@angular/core';
import { BlogTagRoutingModule } from './blog-tag-routing.module';
import { ShareModule } from 'src/app/share/share.module';
import { ComponentsModule } from 'src/app/components/components.module';
import { IndexComponent } from './index/index.component';
import { DetailComponent } from './detail/detail.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';

@NgModule({
  declarations: [IndexComponent, DetailComponent, AddComponent, EditComponent],
  imports: [
    ComponentsModule,
    ShareModule,
    BlogTagRoutingModule
  ]
})
export class BlogTagModule { }
