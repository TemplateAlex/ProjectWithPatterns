namespace ForAizhulov.Patterns
{
    internal interface IStrategy
    {
        string DoSomething();
    }

    internal class Context
    {
        private IStrategy _strategy;

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void DoSomething()
        {
            if (this._strategy != null)
            {
                this._strategy.DoSomething();
            }
        }
    }

    internal class FirstStrategy: IStrategy
    {
        //Создание объекта первой фабрики
        public string DoSomething()
        {
            //Создание первого продукта и вызов его метода
            return ""; //Возвращение строчки состоящей из HTML кода (пока, хезе чего)
        }
    }

    internal class SecondStrategy: IStrategy
    {
        //Создание объекта первой фабрики
        public string DoSomething()
        {
            //Создание первого продукта и вызов его метода
            return ""; //Возвращение строчки состоящей из HTML кода (пока, хезе чего)
        }
    }
}
