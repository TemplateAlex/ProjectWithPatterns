namespace ForAizhulov.Patterns
{
    internal interface ISubject
    {
        string[] Request(int choice);
    }

    internal class StringSubject: ISubject
    {
        public string[] programmersNames = new string[] { "Аметов Дамир", "Еволенко Алексей", "Мендешев Темирлан" };
        public string[] namesCiphers = new string[] { "Atbash", "Caesar", "ADFGX", "Visiner","XOR" };

        public string[] Request(int choice)
        {
            Context context = new Context();

            if (choice == 1) return programmersNames;

            IStrategy strategy = new SetStringKeyStrategy();
            context.SetStrategy(strategy);

            string[] inputsCiphers = new string[namesCiphers.Length];

            int tmp = namesCiphers.Length - 1;

            for (int i = 0; i < namesCiphers.Length - 1; i++)
            {
                List<string> nameStringKeyCipher = new List<string>();
                nameStringKeyCipher.Add(namesCiphers[i]);
                inputsCiphers[i] = context.GetHtmlString(nameStringKeyCipher); 
            }

            strategy = new SetIntKeyStrategy();
            context.SetStrategy(strategy);

            for (int i = tmp; i < namesCiphers.Length; i++)
            {
                List<string> nameIntKeyCipher = new List<string>();
                nameIntKeyCipher.Add(namesCiphers[i]);
                inputsCiphers[i] = context.GetHtmlString(nameIntKeyCipher);
            }

            return inputsCiphers;
        }
    }

    internal class Proxy: ISubject
    {
        private StringSubject _stringSubject;

        public Proxy(StringSubject stringSubject)
        {
            this._stringSubject = stringSubject;
        }

        public string[] Request(int choice)
        {
            if (this.CheckAccess(choice))
            {
                return this._stringSubject.Request(choice);
            }
            else return null!;
        }

        public bool CheckAccess(int choice)
        {
            bool checker = true;

            if (choice == 1)
            {
                foreach (var item in _stringSubject.programmersNames)
                {
                    if (item.GetType() == typeof(string)) checker = true;
                    else
                    {
                        checker = false;
                        break;
                    }
                }
            }
            else
            {
                foreach (var item in _stringSubject.namesCiphers)
                {
                    if (item.GetType() == typeof(string)) checker = true;
                    else
                    {
                        checker = false;
                        break;
                    }
                }
            }

            return checker;
        }
    }

    internal class Client
    {
        public string[] ClientCode(ISubject subject, int choice)
        {
            return subject.Request(choice);
        }
    }
}
