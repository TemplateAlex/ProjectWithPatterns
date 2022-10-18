namespace ForAizhulov.Patterns
{
    internal interface IIterator
    {
        bool isDone();
        IComponent CurrentItem();
        IComponent NextItem();

    }

    internal class Iterator: IIterator
    {
        private IComponent _components;

        public Iterator(IComponent component)
        {
            this._components = component;
        }
        public bool isDone()
        {
            return this._components.IsDone();
        }   

        public IComponent CurrentItem()
        {
            return this._components.GetElement();
        }

        public IComponent NextItem()
        {
            return this._components.GetNextElement();
        }
    }
}
