using AutoMapper;
using myFootball.Dtos;
using myFootball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace myFootball.Controllers.Api
{
    public class PlayerController : ApiController
    {
        private ApplicationDbContext _context;


        public PlayerController()
        {
            _context = new ApplicationDbContext();
        }


        //GET api/player
        public IHttpActionResult GetPlayers()
        {
            return Ok(_context.Players.ToList().Select(Mapper.Map<Player, PlayerDto>));
        }


        //GET api/player/1
        public IHttpActionResult GetPlayer(int id)
        {
            var player = _context.Players.SingleOrDefault(c => c.Id == id);

            if (player == null)
                return NotFound();

            return Ok(Mapper.Map<Player, PlayerDto>(player));
        }


        //POST api/player
        [HttpPost]
        public IHttpActionResult CreatePlayer(PlayerDto playerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var player = Mapper.Map<PlayerDto, Player>(playerDto);

            _context.Players.Add(player);
            _context.SaveChanges();

            playerDto.Id = player.Id;
            return Created(new Uri(Request.RequestUri + player.Id.ToString()), playerDto);
        }


        //PUT api/player/1
        [HttpPut]
        public IHttpActionResult UpdatePlayer(int id, PlayerDto playerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var playerInDb = _context.Players.SingleOrDefault(c => c.Id == id);

            if (playerInDb == null)
                return NotFound();

            Mapper.Map(playerDto, playerInDb);

            _context.SaveChanges();

            return Ok();
        }


        //DELETE api/player/1
        [HttpDelete]
        public IHttpActionResult DeletePlayer(int id)
        {
            var playerInDb = _context.Players.SingleOrDefault(c => c.Id == id);

            if (!ModelState.IsValid)
                return NotFound();

            try
            {
                _context.Players.Remove(playerInDb);
                _context.SaveChanges();

            } catch
            {
                return BadRequest();
            }

            return Ok();

        }
    }
}
