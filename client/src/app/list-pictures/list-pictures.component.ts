import { Component, OnInit } from '@angular/core';
import { PicturesService } from '../services/pictures.service';
import { Picture } from '../models/picture';

@Component({
  selector: 'app-list-pictures',
  templateUrl: './list-pictures.component.html',
  styleUrls: ['./list-pictures.component.scss']
})
export class ListPicturesComponent implements OnInit {
  pictures: Array<Picture>;
  constructor(private picturesService: PicturesService) { }

  ngOnInit(): void {
    this.picturesService.getPictures().subscribe(res => {
      this.pictures = res;
      console.log(this.pictures);
    })
  }



}
