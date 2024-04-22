import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from "./core/home/home.component";
import { NotFoundComponent } from "./core/not-found/not-found.component";
import { PartListComponent } from "./parts/part-list/part-list.component";

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  {
    path: 'part', children: [
      { path: '', component: PartListComponent },
    ]
  },
  { path: '404', component: NotFoundComponent },
  { path: '**', redirectTo: '/404' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
