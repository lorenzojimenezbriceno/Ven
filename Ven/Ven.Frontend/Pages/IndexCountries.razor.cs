using Microsoft.AspNetCore.Components;
using Ven.Frontend.Repositories;
using Ven.Shared.Entities;

namespace Ven.Frontend.Pages;

public partial class IndexCountries
{
    [Inject] private IRepository _repository { get; set; }

    public List<Country>? Countries { get; set; }

    protected async override Task OnInitializedAsync()
    {
        await Task.Delay(5000);
        var responseHttp = await _repository.GetAsync<List<Country>>("/api/countries");
        Countries = responseHttp.Response;
    }
}