using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Html;
using ForAizhulov.Patterns;

namespace ForAizhulov.HtmlHelpers
{
    internal interface IProductA
    {
        HtmlString ShowSomething(IHtmlHelper html);
    }

    internal interface IProductB
    {
        HtmlString ShowSomething(IHtmlHelper html);
    }

    internal class FirstProductA : IProductA
    {
        public HtmlString ShowSomething(IHtmlHelper html)
        {
            return ListForInformationProger(html);
        }

        public static HtmlString ListForInformationProger(IHtmlHelper html)
        {
            StringSubject stringSubject = new StringSubject();
            Proxy proxy = new Proxy(stringSubject);

            Client client = new Client();

            string[] items = client.ClientCode(proxy, 1);

            string result = "<ul class=\"list-group list-group-flush\">";

            foreach (string item in items)
            {
                result = $"{result}<li class=\"list-group-item\">{item}</li>";
            }

            result = $"{result}</ul>";

            return new HtmlString(result);
        }
    }

    internal class SecondProductA : IProductA
    {
        public HtmlString ShowSomething(IHtmlHelper html)
        {
            return CreateButtons(html);
        }

        public static HtmlString CreateButtons(IHtmlHelper html)
        {
            string[] items = new string[] { "Privacy", "Index", "Errors" };
            string result = "";
            result += "<a href = \"" + items[0] + "\" ><button  class=\"btn btn-primary\" type=\"submit\">Privacy</button></a>";
            result += "<a href = \"" + items[1] + "\" ><button  class=\"btn btn-primary\" type=\"submit\">Index</button></a>";
            result += "<a href = \"" + items[2] + "\" ><button  class=\"btn btn-primary\" type=\"submit\">Errors</button></a>";

            return new HtmlString(result);
        }
    }

    internal class FirstProductB : IProductB
    {
        public HtmlString ShowSomething(IHtmlHelper html)
        {
            return ListForInformationCipher(html);
        }

        public static HtmlString ListForInformationCipher(IHtmlHelper html)
        {
            StringSubject realSubject = new StringSubject();
            Proxy proxy = new Proxy(realSubject);

            Client client = new Client();

            string[] items = client.ClientCode(proxy, 2);

            string result = "<ul class=\"list-group list-group-flush\">";
            foreach (string item in items)
            {
                result = $"{result}<li class=\"list-group-item\">{item}</li>";
            }
            result = $"{result}</ul>";
            return new HtmlString(result);
        }
    }

    internal class SecondProductB : IProductB
    {
        public HtmlString ShowSomething(IHtmlHelper html)
        {
            return ShowImages(html);
        }

        public static HtmlString ShowImages(IHtmlHelper html)
        {
            string[] items = new string[] { "58f6a01695be445d0e40b92f33a0c8b5.jpg", "100x64_3 (1).jpg", "maxresdefault.jpg" };
            string result = "";
            foreach (string item in items)
            {

                result = $"{result}  <img src = \"/images/{item}\" class = \" newimages \">";
            }
            return new HtmlString(result);
        }
    }

    internal interface IFactory
    {
        IProductA GetProductA();
        IProductB GetProductB();
    }
    internal class FirstConcreteFactory : IFactory
    {
        public IProductA GetProductA()
        {
            return new FirstProductA();
        }

        public IProductB GetProductB()
        {
            return new FirstProductB();
        }
    }
    internal class SecondConcreteFactory : IFactory
    {
        public IProductA GetProductA()
        {
            return new SecondProductA();
        }

        public IProductB GetProductB()
        {
            return new SecondProductB();
        }
    }

    internal class Factorys
    {
        private IProductA _productA;
        private IProductB _productB;

        public Factorys(IFactory factory)
        {
            _productA = factory.GetProductA();
            _productB = factory.GetProductB();
        }

        public HtmlString showHtmlHelperA(IHtmlHelper html)
        {
            return this._productA.ShowSomething(html);
        }
        public HtmlString showHtmlHelperB(IHtmlHelper html)
        {
            return this._productB.ShowSomething(html);
        }
    }
}
