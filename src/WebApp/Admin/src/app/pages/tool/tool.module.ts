import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ToolRoutingModule } from './tool-routing.module';
import { GenerateCIComponent } from './generate-ci/generate-ci.component';
import { ShareModule } from 'src/app/share/share.module';


@NgModule({
  declarations: [
    GenerateCIComponent
  ],
  imports: [
    ShareModule,
    ToolRoutingModule
  ]
})
export class ToolModule { }
