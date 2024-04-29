
# App Cadastro de Empresas Parceiras

Este sistema contem uma feature de gerenciamento de clientes parceiros, e inclusão de seus logotipos , bem como o cadastro de suas filiais

## Feature implementada:

Gerenciamento de clientes API , Logotipo e Endereço
aplicacao em Razor que consome as apis

### Tecnologias utilizadas:

 
- Net Core 6
- DB SQl Server
- Razor
- Visual Studio 2019
- Entity Framerwork 6

### Como executar

Para executar o projeto:


##Para o Banco de Dados
Criar uma banco de dados chamado EmpresaPadrao, em SQL Server
Configurar nos 2 projetos a connection string 

Buildar a Aplicação , 

Verificar se o dotnet ef , entity FramerworkCore foi instalado para acessar os comandos de migration:

dotnet ef database update


##Para Aplicação
A aplicação resolvi criar uma solução com 2 projetos separados
um seria o projeto API, para funcionar independente e ser acessado por outras aplicações;

O outro projeto seria para visualização , usando razor pages, porem esta serve apenas como tecnologia solicitada , nao usando o método convencional no padrão MVC , que acessa diretamente o Context da aplicação , para gerenciamento de dados.

Todo seu consumo será através de chamadas AJAX das Apis , criandas anteriormente.

Nao houve aplicação de css ou outras adiçõe em HTML , apenas o demonstrativo das funcionalidades 

O projeto foi configurado para rodar simultaneamente nas portas

API : 5100
Web : 5002











