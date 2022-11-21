using Radzen;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;
using Equipments.Web.Client.Models;
using Equipments.Domain;

namespace Equipments.Web.Client.Components.MeasureUnits
{
    public partial class EditMeasureUnit
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

        private MeasureUnitUpdateViewModel model = new();

        private bool errorVisible;
        private int dataTypesCount;

        protected override async Task OnInitializedAsync()
        {
            var item = await httpClient.GetFromJsonAsync<MeasureUnitUpdateViewModel>(Routing.MeasureUnits + "for-update/" + Id);

            model.Name = item.Name;
            model.ShortName = item.ShortName;
            model.DataTypes = item.DataTypes;
            model.SelectedDataTypeId = item.SelectedDataTypeId;

            dataTypesCount = model.DataTypes.Count();
        }

        private async Task FormSubmit()
        {
            try
            {
                var item = new MeasureUnitUpdateDto 
                { 
                    Id = Id,
                    Name = model.Name,
                    ShortName = model.ShortName,
                    DataTypeId = model.SelectedDataTypeId
                };

                await httpClient.PutAsJsonAsync(Routing.MeasureUnits + Id, item);
                DialogService.Close(model);
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