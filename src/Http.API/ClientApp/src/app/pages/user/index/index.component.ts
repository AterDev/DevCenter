import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from 'src/app/share/services/user.service';
import { Router } from '@angular/router';
import { ConfirmDialogComponent } from 'src/app/components/confirm-dialog/confirm-dialog.component';
import { UserItemDto } from 'src/app/share/models/user/user-item-dto.model';
import { UserFilterDto } from 'src/app/share/models/user/user-filter-dto.model';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { RoleItemDto } from 'src/app/share/models/role/role-item-dto.model';
import { RoleService } from 'src/app/share/services/role.service';
import { lastValueFrom } from 'rxjs';
import { PageListOfRoleItemDto } from 'src/app/share/models/role/page-list-of-role-item-dto.model';
import { MatSelectChange } from '@angular/material/select';
import { ListStateService } from 'src/app/share/services/list-state.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  isLoading = true;
  total = 0;
  data: UserItemDto[] = [];
  roles: RoleItemDto[] = [];
  columns: string[] = ['userName', 'realName', 'position', 'email', 'actions'];
  dataSource!: MatTableDataSource<UserItemDto>;
  selection = new SelectionModel<UserItemDto>(true, []);
  filter: UserFilterDto;
  pageSizeOption = [12, 20, 50];
  constructor(
    private service: UserService,
    private roleSrv: RoleService,

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
    this.getRoles().then(() => {
      this.getList();
    });
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
          this.dataSource = new MatTableDataSource<UserItemDto>(this.data);
        }
        this.isLoading = false;
      });
  }
  filterList(event: MatSelectChange): void {
    this.listSrv.filter = { query: null, filter: this.filter };
    this.getList();
  }
  async getRoles() {
    let res = await lastValueFrom(this.roleSrv.filter({ pageIndex: 1, pageSize: 10 }));
    if (res) {
      this.roles = res.data!;
    }
  }

  deleteConfirm(item: UserItemDto): void {
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
  delete(item: UserItemDto): void {
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
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  toggleAllRows() {
    if (this.isAllSelected()) {
      this.selection.clear();
      return;
    }

    this.selection.select(...this.dataSource.data);
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: UserItemDto): string {
    if (!row) {
      return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id}`;
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
    this.router.navigateByUrl('/admin/user/edit/' + id);
  }

}
