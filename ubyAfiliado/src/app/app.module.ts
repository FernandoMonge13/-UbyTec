import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { GestionesComponent } from './gestiones/gestiones.component';
import { HeaderComponent } from './header/header.component';
import { VigilanteGuard } from './vigilante.guard';
import { NuevoAfiliadoComponent } from './nuevo-afiliado/nuevo-afiliado.component';
import { SolicitudComponent } from './solicitud/solicitud.component';
import { NuevoAfiliadoAdminComponent } from './nuevo-afiliado-admin/nuevo-afiliado-admin.component';
import { NuevoProductoComponent } from './nuevo-producto/nuevo-producto.component';
import { GestionProductosComponent } from './gestion-productos/gestion-productos.component';
import { NuevoPedidoComponent } from './nuevo-pedido/nuevo-pedido.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    GestionesComponent,
    HeaderComponent,
    NuevoAfiliadoComponent,
    NuevoAfiliadoAdminComponent,
    SolicitudComponent,
    NuevoProductoComponent,
    GestionProductosComponent,
    NuevoPedidoComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      {path: "", component:LoginComponent, canActivate:[VigilanteGuard]},
      {path: ":id/gestion-pedidos", component:GestionesComponent, canActivate: [VigilanteGuard]},
      {path: ":id/gestion-productos", component:GestionProductosComponent, canActivate: [VigilanteGuard]},
      {path: ":id/nuevo-admin", component:NuevoAfiliadoAdminComponent, canActivate: [VigilanteGuard]},
      {path: ":id/solicitud", component:SolicitudComponent, canActivate: [VigilanteGuard]},
      {path: ":id/gestion/pedidos", component:GestionesComponent, canActivate: [VigilanteGuard]},
      {path: "login", component:LoginComponent},
      {path: ":id/gestion-perfil", component:NuevoAfiliadoComponent, canActivate: [VigilanteGuard]},
      {path: ":id/nuevo/productos", component:NuevoProductoComponent, canActivate: [VigilanteGuard]},
      {path: ":id/actualizar-productos/:producto", component:NuevoProductoComponent, canActivate: [VigilanteGuard]},
      {path: ":id/verificar-pedido/:pedido", component:NuevoPedidoComponent, canActivate: [VigilanteGuard]}
      
    ]),

    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
