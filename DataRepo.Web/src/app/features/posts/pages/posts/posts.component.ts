import { Component } from '@angular/core';
import { PostsService } from '../../services/posts.service';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, RequiredValidator, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Post } from '../../../../core/models/post';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-posts',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './posts.component.html',
  styleUrl: './posts.component.scss'
})
export class PostsComponent {
  postForm: FormGroup = this._fb.group({
    tags: ["", Validators.required],
    sortBy: ["id"],
    direction: ["asc"],
  });
  posts$?: Observable<Post[]>;

  constructor(
    private _postsService: PostsService,
    private _fb: FormBuilder,
  ) { }

  ngOnInit(): void {

  }

  validateForm(): boolean | undefined {
    if (!this.postForm)
      return false;
    return this.postForm.get("tags")?.valid && this.postForm.get("tags")?.touched;
  }

  onSubmit(): void {
    if (!!this.validateForm())
      this.posts$ = this._postsService.getPostsAsync(
          this.postForm.get("tags")?.value,
          this.postForm.get("sortBy")?.value,
          this.postForm.get("direction")?.value);
  }
}
