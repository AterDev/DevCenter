import { Component, OnInit, ViewChild } from '@angular/core';
import { CodeLibraryService } from 'src/app/share/services/code-library.service';
import { Router } from '@angular/router';
import { ConfirmDialogComponent } from 'src/app/components/confirm-dialog/confirm-dialog.component';
import { CodeLibraryItemDto } from 'src/app/share/models/code-library/code-library-item-dto.model';
import { CodeLibraryFilterDto } from 'src/app/share/models/code-library/code-library-filter-dto.model';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { LibraryType } from 'src/app/share/models/enum/library-type.model';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  LibraryType = LibraryType;
  isLoading = true;
  total = 0;
  data: CodeLibraryItemDto[] = [];
  columns: string[] = ['namespace', 'description', 'type', 'isValid', 'isPublic', 'actions'];
  dataSource!: MatTableDataSource<CodeLibraryItemDto>;
  filter: CodeLibraryFilterDto;
  pageSizeOption = [12, 20, 50];
  constructor(
    private service: CodeLibraryService,
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
    this.getList();
  }

  getList(event?: PageEvent): void {
    if (event) {
      this.filter.pageIndex = event.pageIndex + 1;
      this.filter.pageSize = event.pageSize;
    }
    this.service.filter(this.filter)
      .subscribe(res => {
        if (res.data) {
          this.data = res.data;
          this.total = res.count;
          this.dataSource = new MatTableDataSource<CodeLibraryItemDto>(this.data);
        }
        this.isLoading = false;
      });
  }

  deleteConfirm(item: CodeLibraryItemDto): void {
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
  delete(item: CodeLibraryItemDto): void {
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
    this.router.navigateByUrl('/admin/code-library/edit/' + id);
  }

}
