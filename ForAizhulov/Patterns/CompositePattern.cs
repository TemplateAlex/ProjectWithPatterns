using System;
using System.Collections.Generic;

namespace ForAizhulov.Patterns
{
    //In this part code for composite pattern
    internal interface IComponent
    {
        void AddComponentCipher(IComponent component);
        void AddCipher(ICipher cipher);
        void RemoveComponentCipher(IComponent component);
        public bool IsDone();
        IComponent GetElement();
        IComponent GetNextElement();
        IIterator CreateIterator();
        string EncryptWord(string word, string key);
        string DecryptWord(string word, string key);
    }

    internal class CipherRoot: IComponent
    {
        private List<IComponent> components = new List<IComponent>();
        private ICipher _cipher;
        private int count = 0;

        public IIterator CreateIterator()
        {
            return new Iterator(this);
        }

        public IComponent GetElement()
        {
            return components[count];
        }

        public IComponent GetNextElement()
        {
            count++;
            return GetElement();

        }

        public bool IsDone()
        {
            if (count == components.Count - 1) return true;
            return false;
        }
        
        public void AddComponentCipher(IComponent component)
        {
            components.Add(component);
        }

        public void AddCipher(ICipher cipher)
        {
            this._cipher = cipher;
        }

        public void RemoveComponentCipher(IComponent component)
        {
            components.Remove(component);
        }

        public string EncryptWord(string word, string key)
        {
            return this._cipher.Encrypt(word, "");
        }

        public string DecryptWord(string word, string key)
        {
            return this._cipher.Decrypt(word);
        }
    }

    internal class LeafCipher : IComponent
    {
        private ICipher _cipher;

        public void AddCipher(ICipher cipher)
        {
            this._cipher = cipher;
        }
        public void AddComponentCipher(IComponent component)
        {
            throw new NotImplementedException();
        }

        public IIterator CreateIterator()
        {
            return new Iterator(this);
        }

        public string DecryptWord(string word, string key)
        {
            return this._cipher.Decrypt(word, key);
        }

        public string EncryptWord(string word, string key)
        {
            return this._cipher.Encrypt(word, key);
        }

        public IComponent GetElement()
        {
            return this;
        }

        public IComponent GetNextElement()
        {
            throw new NotImplementedException();
        }

        public bool IsDone()
        {
            throw new NotImplementedException();
        }

        public void RemoveComponentCipher(IComponent component)
        {
            throw new NotImplementedException();
        }
    }
}
