using System.Threading.Tasks;

namespace Onion
{
    public interface IWidgetApplicationService
    {
        Task<Widget> Create(string name, WidgetType type);
        Task<Widget> PickUp(int id, int inchesToLift);
        Task<Widget> Drop(int id);
    }
}