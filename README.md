API - CustomerCore
objetivo
Desenvolver um aplicativo para Cadastro de Clientes usando swagger e api.

• Pontos finais:
2.1. POST /api/v1/Customer/create Json { “cpf”: “string” “name”: “string”, “dateOfBirth”: “1980-04-04” }
2.2. GET /api/v1/Customer/exists/cpf/{cpf}
2.3. GET /api/v1/Customer/exists/date-of-birth/{dateofbirth}/cpf/{cpf}
💻Informações Técnicas
Para rodar este projeto, será necessário instalar:

Visual Studio 2022: editor de código para executar a aplicação.

# Atualização do Projeto https://github.com/amrodrigues/Customer que usava o .NetFramework para o .Net6 utilziando o EntityFrameworkCore.


Melhorias:
1- Projeto em fase de Debug. 
2 - Na Camada de apresentação melhorar a validação do campo data de nascimento.
3 - Corrigir o erro de excução do comando Script-Migrations na Camada Projeto.Repository
4 - Fazer Camada de testes.
