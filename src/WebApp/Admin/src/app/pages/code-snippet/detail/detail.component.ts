import { Component, OnInit } from '@angular/core';
import { CodeSnippetService } from 'src/app/share/services/code-snippet.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CodeSnippet } from 'src/app/share/models/code-snippet/code-snippet.model';
import { Location } from '@angular/common';
import * as ClassicEditor from 'ng-ckeditor5-classic';
import { CKEditor5 } from '@ckeditor/ckeditor5-angular';
import { MonacoEditorConstructionOptions, MonacoStandaloneCodeEditor } from '@materia-ui/ngx-monaco-editor';
import { Language } from 'src/app/share/models/enum/language.model';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
  Language = Language;
  id!: string;
  public editor!: MonacoStandaloneCodeEditor;
  public editorOption: MonacoEditorConstructionOptions;
  isLoading = true;
  data = {} as CodeSnippet;
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
    this.editorOption = {
      theme: 'vs-dark',
      minimap: { enabled: false },

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
        this.editor.setValue(this.data.content!);

      }, error => {
        this.snb.open(error);
      })

  }
  editorInit(editor: MonacoStandaloneCodeEditor) {
    this.editor = editor;
    const language = Language[this.data.language!].toLowerCase();
    const model = this.editor.getModel();
    monaco.editor.setModelLanguage(model!, language);
    this.editorOption.language = language;
  }
  back(): void {
    this.location.back();
  }

  edit(): void {
    this.router.navigate(['../../edit/' + this.id], { relativeTo: this.route });

  }
}
