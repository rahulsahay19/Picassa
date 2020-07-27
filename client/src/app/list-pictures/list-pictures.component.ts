import { Component, OnInit } from '@angular/core';
import { PicturesService } from '../services/pictures.service';
import { Picture } from '../models/picture';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-pictures',
  templateUrl: './list-pictures.component.html',
  styleUrls: ['./list-pictures.component.scss']
})
export class ListPicturesComponent implements OnInit {
  pictures: Array<Picture>;
  constructor(private picturesService: PicturesService, private router: Router) { }

  ngOnInit(): void {
    this.getPictures();
  }

  getPictures() {
    this.picturesService.getPictures().subscribe(res => {
      this.pictures = res;
      console.log(this.pictures);
    });
  }

  deletePicture(picture) {
    this.picturesService.deletePicture(picture.id).subscribe(res => {
      const index = this.pictures.indexOf(picture);
      this.pictures.splice(index, 1);
      console.log('picture deleted!');
    });
  }

  updatePicture(id) {
    this.router.navigate(['pictures', id, 'edit']);
  }

}
