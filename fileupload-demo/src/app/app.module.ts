import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UploadServiceService } from './upload-service.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserDetailModel } from './user-detail-model';
import {HttpClientModule} from '@angular/common/http';
import { UploadComponent } from './upload/upload.component';
import { ViewComponent } from './view/view.component';

@NgModule({
  declarations: [
    AppComponent,
    UploadComponent,
    ViewComponent
    
  ],
  imports: [
BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [UploadServiceService, UserDetailModel],
  bootstrap: [AppComponent]
})
export class AppModule { }
