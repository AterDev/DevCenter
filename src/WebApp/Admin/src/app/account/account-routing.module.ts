import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../auth/auth.guard';
import { LayoutComponent } from '../components/layout/layout.component';
import { IndexComponent } from './index/index.component';

const routes: Routes = [
  {
    path: 'account',
    // component: LayoutComponent,
    // data: { reuse: true },
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
    children:
      [
        { path: '', pathMatch: 'full', redirectTo: 'account/index' },
        { path: 'index', component: IndexComponent },
      ]
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
