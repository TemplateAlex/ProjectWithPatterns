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
        IComponent GetElement();
        IComponent GetNextElement();
        IIterator CreateIterator();
        string EncryptWord(string word);
        string DecryptWord(string word);
    }

    internal class CipherRoot: IComponent
    {
        private List<IComponent> components = new List<IComponent>();
        private ICipher _cipher;

        public IIterator CreateIterator()
        {
            return new Iterator(this);
        }

        public IComponent GetElement()
        {
            return this;
        }

        public IComponent GetNextElement()
        {
            return components[0];
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

        public string EncryptWord(string word)
        {
            return this._cipher.Encrypt(word);
        }

        public string DecryptWord(string word)
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

        public string DecryptWord(string word)
        {
            return this._cipher.Decrypt(word);
        }

        public string EncryptWord(string word)
        {
            return this._cipher.Encrypt(word);
        }

        public IComponent GetElement()
        {
            return this;
        }

        public IComponent GetNextElement()
        {
            throw new NotImplementedException();
        }

        public void RemoveComponentCipher(IComponent component)
        {
            throw new NotImplementedException();
        }
    }
}
