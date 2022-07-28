import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/auth/auth.guard';
import { GenerateCIComponent } from './generate-ci/generate-ci.component';

const routes: Routes = [
  {
    path: 'tool',
    canActivate: [AuthGuard],
    children: [
      { path: 'generateCI', component: GenerateCIComponent },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ToolRoutingModule { }
