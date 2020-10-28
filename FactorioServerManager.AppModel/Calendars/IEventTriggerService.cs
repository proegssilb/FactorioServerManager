using System;

namespace FactorioServerManager.AppModel.Calendars
{
    public interface IEventTriggerService
    {
        void TriggerEvents(TimeSpan windowToTrigger);
    }
}
