import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PicturesService } from '../services/pictures.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-post-picture',
  templateUrl: './post-picture.component.html',
  styleUrls: ['./post-picture.component.scss']
})
export class PostPictureComponent {
  pictureForm: FormGroup;
  constructor(private fb: FormBuilder, private pictureService: PicturesService, private router: Router) {
    this.pictureForm = this.fb.group({
      'imageUrl': ['', Validators.required],
      'description': ['']
    })
  }

  get imageUrl() {
    return this.pictureForm.get('imageUrl');
  }
  get description() {
    return this.pictureForm.get('description');
  }

  post() {
    return this.pictureService.postPicture(this.pictureForm.value).subscribe(res => {
      this.router.navigate(['/pictures']);
    });
  }
}
