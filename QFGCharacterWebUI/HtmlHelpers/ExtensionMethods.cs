using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitCollectors.QfgCharacterEditor.WebUI.HtmlHelpers
{
    public static class ExtensionMethods
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e, Name = e.ToString() };

            return new SelectList(values, "Id", "Name", enumObj);
        }

        public static SelectList ToSelectList<TEnum>(this TEnum enumObj, string except)
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         where e.ToString() != except
                         select new { Id = e, Name = e.ToString() };

            return new SelectList(values, "Id", "Name", enumObj);
        }
    }
}