﻿using GiftGivingGenerator.API.DataTransferObject.DrawingResult;
using GiftGivingGenerator.API.Entities;

namespace GiftGivingGenerator.API.Repositories.Abstractions;

public interface IDrawingResultRepository : IRepository<DrawingResult>
{
	List<DrawingResultDto> GetDrawingResultsByEventId(Guid id);
}