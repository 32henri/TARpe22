using System;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace
{
    public class EventPeopleController : Controller
    {
        // This is the method causing the CS1520 error
        public ActionResult GetEventPerson(int eventId, int personId)
        {
            // Your code here
            return Ok(); // Example return
        }
    }
}
