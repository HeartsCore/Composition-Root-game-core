using TestAssigment.Controllers;

namespace TestAssigment.Factory
{
	public interface IGameControllerFactory
	{
		IGameController GameController { get; }
	}
}
