using TestAssigment.Model;
using TestAssigment.Ui;


namespace TestAssigment.Helpers
{
	public class PlayerEntity
	{
		#region Private Data
		public readonly IPlayerModel PlayerModel;

		public readonly IPlayerView PlayerView;
		#endregion


		#region Class Life Cycle
		public PlayerEntity(IPlayerModel playerModel, IPlayerView playerView)
		{
			PlayerModel = playerModel;
			PlayerView = playerView;
		}
        #endregion

    }
}
