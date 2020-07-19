using System;
using TestAssigment.Events;
using TestAssigment.Helpers;
using UnityEngine;


namespace TestAssigment.Model
{
	public class PlayerModel : IPlayerModel
	{
		#region Private Data
		private float _health;
		private int _armor;
		private int _attack;
		private int _vampireValue;
		#endregion


		#region Fields
		public event EventHandler<PlayerHealthChangedEventArgs> OnHealthChanged = delegate (object sender, PlayerHealthChangedEventArgs args)
		{
		};

		public event EventHandler<PlayerArmorChangedEventArgs> OnArmorChanged = delegate (object sender, PlayerArmorChangedEventArgs args)
		{
		};

		public event EventHandler<PlayerAttackValueChangedEventArgs> OnAttackValueChanged = delegate (object sender, PlayerAttackValueChangedEventArgs args)
		{
		};

		public event EventHandler<PlayerVampireValueChangedEventArgs> OnVampireValueChanged = delegate (object sender, PlayerVampireValueChangedEventArgs args)
		{
		};
				
		public int PlayerId { get; set; }

		public PlayerPanelHierarchyBehaviour PlayerPanelHierarchy { get; set; }

		public float Health
		{
			get
			{
				return _health;
			}
			set
			{
				_health = ((value < 0f) ? 0f : value);
				OnHealthChanged(this, new PlayerHealthChangedEventArgs(_health));
			}
		}

		public int Armor
		{
			get
			{
				return _armor;
			}
			set
			{
				_armor = value;
				_armor = Mathf.Clamp(_armor, 0, 100);
				OnArmorChanged(this, new PlayerArmorChangedEventArgs(_armor));
			}
		}

		public int AttackValue
		{
			get
			{
				return _attack;
			}
			set
			{
				_attack = ((value < 0) ? 0 : value);
				OnAttackValueChanged(this, new PlayerAttackValueChangedEventArgs(_attack));
			}
		}

		public int VampireValue
		{
			get
			{
				return _vampireValue;
			}
			set
			{
				_vampireValue = value;
				_vampireValue = Mathf.Clamp(_vampireValue, 0, 100);
				OnVampireValueChanged(this, new PlayerVampireValueChangedEventArgs(_vampireValue));
			}
		}

		public bool IsDead { get; set; }

		public IBuffCollector BuffCollector { get; set; }
        #endregion
    }
}
