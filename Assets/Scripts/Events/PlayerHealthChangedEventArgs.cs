namespace TestAssigment.Events
{
	public class PlayerHealthChangedEventArgs
	{
		#region Fields
		public float Health;
		#endregion


		#region Class Life Cycle
		public PlayerHealthChangedEventArgs(float health)
		{
			Health  = health;
		}
        #endregion
    }
}
