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
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
