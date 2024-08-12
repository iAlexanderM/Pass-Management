import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
//import { PersonCreateComponent } from './person-create/person-create.component';
//import { PersonListComponent } from './person-list/person-list.component';
//import { PersonDetailsComponent } from './person-details/person-details.component';
///*import { CameraModalComponent } from './camera-modal/camera-modal.component';*/
import { CommonModule } from '@angular/common';

//const appRoutes: Routes = [
//  { path: 'persons', component: PersonListComponent },
//  { path: 'persons/create', component: PersonCreateComponent },
//  { path: 'persons/:id', component: PersonDetailsComponent }
//];

@NgModule({
  declarations: [
    AppComponent,
//    PersonCreateComponent,
//    PersonListComponent,
//    PersonDetailsComponent,
///*    CameraModalComponent*/
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
/*    RouterModule.forRoot(appRoutes),*/
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
