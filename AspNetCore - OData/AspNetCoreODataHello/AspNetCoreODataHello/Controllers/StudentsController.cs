using AspNetCoreODataHello.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AspNetCoreODataHello.Controllers
{
    public class StudentsController : ODataController
    {
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<Student> Get()
        {
            return new List<Student>
            {
                new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "Vishwa Goli",
                    Score = 100
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "Josh McCall",
                    Score = 120
                }
            };
        }        
    }
}

