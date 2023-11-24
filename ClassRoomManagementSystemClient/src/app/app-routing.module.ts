import { NgModule } from '@angular/core';
import { HomeComponent } from './components/home/home.component';
import { ClassroomRequestComponent } from './classroom-request/classroom-request.component';
import { RoomAssignmentsComponent } from './components/room-assignments/room-assignments.component';
import { UpdateRequestsComponent } from './components/update-requests/update-requests.component';
import { RoomPropertiesComponent } from './components/room-properties/room-properties.component';

import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'classroom-request', component: ClassroomRequestComponent },
  { path: 'room-assignments', component: RoomAssignmentsComponent },
  { path: 'update-request', component: UpdateRequestsComponent },
  { path: 'room-properties', component: RoomPropertiesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
