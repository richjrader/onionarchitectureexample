namespace Onion.Models
{
    public class WidgetCreateModel
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public WidgetType ConvertWidgetType()
        {
            return new WidgetType(Type);
        }
    }
}