using System;
using TestAssigment.Events;

namespace TestAssigment.Ui
{
	public interface IPlayerView
	{
		PlayerPanelHierarchyBehaviour PlayerPanelHierarchy { set; }

		int PlayerID { get; set; }

		float Health { set; }

		bool IsDead { set; }

		event EventHandler<PlayerButtonClickEventArgs> OnPlayerButtonClicked;

		void Start();

		void EndGame();
	}
}
