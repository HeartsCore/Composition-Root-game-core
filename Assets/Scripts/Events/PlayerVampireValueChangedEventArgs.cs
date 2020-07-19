using System;


namespace TestAssigment.Events
{
	public class PlayerVampireValueChangedEventArgs : EventArgs
	{
		#region Fields
		public int VampireValue;
		#endregion


		#region Class Life Cycle
		public PlayerVampireValueChangedEventArgs(int vampireValue)
		{
			VampireValue = vampireValue;
		}
        #endregion
    }
}
