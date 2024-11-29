using ApiAngular.Models;

namespace ApiAngular.Rotas;

public static class PessoaRotas
{
    public static List<Pessoa> Pessoas = new()
    {
        new("Neymar"),
        new("Martinez"),
        new("Michael"),
        new("Morris"),
        new("Messi"),
        new("Cristiano")
    };
    public static void AddPessoasRoutes(this WebApplication app)
    {
        app.MapGet("pessoas", () => Pessoas);
        app.MapGet("pessoas/{nome}", (string nome) =>
        {
            return Pessoas.Find(p => p.Nome == nome);
        });

        app.MapPost("pessoas", (Pessoa pessoa, HttpContext context) =>
        {
            var contexto = context;
            Pessoas.Add(pessoa);
            return Results.Created($"pessoas/{pessoa.Nome}", pessoa);
        });

        app.MapPut("pessoas/{id:guid}", (Guid id, Pessoa pessoa) =>
        {
            var encontrado = Pessoas.Find(p => p.Id == id);

            if (encontrado is null)
            {
                return Results.NotFound();
            }
            
            encontrado.Nome = pessoa.Nome;
            return Results.NoContent();
        });
    }
}