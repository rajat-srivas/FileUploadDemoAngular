import { Component, OnInit, Input, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators, Form } from '@angular/forms';
import { UploadServiceService } from '../upload-service.service';
import { UserDetailModel } from '../user-detail-model';


@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  fileDetails: File;
  imageDetails: File;
  @ViewChild('image',{static:true}) imageControl : ElementRef;
  @ViewChild('resume',{static:true}) resumeControl : ElementRef;


  constructor(
    private uploadService: UploadServiceService
  ) { }

  ngOnInit() {
    this.uploadService.GetDetails();
  }

  resumeUpload(event) {
    this.fileDetails = event.target.files[0];
  }

  imageUpload(event) {
    this.imageDetails = event.target.files[0];
  }

  onSubmit() {
    const formData: FormData = new FormData();
    formData.append("Image", this.imageDetails, this.imageDetails.name);
    formData.append("Resume", this.fileDetails, this.fileDetails.name);
    formData.append("Details", JSON.stringify(this.uploadService.user));
    this.uploadService.UploadAttachements(formData);
    this.ClearForm();
    
  }

  ClearForm()
  {
    this.uploadService.user = new UserDetailModel;
    this.imageControl.nativeElement.value= "";
    this.resumeControl.nativeElement.value= "";
  }


}
