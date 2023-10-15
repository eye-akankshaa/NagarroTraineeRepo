using System;

namespace Webgentle.BookStore.Data
{
    public interface IEvents
    {
        DateTime Date { get; set; }
        string Description { get; set; }
         string OtherDetails { get; set; }
        int Duration { get; set; }
        string eventType { get; set; }
        int Id { get; set; }
        string invitedTo { get; set; }
        string Location { get; set; }
        string startTime { get; set; }
        string Title { get; set; }
        string CreatedBy { get; set; }
    }
}