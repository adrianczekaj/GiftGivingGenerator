﻿namespace GiftGivingGenerator.API.DataTransferObject.Email;

public class Mail
{
	public string Recipient { get; set; }
	public string Subject { get; set; }
	public string Body { get; set; }
}