﻿using System.Security.Cryptography;
using Microsoft.Extensions.Options;

namespace GiftGivingGenerator.API.HashingPassword;

public sealed class PasswordHasher
{
	private readonly HashingOptions _options;

	public PasswordHasher(IOptions<HashingOptions> options)
	{
		_options = options.Value;
	}
	
	private const int SaltSize = 16;
	private const int KeySize = 32;

	public string Hash(string password)
	{
		using (var algorithm = new Rfc2898DeriveBytes(
			       password,
			       SaltSize,
			       _options.Iterations,
			       HashAlgorithmName.SHA256))
		{
			var key = Convert.ToBase64String((algorithm.GetBytes((KeySize))));
			var salt = Convert.ToBase64String(algorithm.Salt);
			
			return $"{_options.Iterations}.{salt}.{key}";
		}
	}

	public (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
	{
		var parts = hash.Split('.', 3);

		if (parts.Length != 3)
		{
			throw new FormatException("Unexpected hash format. " +
			                          "Should be formatted as `{iterations}.{salt}.{hash}`");
		}

		var iterations = Convert.ToInt32(parts[0]);
		var salt = Convert.FromBase64String(parts[1]);
		var key = Convert.FromBase64String(parts[2]);
		
		var needsUpgrade = iterations != _options.Iterations;
		
		using (var algorithm = new Rfc2898DeriveBytes(
			       password,
			       salt,
			       iterations,
			       HashAlgorithmName.SHA256))
		{
			var keyToCheck = algorithm.GetBytes(KeySize);

			var verified = keyToCheck.SequenceEqual(key);

			return (verified, needsUpgrade);
		}
	}
}