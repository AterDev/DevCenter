import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { NavigationStart, Router } from '@angular/router';
import { filter, lastValueFrom, map, Observable, startWith } from 'rxjs';
import { LoginService } from 'src/app/auth/login.service';
import { ResourceDialogComponent } from 'src/app/pages/home/resource-dialog/resource-dialog.component';
import { Resource } from 'src/app/share/models/resource/resource.model';
import { ResourceService } from 'src/app/share/services/resource.service';

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
    private resourceSrv: ResourceService,
    public dialog: MatDialog
  ) {
    // this layout is out of router-outlet, so we need to listen router event and change isLogin status
    router.events.subscribe((event) => {
      if (event instanceof NavigationStart) {
        const navigateByUrls = ['/index', '/resource', '/server'];

        this.isLogin = this.auth.isLogin;
        this.isAdmin = this.auth.isAdmin;
        this.username = this.auth.userName;

        if (this.isLogin && navigateByUrls.includes(event.url))
          this.getResources()
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
  async getResources(): Promise<void> {
    let res = await lastValueFrom(this.resourceSrv.getAllResources());
    if (res) {
      this.resources = res;
    }
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
