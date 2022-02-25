﻿namespace GiftGivingGenerator.API.DataTransferObject.DrawingResult;

public class DrawingResultForUserDto
{
	public Guid EventId { get; set; }
    public string EventName { get; set; }    
    public DateTime EndDate { get; set; }
    public int? Budget { get; set; }
    public string? Message { get; set; }
    public Guid GiverId { get; set; }
    public string GiverName { get; set; }
    public string RecipientName { get; set; }
  	public string RecipientGiftWishes { get; set; }
}