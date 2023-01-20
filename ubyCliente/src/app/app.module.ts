import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { NuevoPedidioComponent } from './nuevo-pedidio/nuevo-pedidio.component';
import { VigilanteGuard } from './vigilante.guard';
import { NuevoProductoPedidoComponent } from './nuevo-producto-pedido/nuevo-producto-pedido.component';
import { HeaderComponent } from './header/header.component';
import { MiPerfilComponent } from './mi-perfil/mi-perfil.component';
import { ComprasComponent } from './compras/compras.component';
import { CarritoComponent } from './carrito/carrito.component';
import { PedidoCursoComponent } from './pedido-curso/pedido-curso.component';

@NgModule({
    declarations: [
        AppComponent,
        LoginComponent,
        NuevoPedidioComponent,
        NuevoProductoPedidoComponent,
        HeaderComponent,
        MiPerfilComponent,
        CarritoComponent,
        ComprasComponent,
        PedidoCursoComponent
    ],
    providers: [],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule, RouterModule.forRoot([
            { path: "", component: LoginComponent },
            { path: "login", component: LoginComponent },
            { path: "nuevo/pedido", component: NuevoPedidioComponent, canActivate: [VigilanteGuard] },
            { path: "nuevo/productopedido", component: NuevoProductoPedidoComponent, canActivate: [VigilanteGuard] },
            { path: ":id/comprar", component:ComprasComponent, canActivate: [VigilanteGuard] },
            { path: ":id/comprar/:comercio", component: CarritoComponent, canActivate: [VigilanteGuard] },
            { path: ":id/mi-perfil", component: MiPerfilComponent, canActivate: [VigilanteGuard] },
            { path: ":id/en-curso", component: PedidoCursoComponent, canActivate: [VigilanteGuard] }
        ]),
        FormsModule,
        HttpClientModule
    ]
})
export class AppModule { }
