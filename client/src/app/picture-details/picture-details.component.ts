import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PicturesService } from '../services/pictures.service';
import { Picture } from '../models/picture';
import { map, mergeMap } from 'rxjs/operators';

@Component({
  selector: 'app-picture-details',
  templateUrl: './picture-details.component.html',
  styleUrls: ['./picture-details.component.scss']
})
export class PictureDetailsComponent implements OnInit {
  id: number;
  picture: Picture;
  constructor(private route: ActivatedRoute, private picturesService: PicturesService) {
    this.fetchPicture();
  }

  ngOnInit(): void {
  }

  fetchPicture() {
    this.route.params.pipe(map(params => {
      const id = params['id'];
      return id
    }), mergeMap(id => this.picturesService.getPicture(id))).subscribe(picture => {
      this.picture = picture;
    })
  }

}
