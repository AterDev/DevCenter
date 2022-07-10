import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '', redirectTo: 'index', pathMatch: 'full', data: {
      reuse: true
    }
  },
  { path: 'index', redirectTo: 'index', pathMatch: 'full' },
  { path: 'login', redirectTo: 'login', pathMatch: 'full' },
  { path: 'admin', redirectTo: 'admin/index', pathMatch: 'full' },
  { path: 'account', redirectTo: 'account/index', pathMatch: 'full' },
  { path: '*', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
