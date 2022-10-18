using System;
using System.Collections.Generic;
using ForAizhulov.Patterns;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;

namespace ForAizhulov.HtmlHelpers
{
    internal static class HtmlHelperForCipher
    {
        public static HtmlString SetCheckBoxes(this IHtmlHelper html, IStrategy strategy, List<string> ciphersName)
        {
            Context context = new Context();
            context.SetStrategy(strategy);

            return new HtmlString(context.GetHtmlString(ciphersName));
        }
    }
}
