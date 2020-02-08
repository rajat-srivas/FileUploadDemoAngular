import { Injectable } from '@angular/core';
import { UserDetailModel } from './user-detail-model';
import { HttpClient, HttpClientModule, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class UploadServiceService {

  user: UserDetailModel = new UserDetailModel;
  userList: UserDetailModel[] = [];
  api_url = "http://localhost:52862/api/";
  attachment_BaseLocations = "http://localhost:52862/Attachments/";


  constructor(private httpVariable: HttpClient) { }

  UploadAttachements(formData) {
    this.httpVariable.post(this.api_url + "Upload", formData)
      .subscribe
      ((response) => {
        console.log("uploaded");
        this.GetDetails();
        console.log(this.userList);},
        
   
      );
  }

  GetDetails() {
    this.httpVariable.get(this.api_url + "Upload")
    
         .subscribe((respones) => {
        console.log(respones);
        this.userList = respones as UserDetailModel[];
      })
  }



}
