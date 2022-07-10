import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { NavigationStart, Router } from '@angular/router';
import { filter, map, Observable, startWith } from 'rxjs';
import { LoginService } from 'src/app/auth/login.service';
import { ResourceDialogComponent } from 'src/app/pages/home/resource-dialog/resource-dialog.component';
import { Resource } from 'src/app/share/models/resource/resource.model';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {
  isLogin = false;
  isAdmin = false;
  username?: string | null = null;
  searchControl: FormControl = new FormControl(null);
  resources = [] as Resource[];
  filteredResource: Observable<Resource[]>;
  constructor(
    private auth: LoginService,
    private router: Router,
    public dialog: MatDialog
  ) {
    // this layout is out of router-outlet, so we need to listen router event and change isLogin status
    router.events.subscribe((event) => {
      if (event instanceof NavigationStart) {
        this.isLogin = this.auth.isLogin;
        this.isAdmin = this.auth.isAdmin;
        this.username = this.auth.userName;
      }
    });

    this.filteredResource = this.searchControl.valueChanges.pipe(
      startWith(''),
      map(resource => {
        return resource ?
          this._filterStates(resource) :
          this.resources.slice()
      }),
    );
  }
  private _filterStates(value: string): Resource[] {
    const filterValue = value.toLowerCase();

    return this.resources.filter(resource => {
      return resource.name.toLowerCase().includes(filterValue)
        || resource.attributes?.findIndex(a => a.value.includes(filterValue))! >= 0
        || resource.description?.toLowerCase().includes(filterValue);
    });
  }
  ngOnInit(): void {
    this.isLogin = this.auth.isLogin;
    this.isAdmin = this.auth.isAdmin;
    if (this.isLogin) {
      this.username = this.auth.userName!;
    }
    const searchResources = localStorage.getItem('searchResources');
    if (searchResources) {
      this.resources = JSON.parse(searchResources);
      console.log(this.resources);
    }
  }
  selectSearch(event: MatAutocompleteSelectedEvent) {
    const resource = this.resources.find(item => item.id === event.option.id);
    this.dialog.open(ResourceDialogComponent, {
      data: resource
    });

  }

  login(): void {
    this.router.navigateByUrl('/login')
  }

  logout(): void {
    this.auth.logout();
    this.router.navigateByUrl('/index');
    location.reload();
  }
}
