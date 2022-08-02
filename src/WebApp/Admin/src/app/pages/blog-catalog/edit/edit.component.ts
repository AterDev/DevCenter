import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogCatalog } from 'src/app/share/models/blog-catalog/blog-catalog.model';
import { BlogCatalogService } from 'src/app/share/services/blog-catalog.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BlogCatalogUpdateDto } from 'src/app/share/models/blog-catalog/blog-catalog-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Location } from '@angular/common';
import { Status } from 'src/app/share/models/enum/status.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  Status = Status;

  id!: string;
  isLoading = true;
  data = {} as BlogCatalog;
  updateData = {} as BlogCatalogUpdateDto;
  formGroup!: FormGroup;
    constructor(
    
    private service: BlogCatalogService,
    private snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location
    // public dialogRef: MatDialogRef<EditComponent>,
    // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.id = id;
    } else {
      // TODO: id为空
    }
  }

    get name() { return this.formGroup.get('name'); }
    get type() { return this.formGroup.get('type'); }
    get sort() { return this.formGroup.get('sort'); }
    get level() { return this.formGroup.get('level'); }
    get status() { return this.formGroup.get('status'); }
    get isDeleted() { return this.formGroup.get('isDeleted'); }


  ngOnInit(): void {
    this.getDetail();
    
    // TODO:等待数据加载完成
    // this.isLoading = false;
  }
  
  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe(res => {
        this.data = res;
        this.initForm();
        this.isLoading = false;
      }, error => {
        this.snb.open(error);
      })
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      name: new FormControl(this.data.name, [Validators.maxLength(50)]),
      type: new FormControl(this.data.type, [Validators.maxLength(50)]),
      sort: new FormControl(this.data.sort, []),
      level: new FormControl(this.data.level, []),
      status: new FormControl(this.data.status, []),
      isDeleted: new FormControl(this.data.isDeleted, []),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'name':
        return this.name?.errors?.['required'] ? 'Name必填' :
          this.name?.errors?.['minlength'] ? 'Name长度最少位' :
            this.name?.errors?.['maxlength'] ? 'Name长度最多50位' : '';
      case 'type':
        return this.type?.errors?.['required'] ? 'Type必填' :
          this.type?.errors?.['minlength'] ? 'Type长度最少位' :
            this.type?.errors?.['maxlength'] ? 'Type长度最多50位' : '';
      case 'sort':
        return this.sort?.errors?.['required'] ? 'Sort必填' :
          this.sort?.errors?.['minlength'] ? 'Sort长度最少位' :
            this.sort?.errors?.['maxlength'] ? 'Sort长度最多位' : '';
      case 'level':
        return this.level?.errors?.['required'] ? 'Level必填' :
          this.level?.errors?.['minlength'] ? 'Level长度最少位' :
            this.level?.errors?.['maxlength'] ? 'Level长度最多位' : '';
      case 'status':
        return this.status?.errors?.['required'] ? 'Status必填' :
          this.status?.errors?.['minlength'] ? 'Status长度最少位' :
            this.status?.errors?.['maxlength'] ? 'Status长度最多位' : '';
      case 'isDeleted':
        return this.isDeleted?.errors?.['required'] ? 'IsDeleted必填' :
          this.isDeleted?.errors?.['minlength'] ? 'IsDeleted长度最少位' :
            this.isDeleted?.errors?.['maxlength'] ? 'IsDeleted长度最多位' : '';

      default:
        return '';
    }
  }
  edit(): void {
    if(this.formGroup.valid) {
      this.updateData = this.formGroup.value as BlogCatalogUpdateDto;
      this.service.update(this.id, this.updateData)
        .subscribe(res => {
          this.snb.open('修改成功');
           // this.dialogRef.close(res);
          this.router.navigate(['../../index'],{relativeTo: this.route});
        });
    }
  }

  back(): void {
    this.location.back();
  }

}
