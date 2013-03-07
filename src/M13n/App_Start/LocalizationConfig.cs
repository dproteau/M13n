using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M13n
{

    /// <summary>
    /// 
    /// </summary>
    public static class LocalizationConfig
    {
        public static void RegisterLocalization()
        {
            // String resource for: PropertyValueInvalid & PropertyValueRequired
            DefaultModelBinder.ResourceClassKey = "ValidationMessages";
            // String resource for: FieldMustBeDate & FieldMustBeNumeric
            ClientDataTypeModelValidatorProvider.ResourceClassKey = "ValidationMessages";
        }

    }
}