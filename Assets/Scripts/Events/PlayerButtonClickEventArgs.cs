namespace TestAssigment.Events
{
	public class PlayerButtonClickEventArgs
	{
		public PlayerButtonClickEventArgs(int attackingId, int defencingId)
		{
			AttackingId = attackingId;
			DefencingId = defencingId;
		}

		public readonly int AttackingId;

		public readonly int DefencingId;
	}
}
