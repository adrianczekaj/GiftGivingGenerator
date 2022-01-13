﻿using GiftGivingGenerator.API.HashingPassword;
using GiftGivingGenerator.API.Repositories.Abstractions;
using Microsoft.Extensions.Options;

namespace GiftGivingGenerator.API.Servicess;

public class AuthorizationService
{
	private readonly IOrganizerRepository _repository;
	private readonly HashingOptions _options;
	public AuthorizationService(IOrganizerRepository repository, HashingOptions options)
	{
		_repository = repository;
		_options = options;
	}

	public Guid Id { get; set; }
	public DateTime AuthorizationDate { get; set; } = DateTime.UtcNow;
	public string Status { get; set; } = "Ok";

	public Guid AuthorizateAndGetId(string email, string password)
	{
		var organizer = _repository.GetByEmail(email);

		if (organizer==null)
		{
			Status = "Wrong email";
			throw new Exception("Email address is incorrect.");
		}

		var passwordHasher = new PasswordHasher(_options);
		if (!passwordHasher.Check(organizer.Password, password).Verified)
		{
			Status = "Wrong password.";
			throw new Exception("The password is incorrect.");
		}

		return organizer.Id;
	}
	public IOptions<HashingOptions> HashingOptions { get; }
}