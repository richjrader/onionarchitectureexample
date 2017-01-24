using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Onion
{
    public class WidgetApplicationService : IWidgetApplicationService
    {
        private readonly IWidgetRepository _wigetRepository;
        private readonly INotifier _notifier;

        public WidgetApplicationService(IWidgetRepository widgetRepository, INotifier notifier)
        {
            if (widgetRepository == null)
            {
                throw new ArgumentNullException("widgetRepository");
            }

            if (notifier == null)
            {
                throw new ArgumentNullException("notifier");
            }
            _wigetRepository = widgetRepository;
            _notifier = notifier;
        }
        public async Task<Widget> Create(string name, WidgetType type)
        {
            Widget widget = Widget.Create(name, type);

            using (new TransactionScope())
            {
                widget = await _wigetRepository.Save(widget);
                await _notifier.Notify(widget);
                return widget;
            }
        }

        public async Task<Widget> PickUp(int id, int inchesToLift)
        {
            Widget widget = await _wigetRepository.GetById(id);

            if (widget == null)
            {
                throw new ArgumentException("Widget not found!");
            }

            widget.PickUp(inchesToLift);

            using (new TransactionScope())
            {
                widget = await _wigetRepository.Save(widget);
                await _notifier.Notify(widget);
                return widget;
            }
        }

        public async Task<Widget> Drop(int id)
        {
            Widget widget = await _wigetRepository.GetById(id);

            if (widget == null)
            {
                throw new ArgumentException("Widget not found!");
            }

            widget.Drop();

            using (new TransactionScope())
            {
                widget = await _wigetRepository.Save(widget);
                await _notifier.Notify(widget);
                return widget;
            }
        }
    }
}