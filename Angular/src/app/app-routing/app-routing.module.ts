import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteListComponent } from '../clientes/cliente-list/cliente-list.component';
import { ClienteComponent } from '../clientes/cliente/cliente.component';

const routes: Routes = [
  {
    path: '',
    component: ClienteListComponent,
  },
  {
    path: 'formulario-cliente',
    component: ClienteComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: [],
})
export class AppRoutingModule {}
