# Projeto-API

Objetivo: Desenvolver uma API para de uma fazenda urbana, permitindo operações como criar, edição, buscar e delete.

# Estrutura do Projeto:

## Modelos:
ClienteModel: Representa os clientes, incluindo atributos como ID, nome, email, CPF e senha.

FornecedorModel: Representa os fornecedores, incluindo atributos como ID, nome da empresa, CNPJ, tipo do adubo, agrotoxico, muda fornecidos e suas respectivas quantidades.

FuncionarioModel: Representa os funcionarios, incluindo atributos como ID, nome, CPF e função.

ProdutoModel: Representa os produtos, incluindo atributos como ID, nome do produto, quantidade e preço.

VendasModel: Representa as vendas, incluindo atributos como ID, nome do produto, quantidade vendida, valor total e forma de pagamento. 

## DTOs (Data Transfer Objects):
ClienteCriacaoDto: Utilizado para criar novos clientes, contendo dados necessários como nome, email, CPF e senha.

FornecedorCriacaoDto: Utilizado para criar novos fornecedores, contendo dados necessários como  nome da empresa, CNPJ, tipo do adubo, agrotoxico, muda fornecidos e suas respectivas quantidades.

FuncionarioCriacaoDto: Utilizado para criar novos funcionarios, contendo dados necessários como nome, CPF e função.

FuncionarioEdicaoDto: Utilizado para editar funcionarios existentes, incluindo ID do funcionarios e função.

ProdutoCriacaoDto: Utilizado para criar novos produtos, contendo dados necessários como nome do produto, quantidade e preço.

VendasCriacaoDto: Utilizado para criar novas vendas, contendo dados necessários como nome do produto, quantidade vendida, valor total e forma de pagamento.

## Serviços:
### CLIENTE
IClienteInterface: Define operações para gerenciar clientes.

Métodos como ListarClientes e CriarClientes.

ClienteService: Implementa IClienteInterface e fornece lógica para as operações relacionadas a clientes.

### FUNCIONARIOS
IFuncionarioInterface: Define operações para gerenciar funcionarios.

Métodos como ListarFuncionarios, CriarFuncionario, EditarFuncionario, ExcluirFuncionario.

FuncionarioService: Implementa IFuncionarioInterface e fornece lógica para as operações relacionadas a funcionarios.

### FORNECEDORES
IFornecedorInterface: Define operações para gerenciar fornecedores.

Métodos como ListarFornecedores, CriarFornecedor.

FornecedorService: Implementa IFornecedorInterface e fornece lógica para as operações relacionadas a fornecedores.

### PRODUTOS
IProdutoInterface: Define operações para gerenciar fornecedores.

Métodos como ListarProdutos, EditarProduto, CriarProduto.

ProdutoService: Implementa IFornecedorInterface e fornece lógica para as operações relacionadas a produtos.

### VENDAS
IVendasInterface: Define operações para gerenciar vendas.

Métodos como ListarVendas, CriarVendas.

VendasService: Implementa IVendasInterface e fornece lógica para as operações relacionadas a vendas.

## Funcionalidades:
### CLIENTES
Listar Clientes: Recupera a lista de todos os clientes registrados.

Criar Clientes: Adiciona novos clientes ao banco de dados.

### FUNCIONÁRIOS
Listar Funcionários: Recupera a lista de todos os funcionários registrados.

Criar Funcionários: Adiciona novos funcionários ao banco de dados.

Editar Funcionários: Atualiza as funções de funcionários existentes.

Excluir Funcionários: Remove funcionários do banco de dados.

### FORNECEDORES
Listar Fornecedores: Recupera a lista de todos os fornecedores registrados.

Criar Fornecedores: Adiciona novos fornecedores ao banco de dados.

### PRODUTOS
Listar Produtos: Recupera a lista de todos os produtos registrados.

Criar Produtos: Adiciona novos produtos ao banco de dados.

Editar Produtos: Atualiza as informações de produtos existentes.

### VENDAS
Listar Vendas: Recupera a lista de todas as vendas registradas.

Criar Vendas: Registra novas vendas no sistema.

## Tecnologias Utilizadas:
Entity Framework Core: Para manipulação de dados e acesso ao banco de dados.

ASP.NET Core: Para construção da API.

## Conclusão
O projeto oferece uma API robusta para o gerenciamento de uma fazenda urbana, facilitando operações comuns de CRUD (criar, ler, atualizar, deletar) para clientes, funcionários, fornecedores, produtos e vendas. Com uma estrutura modular e métodos bem definidos, o sistema é escalável e de fácil manutenção, oferecendo flexibilidade para futuras integrações com outras aplicações.
