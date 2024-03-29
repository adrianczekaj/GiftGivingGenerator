﻿using AutoMapper;
using GiftGivingGenerator.API.Entities;
using GiftGivingGenerator.API.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GiftGivingGenerator.API.Repositories;

public class OrganizerRepository : RepositoryBase<Organizer>, IOrganizerRepository
{
	public OrganizerRepository(AppContext dbContext, IMapper mapper) : base(dbContext, mapper)
	{
	}

	public Organizer GetByEmail(string email)
	{
		var organizer = DbContext.Organizer
			.SingleOrDefault(x => x.Email == email);
		
		return organizer;
	}

	public override IQueryable<Organizer> WriteEntitySet()
	{
		return base.WriteEntitySet()
			.Include(x=>x.Persons);
	}
}