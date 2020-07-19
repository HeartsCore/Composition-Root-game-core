using System;
using System.Collections.Generic;
using TestAssigment.Model;


namespace TestAssigment.Helpers
{
	public interface IBuffCollector
	{
		#region Fields
		Dictionary<TypeCharacteristic, PlayerCharacteristics> PlayerCharacteristics { get; }

		Dictionary<TypeBuff, BuffsRepresentation> BuffsCollector { get; }

		List<int> BuffNums { get; }
		#endregion


		#region Methods
		void ApplyBuffsOnPlayer(IPlayerModel playerToBuffing, Action<Dictionary<TypeCharacteristic, float>, IPlayerModel> callback);
        #endregion
    }
}
