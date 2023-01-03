import { NgModule } from '@angular/core';
import { AdminRoutingModule } from './admin-routing.module';
import { IndexComponent } from './index/index.component';
import { ShareModule } from 'src/app/share/share.module';
import { ComponentsModule } from 'src/app/components/components.module';
import { ConfigOptionModule } from '../config-option/config-option.module';
import { EnvironmentModule } from '../environment/environment.module';
import { ResourceAttributeDefineModule } from '../resource-attribute-define/resource-attribute-define.module';
import { ResourceAttributeModule } from '../resource-attribute/resource-attribute.module';
import { ResourceGroupModule } from '../resource-group/resource-group.module';
import { ResourceModule } from '../resource/resource.module';
import { RoleModule } from '../role/role.module';
import { UserModule } from '../user/user.module';
import { ResourceTagsModule } from '../resource-tags/resource-tags.module';
import { ResourceTypeDefinitionModule } from '../resource-type-definition/resource-type-definition.module';
import { RouteReuseStrategy } from '@angular/router';
import { CustomRouteReuseStrategy } from 'src/app/custom-route-strategy';
import { BlogModule } from '../blog/blog.module';
import { BlogCatalogModule } from '../blog-catalog/blog-catalog.module';
import { CodeLibraryModule } from '../code-library/code-library.module';
import { CodeSnippetModule } from '../code-snippet/code-snippet.module';
import { BlogTagModule } from '../blog-tag/blog-tag.module';


@NgModule({
  declarations: [
    IndexComponent
  ],
  imports: [
    ComponentsModule,
    ShareModule,
    AdminRoutingModule,
    ResourceAttributeModule,
    ResourceAttributeDefineModule,
    EnvironmentModule,
    ConfigOptionModule,
    ResourceModule,
    ResourceGroupModule,
    ResourceTagsModule,
    ResourceTypeDefinitionModule,
    RoleModule,
    UserModule,
    BlogModule,
    BlogCatalogModule,
    BlogTagModule,
    CodeLibraryModule,
    CodeSnippetModule,
  ],
  providers: [{
    provide: RouteReuseStrategy,
    useClass: CustomRouteReuseStrategy
  }]
})
export class AdminModule { }
