import { Routes } from '@angular/router';
import { PersonCreateComponent } from './person-create/person-create.component';
import { PersonListComponent } from './person-list/person-list.component';
import { PersonDetailsComponent } from './person-details/person-details.component';

export const appRoutes: Routes = [
  { path: 'persons', component: PersonListComponent },
  { path: 'persons/create', component: PersonCreateComponent },
  { path: 'persons/:id', component: PersonDetailsComponent },
  { path: '', redirectTo: 'persons', pathMatch: 'full' }
];
