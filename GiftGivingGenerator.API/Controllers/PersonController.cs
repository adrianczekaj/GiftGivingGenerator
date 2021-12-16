﻿using GiftGivingGenerator.API.DataTransferObject;
using GiftGivingGenerator.API.DataTransferObject.Event;
using GiftGivingGenerator.API.DataTransferObject.Get;
using GiftGivingGenerator.API.DataTransferObject.Person;
using GiftGivingGenerator.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GiftGivingGenerator.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
	[HttpPost]
	public ActionResult CreatePerson([FromBody] CreateEventDto get)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		
		var person = new Person()
		{
			Name = get.Name
		};

		var dbContext = new AppContext();
		dbContext.Add(person);
		dbContext.SaveChanges();

		return Created($"{person.Id}", null);
	}
	
	//TODO: probablly we can't create 2 persons with the same name
	[HttpGet]
	public ActionResult GetPerson([FromBody] GetId get)
	{
		var dbContext = new AppContext();
		var person = dbContext
			.Persons
			.Single(x => x.Id == get.Id);

		var personDto = new PersonDto()
		{
			Id = person.Id,
			Name = person.Name,
		};

		return Ok(personDto);
	}

	[HttpPut]
	public ActionResult EditPerson([FromBody] PersonDto person)
	{
		var dbContext = new AppContext();
		var selectedPerson = dbContext
			.Persons
			.Single(x => x.Id == person.Id);

		selectedPerson.Name = person.Name;
		dbContext.Update(selectedPerson);
		dbContext.SaveChanges();

		return Ok();
	}
	
	//TODO: what should happen with active/no active allocations, when person is removed?
	[HttpDelete]
	public ActionResult DeletePerson([FromBody] GetId get)
	{
		var dbContext = new AppContext();
		var person = dbContext
			.Persons
			.Single(x => x.Id == get.Id);

		dbContext.Remove(person);
		dbContext.SaveChanges();

		return NoContent();
	}
}