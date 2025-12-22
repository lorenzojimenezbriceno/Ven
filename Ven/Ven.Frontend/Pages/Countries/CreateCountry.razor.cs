using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Ven.Frontend.Repositories;
using Ven.Shared.Entities;

namespace Ven.Frontend.Pages.Countries;

public partial class CreateCountry
{
    [Inject] private IRepository _repository { get; set; } = null!;
    [Inject] private NavigationManager _navigationManager { get; set; } = null!;
    [Inject] private SweetAlertService _sweetAlert { get; set; } = null!;

    private Country Country = new();

    private FormCountry? FormCountry { get; set; }

    private async Task Create()
    {
        var responseHttp = await _repository.PostAsync<Country>($"/api/countries", Country);
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            await _sweetAlert.FireAsync("Error", message, SweetAlertIcon.Error);
            return;
        }

        FormCountry!.FormPostedSuccessfully = true;
        _navigationManager.NavigateTo("/countries");
    }

    private void ReturnAction()
    {
        FormCountry!.FormPostedSuccessfully = true;
        _navigationManager.NavigateTo("/countries");
    }
}