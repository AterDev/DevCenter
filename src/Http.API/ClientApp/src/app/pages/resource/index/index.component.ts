import { Component, OnInit, ViewChild } from '@angular/core';
import { ResourceService } from 'src/app/share/services/resource.service';
import { Router } from '@angular/router';
import { ConfirmDialogComponent } from 'src/app/components/confirm-dialog/confirm-dialog.component';
import { ResourceItemDto } from 'src/app/share/models/resource/resource-item-dto.model';
import { ResourceFilterDto } from 'src/app/share/models/resource/resource-filter-dto.model';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { ResourceGroupService } from 'src/app/share/services/resource-group.service';
import { lastValueFrom } from 'rxjs';
import { ResourceGroup } from 'src/app/share/models/resource-group/resource-group.model';
import { MatSelectChange } from '@angular/material/select';
import { ResourceGroupItemDto } from 'src/app/share/models/resource-group/resource-group-item-dto.model';
import { FilterState, ListStateService } from 'src/app/share/services/list-state.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  isLoading = true;
  total = 0;
  data: ResourceItemDto[] = [];
  columns: string[] = ['name', 'description', 'actions'];
  dataSource!: MatTableDataSource<ResourceItemDto>;
  filter: ResourceFilterDto;
  groups: ResourceGroupItemDto[] = [];
  pageSizeOption = [12, 20, 50];
  constructor(
    private service: ResourceService,
    private listSrv: ListStateService,
    private groupSrv: ResourceGroupService,
    private snb: MatSnackBar,
    private dialog: MatDialog,
    private router: Router,
  ) {

    this.filter = {
      pageIndex: 1,
      pageSize: 12,
      groupId: null
    };
  }

  ngOnInit(): void {
    this.getGroup();
    this.getList();
  }

  filterList(event: MatSelectChange): void {
    this.listSrv.filter = { query: null, filter: this.filter };
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
          this.dataSource = new MatTableDataSource<ResourceItemDto>(this.data);
        }
        this.isLoading = false;
      });
  }
  async getGroup() {
    const res = await lastValueFrom(this.groupSrv.getList());
    if (res) {
      this.groups = res;
    }
  }

  deleteConfirm(item: ResourceItemDto): void {
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
  delete(item: ResourceItemDto): void {
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
    this.router.navigateByUrl('/admin/resource/edit/' + id);
  }

}
