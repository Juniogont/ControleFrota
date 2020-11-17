# Teste
Aplicação que gerencia um frota


#### Tecnologias utilizadas

- ASP.NET Core 3.1 MVC
- ORM (Entity Framework Core (Code First Aproach)
- SQL Server
- xUnit (Testes Unitários)
- LINQ
- Lambda Expressions
- interfaces
- Herança
- modificadores de acesso
- Cookie-based authentication
- Camadas 
	- BLL (Business)
	- MDL (Model)
	- UI (User Interface)
	- Test (Testes Unitários)

#### Instruções 
    
	-Alterar a ConnectionString com um servidor SQL Server Válido
	Arquivos: 
		Startup.cs:
		Linha 24 - var connection = @"Server = DESKTOP-G9N4BMQ\SQLEXPRESS; Database = ControleFrotaDb; Trusted_Connection = True; ";
		ControleFrotaContext:
		Linha 17 - protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Server = DESKTOP-G9N4BMQ\SQLEXPRESS; Database = ControleFrotaDb; Trusted_Connection = True; ");
	- Rodar o migration para criar as tabelas no DB
	- Caso saia da aplicação, clicar novamente no nome do sistema "Controle de Frota" irá logar novamente;


