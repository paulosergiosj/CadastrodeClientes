import { Component, OnInit } from '@angular/core';
import { ClienteService } from 'src/app/shared/cliente.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/app/shared/cliente.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styles: [],
})
export class ClienteComponent implements OnInit {
  constructor(
    public service: ClienteService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit() {
    if (this.service.formData == null) {
      this.novoCliente();
    }
  }

  consultaCEP(cep: string) {
    cep = cep.replace(/\D/g, '');

    if (cep !== '') {
      return this.service.consultaCep(cep).subscribe(
        (res) => {
          this.popularFormComDadosCep(res);
        },
        (err) => {
          this.toastr.error(
            'Erro ao consultar CEP. Verifique o CEP digitado e tente novamente.',
            'Cadastro de Clientes'
          );
          this.removerDadosDeEndereco();
        }
      );
    }
  }

  popularFormComDadosCep(dados) {
    this.service.formData.Endereco = dados.logradouro;
    this.service.formData.CEP = dados.cep;
    this.service.formData.Complemento = dados.complemento;
    this.service.formData.Bairro = dados.bairro;
    this.service.formData.Cidade = dados.localidade;
    this.service.formData.Estado = dados.uf;
  }

  removerDadosDeEndereco() {
    this.service.formData.Endereco = '';
    this.service.formData.CEP = '';
    this.service.formData.Complemento = '';
    this.service.formData.Bairro = '';
    this.service.formData.Cidade = '';
    this.service.formData.Estado = '';
    this.service.formData.Numero = null;
  }

  novoCliente(form?: NgForm) {
    if (form != null) form.resetForm();
    this.service.formData = {
      Id: 0,
      Nome: '',
      DataDeNascimento: null,
      Sexo: '',
      CEP: '',
      Endereco: '',
      Numero: 0,
      Complemento: '',
      Bairro: '',
      Estado: '',
      Cidade: '',
    };
  }

  onSubmit() {
    if (this.service.formData.Id == 0 || this.service.formData.Id == undefined)
      this.inserirCliente();
    else this.alterarCliente();
  }

  inserirCliente() {
    this.service.postCliente().subscribe(
      (res) => {
        this.toastr.success(
          'Cliente cadastrado com sucesso!',
          'Cadastro de Clientes'
        );
        this.paginaInicial();
      },
      (err) => {
        this.toastr.error('Erro ao inserir cliente', 'Cadastro de Clientes');
      }
    );
  }

  alterarCliente() {
    this.service.putCliente().subscribe(
      (res) => {
        this.toastr.success(
          'Requisição enviada com sucesso!',
          'Cadastro de Clientes'
        );
        this.paginaInicial();
      },
      (err) => {
        this.toastr.error('Erro ao alterar cliente', 'Cadastro de Clientes');
      }
    );
  }

  paginaInicial() {
    this.service.formData = new Cliente();
    this.service.readonly = false;
    this.router.navigate(['']);
  }
}
