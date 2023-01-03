import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EnumPipe } from './pipe/enum.pipe';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ToKeyValuePipe } from './pipe/to-key-value.pipe';
import { ComponentsModule } from '../components/components.module';
import { HttpClientModule } from '@angular/common/http';
import { CutStringPipe } from './pipe/cut-string.pipe';

@NgModule({
  declarations: [EnumPipe, ToKeyValuePipe, CutStringPipe],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    ComponentsModule
  ],
  exports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    ComponentsModule,
    EnumPipe,
    ToKeyValuePipe,
    CutStringPipe
  ]
})
export class ShareModule { }
