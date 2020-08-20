# CadastrodeClientes
Cadastro de Clientes com front em Angular e API REST em .NET. Banco de dados MySql usando Migrations.

Para alterar a URL da API .net no angular:
Arquivo 'cliente.service.ts', linha 22.

A API .net usa Cors (Compartilhamento de recursos entre origens).
Caso necessário, alterar a URL da API angular na API .net:
Arquivo 'StartUp.cs', linha 59.

Para alterar os dados de conexão do banco:
Alterar arquivo 'appsettings.json', linha 11.
