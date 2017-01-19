using System.Collections.Generic;

namespace QlikSense
{
    public abstract class QlikObject
    {
        internal QlikObject Parent;

        public string Id { get; set; }
        public string Name { get; set; }

        // Title: usado cuando hay que mostrar un título para el objeto.
        public string Title { get; set; }

        public QlikObject(string id, string name)
        {
            Id = id;
            Name = name;
            Title = string.Empty;
        }
    }

    public abstract class QlikObject<TChild> : QlikObject where TChild : QlikObject
    {
        private IDictionary<string, TChild> childs;

        public TChild this[string childName]
        {
            get { return childs[childName]; }
            set { childs[childName] = value; value.Parent = this; }
        }

        public QlikObject(string id, string name) : base(id, name)
        {
            childs = new Dictionary<string, TChild>();
        }

        public void addChilds(params TChild[] childs)
        {
            foreach (var child in childs)
            {
                this[child.Name] = child;
            }
        }
    }
}
