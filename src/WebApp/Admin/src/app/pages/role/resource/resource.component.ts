import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Role } from 'src/app/share/models/role/role.model';
@Component({
  selector: 'app-resource',
  templateUrl: './resource.component.html',
  styleUrls: ['./resource.component.css']
})
export class ResourceComponent implements OnInit {
  id!: string;
  isLoading = true;
  data = {} as Role;
  constructor(
    private route: ActivatedRoute,
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
