using System;
using System.Text;
using System.Collections.Generic;

namespace ForAizhulov.Patterns
{
    internal interface IProduct
    {
        string ReturnHtmlString(List<string> ciphersName);
    }

    internal abstract class FactoryCipher
    {
        protected abstract IProduct GetProduct();
    }

    internal class StringKeyCipherProduct: IProduct
    {
        public string ReturnHtmlString(List<string> ciphersName)
        {

            StringBuilder sbResult = new StringBuilder();

            foreach(string cipherName in ciphersName)
            {
                sbResult.Append("<div class='cipher-container__wrapper container d-flex'>");
                sbResult.Append($"<input type='checkbox' name='{cipherName}' id='{cipherName}CipherId' value='true' data-val='true' />");
                sbResult.Append($"<p class='mt-3 ms-1'>{cipherName} Cipher</p>");
                sbResult.Append("</div>");
            }


            return sbResult.ToString();
        }
    }

    internal class IntegerKeyCipherProduct: IProduct
    {
        public string ReturnHtmlString(List<string> ciphersName)
        {
            StringBuilder sbResult = new StringBuilder();

            foreach (string cipherName in ciphersName)
            {
                sbResult.Append("<div class='cipher-container__wrapper container d-flex'>");
                sbResult.Append($"<input type='checkbox' name='{cipherName}' id='{cipherName}CipherId' value='true' data-val='true' />");
                sbResult.Append($"<p class='mt-3 ms-1'>{cipherName} Cipher</p>");
                sbResult.Append("</div>");
            }
            
            return sbResult.ToString();
        }
    }
    internal interface IStrategy
    {
        string ReturnHtmlString(List<string> ciphersName);
    }

    internal class Context
    {
        private IStrategy _strategy;

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public string GetHtmlString(List<string> ciphersName)
        {

            if (_strategy != null)
            {
                return this._strategy.ReturnHtmlString(ciphersName);
            }

            return "";
        }
    }

    internal class SetStringKeyStrategy: FactoryCipher, IStrategy
    {
        protected override IProduct GetProduct()
        {
            return new StringKeyCipherProduct();
        }
        
        public string ReturnHtmlString(List<string> ciphersName)
        {
            return GetProduct().ReturnHtmlString(ciphersName);
        }
    }

    internal class SetIntKeyStrategy: FactoryCipher, IStrategy
    {
        protected override IProduct GetProduct()
        {
            return new IntegerKeyCipherProduct();
        }
        public string ReturnHtmlString(List<string> ciphersName)
        {
            return GetProduct().ReturnHtmlString(ciphersName);
        }
    }
}
