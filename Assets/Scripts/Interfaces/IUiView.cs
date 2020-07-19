using TestAssigment.Helpers;


namespace TestAssigment.Ui
{
	public interface IUiView
	{
		#region Fields
		PlayerPanelHierarchyBehaviour PlayerPanelHierarchy { set; }

		float Health { set; }

		int Armor { set; }

		int AttackValue { set; }

		int VampireValue { set; }

		IBuffCollector BuffCollector { set; }
		#endregion


		#region Methods
		void Start();

		void EndGame();
        #endregion
    }
}
