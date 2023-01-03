import { Component, OnInit, ViewChild } from '@angular/core';
import { CodeSnippetService } from 'src/app/share/services/code-snippet.service';
import { Router } from '@angular/router';
import { ConfirmDialogComponent } from 'src/app/components/confirm-dialog/confirm-dialog.component';
import { CodeSnippetItemDto } from 'src/app/share/models/code-snippet/code-snippet-item-dto.model';
import { CodeSnippetFilterDto } from 'src/app/share/models/code-snippet/code-snippet-filter-dto.model';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { CodeType } from 'src/app/share/models/enum/code-type.model';
import { Language } from 'src/app/share/models/enum/language.model';
import { CodeLibraryService } from 'src/app/share/services/code-library.service';
import { lastValueFrom } from 'rxjs';
import { CodeLibraryItemDto } from 'src/app/share/models/code-library/code-library-item-dto.model';
import { MatSelectChange } from '@angular/material/select';
import { ListStateService } from 'src/app/share/services/list-state.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;

  Language = Language;
  CodeType = CodeType;
  isLoading = true;
  codeLibs = [] as CodeLibraryItemDto[];
  total = 0;
  data: CodeSnippetItemDto[] = [];
  columns: string[] = ['name', 'description', 'language', 'codeType', 'createdTime', 'actions'];
  dataSource!: MatTableDataSource<CodeSnippetItemDto>;
  filter: CodeSnippetFilterDto;
  pageSizeOption = [12, 20, 50];
  constructor(
    private service: CodeSnippetService,
    private librarySrv: CodeLibraryService,
    private listSrv: ListStateService,
    private snb: MatSnackBar,
    private dialog: MatDialog,
    private router: Router,
  ) {

    this.filter = {
      pageIndex: 1,
      pageSize: 12
    };
  }

  ngOnInit(): void {
    this.getLibrary();
    this.getList();
  }

  getList(event?: PageEvent): void {
    if (this.listSrv.filter?.filter)
      this.filter = this.listSrv.filter?.filter;

    if (event) {
      this.filter.pageIndex = event.pageIndex + 1;
      this.filter.pageSize = event.pageSize;
    }
    this.service.filter(this.filter)
      .subscribe(res => {
        if (res.data) {
          this.data = res.data;
          this.total = res.count;
          this.dataSource = new MatTableDataSource<CodeSnippetItemDto>(this.data);
        }
        this.isLoading = false;
      });
  }

  async getLibrary() {
    const res = await lastValueFrom(this.librarySrv.filter({
      pageIndex: 1,
      pageSize: 100
    }));
    if (res.data) {
      this.codeLibs = res.data;
    }
  }

  filterList(event: MatSelectChange): void {
    this.listSrv.filter = { query: null, filter: this.filter };
    this.getList();
  }

  deleteConfirm(item: CodeSnippetItemDto): void {
    const ref = this.dialog.open(ConfirmDialogComponent, {
      hasBackdrop: true,
      disableClose: false,
      data: {
        title: '删除',
        content: '是否确定删除?'
      }
    });

    ref.afterClosed().subscribe(res => {
      if (res) {
        this.delete(item);
      }
    });
  }
  delete(item: CodeSnippetItemDto): void {
    this.service.delete(item.id)
      .subscribe(res => {
        if (res) {
          this.data = this.data.filter(_ => _.id !== item.id);
          this.dataSource.data = this.data;
          this.snb.open('删除成功');
        } else {
          this.snb.open('删除失败');
        }
      });
  }

  /*
  openAddDialog(): void {
    const ref = this.dialog.open(AddComponent, {
      hasBackdrop: true,
      disableClose: false,
      data: {
      }
    });
    ref.afterClosed().subscribe(res => {
      if (res) {
        this.snb.open('添加成功');
        this.getList();
      }
    });
  }
  openDetailDialog(id: string): void {
    const ref = this.dialog.open(DetailComponent, {
      hasBackdrop: true,
      disableClose: false,
      data: { id }
    });
    ref.afterClosed().subscribe(res => {
      if (res) { }
    });
  }

  openEditDialog(id: string): void {
    const ref = this.dialog.open(EditComponent, {
      hasBackdrop: true,
      disableClose: false,
      data: { id }
    });
    ref.afterClosed().subscribe(res => {
      if (res) {
        this.snb.open('修改成功');
        this.getList();
      }
    });
  }*/

  /**
   * 编辑
   */
  edit(id: string): void {
    console.log(id);
    this.router.navigateByUrl('/admin/code-snippet/edit/' + id);
  }

}
