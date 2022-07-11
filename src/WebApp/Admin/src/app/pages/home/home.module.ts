import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { LoginComponent } from './login/login.component';
import { IndexComponent } from './index/index.component';
import { ShareModule } from 'src/app/share/share.module';
import { ResourceDialogComponent } from './resource-dialog/resource-dialog.component';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ServerComponent } from './server/server.component';
import { ResourceComponent } from './resource/resource.component';


@NgModule({
  declarations: [
    LoginComponent,
    IndexComponent,
    ResourceDialogComponent,
    ServerComponent,
    ResourceComponent
  ],
  imports: [
    ShareModule,
    HomeRoutingModule
  ],
  providers: [
    { provide: MatDialogRef, useValue: {} },
    { provide: MAT_DIALOG_DATA, useValue: [] }
  ]
})
export class HomeModule { }
