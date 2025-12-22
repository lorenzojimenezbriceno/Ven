using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Ven.Frontend.Repositories;
using Ven.Shared.Entities;

namespace Ven.Frontend.Pages.Countries;

public partial class EditCountry
{
    [Inject] private IRepository _repository { get; set; } = null!;
    [Inject] private NavigationManager _navigationManager { get; set; } = null!;
    [Inject] private SweetAlertService _sweetAlert { get; set; } = null!;

    private Country? Country;

    private FormCountry? FormCountry { get; set; }

    [Parameter]
    public int Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var responseHTTP = await _repository.GetAsync<Country>($"api/countries/{Id}");

        if (responseHTTP.Error)
        {
            var messageError = "";
            if (responseHTTP.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                messageError = "Registro No Encontrado";
            }
            else
            {
                messageError = await responseHTTP.GetErrorMessageAsync();
            }
            await _sweetAlert.FireAsync("Error", messageError, SweetAlertIcon.Error);

            _navigationManager.NavigateTo("/countries");
        }
        else
        {
            Country = responseHTTP.Response;
        }
    }

    private async Task Edit()
    {
        var responseHttp = await _repository.PutAsync<Country>($"/api/countries", Country!);
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