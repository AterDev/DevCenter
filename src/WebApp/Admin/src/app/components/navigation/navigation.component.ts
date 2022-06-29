import { AfterViewInit, Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion';

@Component({
  selector: 'admin-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit, AfterViewInit {
  events: string[] = [];
  opened = true;
  expanded = true;
  @ViewChild(MatAccordion, { static: true }) accordion!: MatAccordion;
  constructor() {
  }

  ngOnInit(): void {
    console.log(this.accordion);
    if (this.expanded) {
      this.accordion?.openAll();
    } else {
      this.accordion?.closeAll();
    }
  }

  ngAfterViewInit(): void {


  }
  toggle(): void {
    this.opened = !this.opened;
  }

  expandToggle(): void {
    this.expanded = !this.expanded;
    if (this.expanded) {
      this.accordion?.openAll();
    } else {
      this.accordion?.closeAll();
    }
  }
}
