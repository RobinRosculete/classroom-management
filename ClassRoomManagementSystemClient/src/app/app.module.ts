import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClassroomRequestComponent } from './classroom-request/classroom-request.component';
import { RoomAssignmentsComponent } from './components/room-assignments/room-assignments.component';
import { UpdateRequestsComponent } from './components/update-requests/update-requests.component';
import { RoomPropertiesComponent } from './components/room-properties/room-properties.component';
import { NavmenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { UpdateClassroomEquipmentComponent } from './components/update-classroom-equipment/update-classroom-equipment.component';

@NgModule({
  declarations: [
    AppComponent,
    NavmenuComponent,
    RoomPropertiesComponent,
    UpdateRequestsComponent,
    RoomAssignmentsComponent,
    ClassroomRequestComponent,
    HomeComponent,
    UpdateClassroomEquipmentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
