import { Cliente } from './cliente.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ClienteService {
  formData: Cliente = {
    Id: 0,
    Nome: null,
    DataDeNascimento: null,
    Sexo: null,
    CEP: null,
    Endereco: null,
    Numero: null,
    Complemento: null,
    Bairro: null,
    Estado: null,
    Cidade: null,
  };
  readonly rootURL = 'https://localhost:44379/api';
  list: Cliente[];
  public readonly: boolean;

  constructor(private http: HttpClient) {}

  postCliente() {
    return this.http.post(this.rootURL + '/Clientes', this.formData);
  }

  putCliente() {
    return this.http.put(
      this.rootURL + '/Clientes/' + this.formData.Id,
      this.formData
    );
  }

  refreshList() {
    this.http
      .get(this.rootURL + '/Clientes')
      .toPromise()
      .then((res) => (this.list = res as Cliente[]));
  }

  getClienteById(id: number) {
    return this.http.get(this.rootURL + '/Clientes/' + id);
  }

  deleteCliente(id) {
    return this.http.delete(this.rootURL + '/Clientes/' + id);
  }

  consultaCep(cep: string) {
    return this.http.get(`//viacep.com.br/ws/${cep}/json`);
  }
}
