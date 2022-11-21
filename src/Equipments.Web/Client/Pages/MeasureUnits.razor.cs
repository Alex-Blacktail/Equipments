using Radzen;
using Radzen.Blazor;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Equipments.Web.Client.Models;
using Equipments.Web.Client.Components.MeasureUnits;

namespace Equipments.Web.Client.Pages
{
    public partial class MeasureUnits
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

        private IEnumerable<MeasureUnitDto> list;

        private RadzenDataGrid<MeasureUnitDto> grid;
        private int count;

        private async Task GridLoadData(LoadDataArgs args)
        {
            try
            {
                list = await httpClient.GetFromJsonAsync<MeasureUnitDto[]>(Routing.MeasureUnits);        
                count = list.Count();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"������", Detail = $"���������� ��������� ������" });
            }
        }

        private async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddMeasureUnit>("��������", null);
            await grid.Reload();
        }

        private async Task EditRow(MeasureUnitDto args)
        {
            await DialogService.OpenAsync<EditMeasureUnit>("�������������", new Dictionary<string, object> { {"id", args.Id} });
            await grid.Reload();
        }

        private async Task GridDeleteButtonClick(MouseEventArgs args, MeasureUnitDto model)
        {
            try
            {
                if (await DialogService.Confirm("�� �������, ��� ������ ������� ������ ������?") == true)
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
                    Summary = $"������", 
                    Detail = $"���������� ������� ������" 
                });
            }
        }
    }
}