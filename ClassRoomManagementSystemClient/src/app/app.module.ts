import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClassroomRequestComponent } from './classroom-request/classroom-request.component';
import { RoomAssignmentsComponent } from './room-assignments/room-assignments.component';
import { UpdateRequestsComponent } from './update-requests/update-requests.component';
import { RoomPropertiesComponent } from './room-properties/room-properties.component';
import { NavmenuComponent } from './navmenu/navmenu.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    NavmenuComponent,
    RoomPropertiesComponent,
    UpdateRequestsComponent,
    RoomAssignmentsComponent,
    ClassroomRequestComponent,
    HomeComponent,
  ],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
