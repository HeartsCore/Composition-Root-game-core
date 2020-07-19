using UnityEngine;


namespace TestAssigment.Helpers
{
	public class PlayerCharacteristics
	{
		#region Fields
		public string Title;
		public float Value;
		public Sprite Icon;
		#endregion


		#region Class Life Cycle
		public PlayerCharacteristics(string title, float value, Sprite icon)
		{
			Title = title;
			Value = value;
			Icon = icon;
		}
        #endregion

    }
}
