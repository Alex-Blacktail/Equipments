using Radzen;
using Equipments.Domain;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;
using Equipments.Web.Client.Models;

namespace Equipments.Web.Client.Components
{
    public partial class EditInspectionType
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

        [Parameter]
        public int Id { get; set; }

        private SomeTypeDto typeDto = new();
        private bool errorVisible;

        protected override async Task OnInitializedAsync()
        {
            var dataType = await httpClient.GetFromJsonAsync<DataType>(Routing.InspectionTypes + Id);

            typeDto.Name = dataType.Name;
        }

        private async Task FormSubmit()
        {
            try
            {
                await httpClient.PutAsJsonAsync(Routing.InspectionTypes + Id, typeDto);
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