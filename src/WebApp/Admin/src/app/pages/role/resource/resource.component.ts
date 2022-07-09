import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { ResourceGroupService } from 'src/app/share/services/resource-group.service';
import { ResourceGroupRoleDto } from 'src/app/share/models/resource-group/resource-group-role-dto.model';
@Component({
  selector: 'app-resource',
  templateUrl: './resource.component.html',
  styleUrls: ['./resource.component.css']
})
export class ResourceComponent implements OnInit {
  id!: string;
  isLoading = true;
  groups = [] as ResourceGroupRoleDto[];

  constructor(
    private route: ActivatedRoute,
    private groupSrv: ResourceGroupService,
    private location: Location
  ) {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.id = id;
    } else {
      // TODO: id为空
    }
  }

  ngOnInit(): void {

  }
  back(): void {
    this.location.back();
  }
}
