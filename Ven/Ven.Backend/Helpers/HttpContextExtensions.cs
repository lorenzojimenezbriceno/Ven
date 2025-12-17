using Microsoft.EntityFrameworkCore;

namespace Ven.Backend.Helpers;

public static class HttpContextExtensions
{
    public async static Task InsertParameterPagination<T>(this HttpContext context, IQueryable<T> queryable, int cantidadRegistrosAMostrar)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        double conteo = await queryable.CountAsync();
        double totalPaginas = Math.Ceiling(conteo / cantidadRegistrosAMostrar);

        // Se pasa la cantidad de registros y total de páginas en el encabezado http
        context.Response.Headers.Append("Counting", conteo.ToString());
        context.Response.Headers.Append("TotalPages", totalPaginas.ToString());
    }
}
