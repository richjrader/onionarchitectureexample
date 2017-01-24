using System.Threading.Tasks;

namespace Onion
{
    public interface INotifier
    {
         Task Notify(Widget obj);
    }
}