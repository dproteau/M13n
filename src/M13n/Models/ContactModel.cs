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
        [Required(ErrorMessageResourceType = typeof(SharedStrings), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(SharedStrings), ErrorMessageResourceName = "MaxLengthField")]
        [Display(ResourceType = typeof(HomeStrings), Name = "ContactFormNameLabel")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedStrings), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(SharedStrings), ErrorMessageResourceName = "MaxLengthField")]
        [Email( ErrorMessageResourceType = typeof(SharedStrings), ErrorMessageResourceName = "EmailField")]
        [Display( ResourceType = typeof(HomeStrings), Name = "ContactFormEmailLabel")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedStrings), ErrorMessageResourceName = "RequiredField")]
        [StringLength(25, ErrorMessageResourceType = typeof(SharedStrings), ErrorMessageResourceName = "MaxLengthField")]
        [Display( ResourceType = typeof(HomeStrings), Name = "ContactFormSubjectLabel")]
        public string Subject { get; set; }

        [Required( ErrorMessageResourceType = typeof(SharedStrings), ErrorMessageResourceName = "RequiredField")]
        [StringLength(250, ErrorMessageResourceType = typeof(SharedStrings), ErrorMessageResourceName = "MaxLengthField")]
        [DataType(DataType.MultilineText)]
        [Display( ResourceType = typeof(HomeStrings), Name = "ContactFormMessageLabel")]
        public string Message { get; set; }

    }
}