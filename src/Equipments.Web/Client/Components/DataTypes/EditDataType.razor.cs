using Radzen;
using Equipments.Domain;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;
using Equipments.Web.Client.Models;

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

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var dataType = await httpClient.GetFromJsonAsync<DataType>(Routing.DataTypes + Id);

            dataTypeDto.Name = dataType.Name;
            dataTypeDto.CodeName = dataType.CodeName;
        }

        private DataTypeDto dataTypeDto = new();
        private bool errorVisible;

        private async Task FormSubmit()
        {
            try
            {
                await httpClient.PutAsJsonAsync(Routing.DataTypes + Id, dataTypeDto);
                DialogService.Close(dataTypeDto);
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