using UnityEngine;
using UnityEngine.UI;


namespace TestAssigment.Helpers
{
	public class StatReference : MonoBehaviour
	{
		#region Fields
		public Text Text { get; private set; }

		public Image Icon { get; private set; }
		#endregion


		#region Unity Methods
		private void OnEnable()
		{
			this.Text = base.GetComponentInChildren<Text>();
			this.Icon = base.GetComponentsInChildren<Image>()[1];
		}
        #endregion
    }
}
