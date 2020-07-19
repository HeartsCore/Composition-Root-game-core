using System.Collections.Generic;
using TestAssigment.Helpers;


namespace TestAssigment.Controllers
{
	public interface IPlayerController
	{
		Dictionary<int, PlayerEntity> Players { get; }
	}
}
