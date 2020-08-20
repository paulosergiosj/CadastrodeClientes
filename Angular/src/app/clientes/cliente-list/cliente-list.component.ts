import { Component, OnInit } from '@angular/core';
import { ClienteService } from 'src/app/shared/cliente.service';
import { Cliente } from 'src/app/shared/cliente.model';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cliente-list',
  templateUrl: './cliente-list.component.html',
  styles: [],
})
export class ClienteListComponent implements OnInit {
  constructor(
    public service: ClienteService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit() {
    this.service.refreshList();
  }

  visualizarCadastro(cl: Cliente) {
    this.service.formData = Object.assign({}, cl);
    this.service.readonly = true;
    this.router.navigate(['/formulario-cliente']);
  }

  editarCadastro(cl: Cliente) {
    this.service.formData = Object.assign({}, cl);
    this.service.readonly = false;
    this.router.navigate(['/formulario-cliente']);
  }

  botaoExcluir(id) {
    if (confirm('Tem certeza que deseja excluir esse registro?')) {
      this.service.deleteCliente(id).subscribe(
        (res) => {
          this.service.refreshList();
          this.toastr.warning(
            'Registro excluído com sucesso!',
            'Cadastro de Clientes'
          );
        },
        (err) => {
          this.toastr.error(
            'Erro ao excluir registro: ' + err,
            'Cadastro de Clientes'
          );
        }
      );
    }
  }

  novoCliente() {
    this.router.navigate(['formulario-cliente']);
  }
}
