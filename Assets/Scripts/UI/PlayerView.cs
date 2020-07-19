using System;
using System.Collections;
using TestAssigment.Events;
using UnityEngine;
using UnityEngine.Events;

namespace TestAssigment.Ui
{
	public class PlayerView : MonoBehaviour, IPlayerView
	{
		#region Private Data
		private static readonly int AnimatorAttackHash = Animator.StringToHash("Attack");
		private static readonly int AnimatorHealthHash = Animator.StringToHash("Health");
		private float _health;
		#endregion


		#region Fields
		public PlayerPanelHierarchyBehaviour PlayerPanelHierarchy { get; set; }

		public int PlayerID { get; set; }

		public float Health
		{
			get
			{
				return _health;
			}
			set
			{
				_health = ((value < 0f) ? 0f : value);
				HandleHealthChanged();
			}
		}

		public bool IsDead { get; set; }

		public event EventHandler<PlayerButtonClickEventArgs> OnPlayerButtonClicked = delegate (object sender, PlayerButtonClickEventArgs args)
		{ };
		#endregion


		#region Methods
		void IPlayerView.Start()
		{
			PlayerPanelHierarchy.attackButton.onClick.AddListener(OnAttackButtonClicked);
		}

		void IPlayerView.EndGame()
		{
			PlayerPanelHierarchy.attackButton.onClick.RemoveAllListeners();
			IsDead = false;
			PlayerPanelHierarchy.character.SetInteger(PlayerView.AnimatorHealthHash, 100);
		}

		private void HandleHealthChanged()
		{
			int value = Mathf.RoundToInt(_health);
			PlayerPanelHierarchy.character.SetInteger(PlayerView.AnimatorHealthHash, value);
		}

		private void OnAttackButtonClicked()
		{
			if (IsDead)
			{
				return;
			}
			RaycastHit raycastHit;
			if (Physics.Raycast(base.transform.position, base.transform.TransformDirection(Vector3.forward), out raycastHit, 3f))
			{
				IPlayerView component = raycastHit.collider.GetComponent<IPlayerView>();
				if (component == null)
				{
					return;
				}
				OnPlayerButtonClicked(this, new PlayerButtonClickEventArgs(PlayerID, component.PlayerID));
				base.StartCoroutine(AnimatorDelayTriggerReset());
			}
		}

		private IEnumerator AnimatorDelayTriggerReset()
		{
			Animator playerAnimator = PlayerPanelHierarchy.character;
			playerAnimator.SetTrigger(PlayerView.AnimatorAttackHash);
			float seconds = 0.25f;
			yield return new WaitForSeconds(seconds);
			playerAnimator.ResetTrigger(PlayerView.AnimatorAttackHash);
			yield break;
		}
        #endregion
    }
}
