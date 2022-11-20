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

        protected IEnumerable<DataType> dataTypes;

        protected RadzenDataGrid<DataType> grid0;
        protected int count;

        protected async Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                dataTypes = await httpClient.GetFromJsonAsync<DataType[]>("DataTypes");        
                count = dataTypes.Count();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to load DataTypes" });
            }
        }    

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddDataType>("Add DataType", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataType args)
        {
            await DialogService.OpenAsync<EditDataType>("Edit DataType", new Dictionary<string, object> { {"id", args.Id} });
            await grid0.Reload();
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, DataType dataType)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    //var deleteResult = await EquipmentsService.DeleteDataType(id:dataType.Id);
                    var deleteResult = await httpClient.DeleteAsync("DataTypes/" + dataType.Id);
                    if (deleteResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage
                { 
                    Severity = NotificationSeverity.Error,
                    Summary = $"Error", 
                    Detail = $"Unable to delete DataType" 
                });
            }
        }
    }
}