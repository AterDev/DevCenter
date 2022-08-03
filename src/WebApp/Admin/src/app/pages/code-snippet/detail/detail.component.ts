import { Component, OnInit } from '@angular/core';
import { CodeSnippetService } from 'src/app/share/services/code-snippet.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CodeSnippet } from 'src/app/share/models/code-snippet/code-snippet.model';
import { Location } from '@angular/common';
import * as ClassicEditor from 'ng-ckeditor5-classic';
import { CKEditor5 } from '@ckeditor/ckeditor5-angular';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
  id!: string;
  isLoading = true;
  data = {} as CodeSnippet;
  public editor: CKEditor5.EditorConstructor = ClassicEditor;
  constructor(
    private service: CodeSnippetService,
    private snb: MatSnackBar,
    private route: ActivatedRoute,
    public location: Location,
    private router: Router,
  ) {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.id = id;
    } else {
      // TODO: id为空

    }
  }
  ngOnInit(): void {
    this.getDetail();
  }
  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe(res => {
        this.data = res;
        this.isLoading = false;
      }, error => {
        this.snb.open(error);
      })
  }
  back(): void {
    this.location.back();
  }

  edit(): void {
    this.router.navigate(['../../edit/' + this.id], { relativeTo: this.route });

  }
}
