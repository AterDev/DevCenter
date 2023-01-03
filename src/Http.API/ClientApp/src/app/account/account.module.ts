import { NgModule } from '@angular/core';

import { AccountRoutingModule } from './account-routing.module';
import { IndexComponent } from './index/index.component';
import { ShareModule } from '../share/share.module';


@NgModule({
  declarations: [
    IndexComponent
  ],
  imports: [
    ShareModule,
    AccountRoutingModule
  ]
})
export class AccountModule { }
