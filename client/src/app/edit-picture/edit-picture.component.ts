import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PicturesService } from '../services/pictures.service';
import { Picture } from '../models/picture';

@Component({
  selector: 'app-edit-picture',
  templateUrl: './edit-picture.component.html',
  styleUrls: ['./edit-picture.component.scss']
})
export class EditPictureComponent implements OnInit {
  pictureForm: FormGroup;
  id: number;
  picture: Picture;
  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private picturesService: PicturesService,
    private router: Router) {

    this.pictureForm = this.fb.group({
      'id': [''],
      'description': ['']
    })
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.picturesService.getPicture(this.id).subscribe(res => {
        this.picture = res;
        this.pictureForm = this.fb.group({
          'id': [this.picture.id],
          'description': [this.picture.description]
        })
      })
    })
  }

  editPicture() {
    this.picturesService.editPicture(this.pictureForm.value).subscribe(res => {
      this.router.navigate(['pictures']);
    });
  }

}
