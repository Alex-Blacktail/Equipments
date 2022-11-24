using Radzen;
using Radzen.Blazor;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Equipments.Web.Client.Models;
using Equipments.Web.Client.Components.MeasureUnits;
using Equipments.Web.Client.Models.Components;
using Equipments.Domain.Components;

namespace Equipments.Web.Client.Pages
{
    public partial class ComponentTypeProperties
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        [Inject]
        protected DialogService DialogService { get; set; }
        [Inject]
        protected TooltipService TooltipService { get; set; }
        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }
        [Inject]
        protected NotificationService NotificationService { get; set; }

        private ComponentTypePropertiesViewModel viewModel = new();

        private RadzenDataGrid<ComponentTypePropertyViewModel> grid;
        private int count;

        private async Task GridLoadData(LoadDataArgs args)
        {
            try
            {
                viewModel.ComponentTypes = await httpClient.GetFromJsonAsync<SomeTypeDto[]>(Routing.ComponentTypes);
                viewModel.ComponentTypeId = viewModel.ComponentTypes.First().Id;
                if (viewModel.ComponentTypes.Count() > 0)
                {
                    viewModel = await httpClient.GetFromJsonAsync<ComponentTypePropertiesViewModel>(
                                Routing.ComponentTypeProperties + "type/" + viewModel.ComponentTypeId);

                    count = viewModel.ComponentTypeProperties.Count();
                }
                
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Ошибка", Detail = $"Невозможно загрузить данные" });
            }
        }

        private async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddMeasureUnit>("Добавить", null);
            await grid.Reload();
        }

        private async Task EditRow(ComponentTypePropertyViewModel args)
        {
            await DialogService.OpenAsync<EditMeasureUnit>("Редактировать", new Dictionary<string, object> { {"id", args.Id} });
            await grid.Reload();
        }

        private async Task GridDeleteButtonClick(MouseEventArgs args, ComponentTypePropertyViewModel model)
        {
            try
            {
                if (await DialogService.Confirm("Вы уверены, что хотите удалить данную запись?") == true)
                {
                    var deleteResult = await httpClient.DeleteAsync(Routing.MeasureUnits + model.Id);
                    if (deleteResult != null)
                    {
                        await grid.Reload();
                    }
                }
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage
                { 
                    Severity = NotificationSeverity.Error,
                    Summary = $"Ошибка", 
                    Detail = $"Невозможно удалить запись" 
                });
            }
        }

        private void RefreshGrid(object value)
        {

        }
    }
}