using FactorioServerManager.AppModel.Games;
using FactorioServerManager.AppModel.Users;
using System;
using System.Collections.Generic;

namespace FactorioServerManager.AppModel.Calendars
{
    public interface ICalendarService
    {
        void AssociateCalendar(User userToModify, Uri calendarUri);
        void AddCalendar(Calendar calendar, User addedTo);
        IReadOnlyList<Calendar> GetUserCalendars();
        IReadOnlyList<Calendar> GetGameCalendars(FactorioGame game);
        Calendar GetCalendarByUri(Uri calendarUri);
        IReadOnlyList<CalendarEvent> GetCalendarEvents(Calendar calendar);
        IReadOnlyList<CalendarEvent> GetGameEvents(FactorioGame game);
        void UpdateCalendars();
        void UpdateCalendar(Calendar currentCalendar);
    }
}
