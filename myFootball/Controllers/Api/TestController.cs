using AutoMapper;
using myFootball.Dtos;
using myFootball.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace myFootball.Controllers.Api
{
    public class TestController : ApiController
    {

        private ApplicationDbContext _context;

        public TestController()
        {
            _context = new ApplicationDbContext();
        }



        //POST api/test
        [HttpPost]
        public IHttpActionResult CreateTest(TestDto testDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var test = Mapper.Map<TestDto, Test>(testDto);

            _context.Tests.Add(test);
            _context.SaveChanges();

            testDto.Id = test.Id;
            return Created(new Uri(Request.RequestUri + test.Id.ToString()), testDto);
        }




        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}