using System.Threading.Tasks;

namespace Onion
{
    public interface IWidgetRepository
    {
        Task<Widget> Save(Widget widget);
        Task<Widget> GetById(int id);
    }
}