# BancoDigital
Implementação de uma API utilizando algumas funcionalides de um Banco Digital.

- Tecnologias Utilizadas.
- dotnet core 5
- entity framework core
- Mysql
- Xunit
- Docker
- Swagger


# Instalação e Execução
Instale a versão do dotnet 5.0 no site https://dotnet.microsoft.com/download 
Instale o Banco de dados mysql  https://www.mysql.com/downloads/ 

Após as instalações acima feitas corretamente faça o clone do projeto
Modifique a connection string  que fica localizada no arquivo appsettings.json de acordo com a sua configuraçao do Mysql
Execute a o projeto através da sua IDE de preferência ou terminal
Ao executar a API uma interface criada pelo Swagger aparecerá com as acões da API

# Funcionalidades da API

GET /api/Contas/{conta} -Obtém o saldo existente da conta informada

PUT /api/Depositar -Realiza um depósito de uma quantia na conta especificada e retorna o saldo atualizado

PUT /api/Depositar/sacar -Realiza o saque  de uma quantia na conta especificada e retorna o saldo atualizado, caso o saque seja maior do que o valor da conta retorna uma mensagem de erro "Saldo insuficiente"


As funcionalidades da API foram testadas utulizando testes Unitarios que se encontram no projeto  e o Postman 









