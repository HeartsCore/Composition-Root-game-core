using System;
using TestAssigment.Events;
using TestAssigment.Helpers;


namespace TestAssigment.Model
{
	public interface IPlayerModel
	{
		#region Fields
		PlayerPanelHierarchyBehaviour PlayerPanelHierarchy { get; set; }

		int PlayerId { get; set; }

		float Health { get; set; }

		int Armor { get; set; }

		int AttackValue { get; set; }

		int VampireValue { get; set; }

		bool IsDead { get; set; }

		IBuffCollector BuffCollector { get; set; }

		event EventHandler<PlayerHealthChangedEventArgs> OnHealthChanged;

		event EventHandler<PlayerArmorChangedEventArgs> OnArmorChanged;

		event EventHandler<PlayerAttackValueChangedEventArgs> OnAttackValueChanged;

		event EventHandler<PlayerVampireValueChangedEventArgs> OnVampireValueChanged;
        #endregion
    }
}
