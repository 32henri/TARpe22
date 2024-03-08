using System;
using Microsoft.AspNetCore.Mvc;

namespace YourNamespace
{
    public class PeopleController : Controller
    {
        // This is the method causing the CS1520 error
        public ActionResult GetPerson(int id)
        {
            // Your code here
            return Ok(); // Example return
        }
    }
}
