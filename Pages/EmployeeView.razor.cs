using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorValidation.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Radzen;

namespace BlazorValidation.Pages
{
    public class EmployeeViewPageModel : OwningComponentBase<DataAdaptor>
    {
        protected Employee Model { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Model = Service.Get();
        }

        /// <summary>
        /// Kaydetme işlemleri burada yapılır
        /// </summary>
        protected void OnSaveClick()
        { }

    }
}
