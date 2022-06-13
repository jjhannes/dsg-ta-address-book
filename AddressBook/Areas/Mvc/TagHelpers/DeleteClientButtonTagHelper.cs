using AddressBook.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Areas.Mvc.TagHelpers
{
    public class DeleteClientButtonTagHelper : TagHelper
    {
        public Client Client { get; set; }
        public IUrlHelper UrlHelper { get; set; }

        public DeleteClientButtonTagHelper()
        {
            
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string deleteRoute = UrlHelperExtensions.Action(this.UrlHelper, "Delete", "Clients", new { id = this.Client.Id });
            var jsonParam = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Name = this.Client.Name,
                Surname = this.Client.Surname,
                Email = this.Client.Email,
                ContactNumber = this.Client.ContactNumber,
                Company = this.Client.Company,
                DeleteRoute = deleteRoute
            });

            output.TagName = "button";
            output.Attributes.SetAttribute("class", "btn btn-outline-danger btn-sm ms-2 float-end");
            output.Attributes.SetAttribute("onclick", $"confirmDelete({ jsonParam })");
            output.Content.SetContent("Delete");
        }
    }
}
