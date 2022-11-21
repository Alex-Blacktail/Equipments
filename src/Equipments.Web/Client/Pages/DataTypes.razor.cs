using Radzen;
using Radzen.Blazor;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Equipments.Domain;
using Equipments.Web.Client.Components.DataTypes;

namespace Equipments.Web.Client.Pages
{
    public partial class DataTypes
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

        private IEnumerable<DataType> dataTypes;

        private RadzenDataGrid<DataType> grid;
        private int count;

        private async Task GridLoadData(LoadDataArgs args)
        {
            try
            {
                dataTypes = await httpClient.GetFromJsonAsync<DataType[]>(Routing.DataTypes);        
                count = dataTypes.Count();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"������", Detail = $"���������� ������� ������" });
            }
        }

        private async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddDataType>("�������� ��� ������", null);
            await grid.Reload();
        }

        private async Task EditRow(DataType args)
        {
            await DialogService.OpenAsync<EditDataType>("������������� ��� ������", new Dictionary<string, object> { {"id", args.Id} });
            await grid.Reload();
        }

        private async Task GridDeleteButtonClick(MouseEventArgs args, DataType dataType)
        {
            try
            {
                if (await DialogService.Confirm("�� ������������� ������ ������� ��������� ������?") == true)
                {
                    var deleteResult = await httpClient.DeleteAsync(Routing.DataTypes + dataType.Id);
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