using System;


namespace TestAssigment.Events
{
	public class PlayerArmorChangedEventArgs : EventArgs
	{
		public PlayerArmorChangedEventArgs(int armor)
		{
			Armor = armor;
		}

		public int Armor;
	}
}
