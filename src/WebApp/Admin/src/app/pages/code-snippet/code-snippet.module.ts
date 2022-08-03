import { NgModule } from '@angular/core';
import { CodeSnippetRoutingModule } from './code-snippet-routing.module';
import { ShareModule } from 'src/app/share/share.module';
import { ComponentsModule } from 'src/app/components/components.module';
import { IndexComponent } from './index/index.component';
import { DetailComponent } from './detail/detail.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { ListStateService } from 'src/app/share/services/list-state.service';
import { MonacoEditorModule } from '@materia-ui/ngx-monaco-editor';

@NgModule({
  declarations: [IndexComponent, DetailComponent, AddComponent, EditComponent],
  imports: [
    ComponentsModule,
    ShareModule,
    CKEditorModule,
    MonacoEditorModule,
    CodeSnippetRoutingModule
  ],
  providers: [ListStateService]
})
export class CodeSnippetModule { }
