import { Component, OnInit } from '@angular/core';
import { UploadServiceService } from '../upload-service.service';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  constructor( private uploadService: UploadServiceService) { }

  ngOnInit() {
  }

}
