using Radzen;
using Radzen.Blazor;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Equipments.Web.Client.Models;
using Equipments.Web.Client.Components;

namespace Equipments.Web.Client.Pages
{
    public partial class InspectionTypes
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

        private IEnumerable<SomeTypeDto> types;

        private RadzenDataGrid<SomeTypeDto> grid;
        private int count;

        private async Task GridLoadData(LoadDataArgs args)
        {
            try
            {
                types = await httpClient.GetFromJsonAsync<SomeTypeDto[]>(Routing.InspectionTypes);        
                count = types.Count();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Ошибка", Detail = $"Невозможно удалить запись" });
            }
        }

        private async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddInspectionType>("Добавить вид состояния", null);
            await grid.Reload();
        }

        private async Task EditRow(SomeTypeDto args)
        {
            await DialogService.OpenAsync<EditInspectionType>("Редактировать вид состояния", new Dictionary<string, object> { {"id", args.Id} });
            await grid.Reload();
        }

        private async Task GridDeleteButtonClick(MouseEventArgs args, SomeTypeDto type)
        {
            try
            {
                if (await DialogService.Confirm("Вы действительно хотите удалить выбранную запись?") == true)
                {
                    var deleteResult = await httpClient.DeleteAsync(Routing.InspectionTypes + type.Id);
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
    }
}