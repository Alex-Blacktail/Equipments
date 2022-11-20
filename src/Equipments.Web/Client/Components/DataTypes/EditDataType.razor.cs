using Radzen;
using Equipments.Domain;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;

namespace Equipments.Web.Client.Components.DataTypes
{
    public partial class EditDataType
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

        //[Inject]
        //public EquipmentsService EquipmentsService { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            dataType = await httpClient.GetFromJsonAsync<DataType>("DataTypes");
        }

        protected bool errorVisible;
        protected DataType dataType;

        protected async Task FormSubmit()
        {
            try
            {
                await httpClient.PutAsJsonAsync("DataTypes", dataType);
                DialogService.Close(dataType);
            }
            catch (Exception ex)
            {
                errorVisible = true;
            }
        }

        protected async Task CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}