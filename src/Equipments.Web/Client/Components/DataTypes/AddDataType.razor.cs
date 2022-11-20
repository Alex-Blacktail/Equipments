using Radzen;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Equipments.Web.Shared;
using System.Net.Http.Json;

namespace Equipments.Web.Client.Components.DataTypes
{
    public partial class AddDataType
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

        protected override async Task OnInitializedAsync()
        {
            dataTypeDto = new DataTypeDto();
        }

        protected DataTypeDto dataTypeDto;
        protected bool errorVisible;

        protected async Task FormSubmit()
        {
            try
            {
                await httpClient.PostAsJsonAsync("DataTypes", dataTypeDto);
                DialogService.Close(dataTypeDto);
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