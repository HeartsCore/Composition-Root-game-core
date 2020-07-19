using System;


namespace TestAssigment.Events
{
	public class PlayerAttackValueChangedEventArgs : EventArgs
	{
		public PlayerAttackValueChangedEventArgs(int attack)
		{
			Attack = attack;
		}

		public int Attack;
	}
}
