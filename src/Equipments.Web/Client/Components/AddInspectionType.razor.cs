using Radzen;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Equipments.Web.Client.Models;
using System.Net.Http.Json;

namespace Equipments.Web.Client.Components
{
    public partial class AddInspectionType
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

        private SomeTypeDto typeDto;
        private bool errorVisible;

        protected override async Task OnInitializedAsync()
        {
            typeDto = new SomeTypeDto();
        }

        private async Task FormSubmit()
        {
            try
            {
                await httpClient.PostAsJsonAsync(Routing.InspectionTypes, typeDto);
                DialogService.Close(typeDto);
            }
            catch (Exception ex)
            {
                errorVisible = true;
            }
        }

        private async Task CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}