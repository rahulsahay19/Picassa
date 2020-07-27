import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PicturesService } from '../services/pictures.service';
import { Picture } from '../models/picture';

@Component({
  selector: 'app-picture-details',
  templateUrl: './picture-details.component.html',
  styleUrls: ['./picture-details.component.scss']
})
export class PictureDetailsComponent implements OnInit {
  id: number;
  picture: Picture;
  constructor(private route: ActivatedRoute, private picturesService: PicturesService) {
    this.route.params.subscribe(res => {
      this.id = res['id'];
      this.picturesService.getPicture(this.id).subscribe(res => {
        this.picture = res;
      })
    })
  }

  ngOnInit(): void {
  }

}
