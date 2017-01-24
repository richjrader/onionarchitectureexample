using System;

namespace Onion
{
    public class Widget
    {
        public int? Id { get; private set; }
        public string Name { get; private set; }
        public WidgetType Type { get; private set; }
        public int Height { get; private set; }

        private Widget(int? id, string name, WidgetType type, int height)
        {
            Id = id;
            Name = name;
            Type = type;
            Height = height;
        }

        public static Widget Create(string name, WidgetType type)
        {
            if (type.Name == "Wizbang")
            {
                throw new AggregateException("Can't have a Widget that is a Wizbang for some reason!");
            }
            
            return new Widget(null, name, type, 0);
        }

        public static Widget Reconstitute(int id, string name, WidgetType type, int height)
        {
            return new Widget(id, name, type, height);
        }

        public void PickUp(int inchesToLift)
        {
            if (inchesToLift < 0)
            {
                throw new AggregateException("Lifting moves things up, not down!");
            }
            Height += inchesToLift;
        }

        public void Drop()
        {
            Height = 0;
        }
    }
}
