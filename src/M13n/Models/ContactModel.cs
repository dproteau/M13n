using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DataAnnotationsExtensions;
using M13n.Resources;
using M13n.Resources.Views;

namespace M13n.Models
{
    public class ContactModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [StringLength(50, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "MaxLength")]
        [Display(ResourceType = typeof(HomeStrings), Name = "Contact_NameLabel")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [StringLength(50, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "MaxLength")]
        [Email(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "EmailAddress")]
        [Display( ResourceType = typeof(HomeStrings), Name = "Contact_EmailLabel")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [StringLength(25, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "MaxLength")]
        [Display( ResourceType = typeof(HomeStrings), Name = "Contact_SubjectLabel")]
        public string Subject { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "Required")]
        [StringLength(250, ErrorMessageResourceType = typeof(ValidationErrors), ErrorMessageResourceName = "MaxLength")]
        [DataType(DataType.MultilineText)]
        [Display( ResourceType = typeof(HomeStrings), Name = "Contact_MessageLabel")]
        public string Message { get; set; }

    }
}