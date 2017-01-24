using System;
using System.Threading.Tasks;

namespace Onion
{
    public class WidgetRepository : IWidgetRepository
    {
        public Task<Widget> Save(Widget widget)
        {
            throw new NotImplementedException();
        }

        public Task<Widget> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
