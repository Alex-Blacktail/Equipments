using Radzen;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Equipments.Web.Client.Models;
using System.Net.Http.Json;
using Equipments.Domain;

namespace Equipments.Web.Client.Components.MeasureUnits
{
    public partial class AddMeasureUnit
    {
#region DefaultRadzen

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

#endregion

        private MeasureUnitCreateViewModel model;
        private int dataTypesCount;
        private bool errorVisible;

        protected override async Task OnInitializedAsync()
        {
            model = new MeasureUnitCreateViewModel();
            try
            {
                model.DataTypes = await httpClient.GetFromJsonAsync<DataType[]>(Routing.DataTypes);
                dataTypesCount = model.DataTypes.Count();
            }
            catch (Exception ex)
            {
                errorVisible = true;
            }
        }

        private async Task FormSubmit()
        {
            try
            {
                var item = new MeasureUnitCreateDto
                {
                    DataTypeId = model.SelectedDataTypeId,
                    Name = model.Name,
                    ShortName = model.ShortName
                };

                await httpClient.PostAsJsonAsync(Routing.MeasureUnits, item);
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