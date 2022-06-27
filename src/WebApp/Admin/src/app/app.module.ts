import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ComponentsModule } from './components/components.module';
import { AppRoutingModule } from './app-routing.module';
import { HomeModule } from './pages/home/home.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';
import { CustomerHttpInterceptor } from './share/customer-http.interceptor';
import { EnvironmentModule } from './pages/environment/environment.module';
import { ConfigOptionModule } from './pages/config-option/config-option.module';
import { ResourceModule } from './pages/resource/resource.module';
import { ResourceAttributeModule } from './pages/resource-attribute/resource-attribute.module';
import { ResourceAttributeDefineModule } from './pages/resource-attribute-define/resource-attribute-define.module';
import { ResourceGroupModule } from './pages/resource-group/resource-group.module';
import { RoleModule } from './pages/role/role.module';
import { UserModule } from './pages/user/user.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    ComponentsModule,
    HomeModule,
    EnvironmentModule,
    ConfigOptionModule,
    ResourceModule,
    ResourceAttributeModule,
    ResourceAttributeDefineModule,
    ResourceGroupModule,
    RoleModule,
    UserModule
  ],
  providers: [
    { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2500 } },
    { provide: HTTP_INTERCEPTORS, useClass: CustomerHttpInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
