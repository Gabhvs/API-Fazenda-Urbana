using APIFazendaUrbana.Data;
using APIFazendaUrbana.Services.Cliente;
using APIFazendaUrbana.Services.Fornecedor;
using APIFazendaUrbana.Services.Funcionario;
using APIFazendaUrbana.Services.Login;
using APIFazendaUrbana.Services.Produto;
using APIFazendaUrbana.Services.Vendas;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IClienteInterface, ClienteService>();
builder.Services.AddScoped<IFornecedorInterface, FornecedorService>();
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();
builder.Services.AddScoped<IProdutoInterface, ProdutoService>();
builder.Services.AddScoped<IVendasInterface, VendasService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection"));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
