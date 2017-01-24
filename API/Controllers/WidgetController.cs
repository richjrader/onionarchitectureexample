using System;
using System.Threading.Tasks;
using System.Web.Http;
using Onion.Models;

namespace Onion.Controllers
{
    public class WidgetController : ApiController
    {
        private readonly IWidgetRepository _widgetRepository;
        private readonly IWidgetApplicationService _widgetApplicationService;

        public WidgetController(IWidgetRepository widgetRepository, IWidgetApplicationService widgetApplicationService)
        {
            if (widgetRepository == null)
            {
                throw new ArgumentNullException("widgetRepository");
            }
            if (widgetApplicationService == null)
            {
                throw new ArgumentNullException("widgetApplicationService");
            }

            _widgetRepository = widgetRepository;
            _widgetApplicationService = widgetApplicationService;
        }


       
        [Route("")]
        public async Task<IHttpActionResult> GetWidgetById(int id)
        {
            Widget widget = await _widgetRepository.GetById(id);

            if (widget == null)
                return NotFound();

            return Ok(new WidgetReadModel(widget));
        }

       
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateWidget(WidgetCreateModel model)
        {
            try
            {
                if (model == null)
                    return BadRequest("A Widget model is required to create a Widget");

                var widget = await _widgetApplicationService.Create(model.Name, model.ConvertWidgetType());

                return Ok(widget);
            }
            catch (AggregateException aggEx)
            {
                return BadRequest(aggEx.Message);
            }
            catch (ArgumentException argEx)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}