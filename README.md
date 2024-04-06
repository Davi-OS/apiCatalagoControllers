# Projeto de Gestão de Catálogo de Produtos com API em .NET

Bem-vindo ao repositório do projeto de gestão de catálogo de produtos com uma API em .NET! Esse projeto possui a ideia de praticar e entender uma API em .NET utilizando controllers para gerenciar um catálogo de produtos e categorias. Além disso, a aplicação realiza operações CRUD no banco de dados MySQL hospedado na plataforma Azure, utilizando o Entity Framework para a interação com o banco de dados.

## Funcionalidades

1. **Produtos e Categorias**: A API permite o gerenciamento de produtos e categorias, proporcionando a criação, leitura, atualização e exclusão de registros.

2. **Banco de Dados na Azure**: O projeto utiliza o banco de dados MySQL hospedado na plataforma Azure, garantindo uma infraestrutura escalável e confiável.

3. **Entity Framework**: O Entity Framework é utilizado para simplificar e agilizar o acesso aos dados no banco de dados, facilitando a interação com o sistema de gerenciamento.

4. **Swagger para Documentação de API**: O projeto inclui a integração do Swagger, permitindo a visualização e interação com os endpoints da API de forma fácil e documentada.
   
## Acesssando a Aplicação
Acesse o link para conferir e interagir com os endpoints da API:
   
https://apicatalogoprod.azurewebsites.net/swagger/index.html

## Rodando Localmente

Caso deseja clonar o repositorio certifique-se de ter as seguintes ferramentas instaladas antes de executar o projeto:

- Visual Studio (ou Visual Studio Code) com suporte a desenvolvimento .NET.
- Conta na plataforma Azure com um banco de dados MySQL configurado.

## Configuração

1. Clone o repositório para sua máquina local.
   ```
   git clone https://github.com/seu-usuario/nome-do-repositorio.git
   ```

2. Abra o projeto no Visual Studio ou Visual Studio Code.

3. Configure as credenciais do banco de dados na Azure no arquivo `appsettings.json`.

4. Execute o projeto.



## Endpoints da API

A API oferece os seguintes endpoints principais:

- `GET /api/produtos`: Obtém a lista de todos os produtos.
- `GET /api/produtos/{id}`: Obtém detalhes de um produto específico.
- `POST /api/produtos`: Cria um novo produto.
- `PUT /api/produtos/{id}`: Atualiza os detalhes de um produto existente.
- `DELETE /api/produtos/{id}`: Exclui um produto.

- `GET /api/categorias`: Obtém a lista de todas as categorias.
- - `GET /api/categorias/produtos`: Obtém a lista de todas as categorias e seus respectivos produtos.
- `GET /api/categorias/{id}`: Obtém detalhes de uma categoria específica.
- `POST /api/categorias`: Cria uma nova categoria.
- `PUT /api/categorias/{id}`: Atualiza os detalhes de uma categoria existente.
- `DELETE /api/categorias/{id}`: Exclui uma categoria. 
--- 
