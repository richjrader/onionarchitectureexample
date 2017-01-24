namespace Onion.Models
{
    public class WidgetReadModel
    {
        public int? Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Height { get; private set; }

        public WidgetReadModel(Widget widget)
        {
            Id = widget.Id;
            Name = widget.Name;
            Type = widget.Type.Name;
            Height = widget.Height;
        }
    }
}