using System;
using System.Collections.Generic;
using TestAssigment.Helpers;
using UnityEngine;


namespace TestAssigment.Ui
{
	public class UiView : MonoBehaviour, IUiView
	{
		#region Private Data
		private GameObject _statPrefab;
		private StatReference _healthBar;
		private StatReference _armorBar;
		private StatReference _attackBar;
		private StatReference _vampireBar;
		private float _health;
		private int _armor;
		private int _attackValue;
		private int _vampireValue;
		private List<StatReference> _buffIcons;
		#endregion


		#region Fields
		public PlayerPanelHierarchyBehaviour PlayerPanelHierarchy { get; set; }

		public float Health
		{
			get
			{
				return _health;
			}
			set
			{
				_health = value;
				UpdateHealthBar();
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
				UpdateArmorBar();
			}
		}

		public int AttackValue
		{
			get
			{
				return _attackValue;
			}
			set
			{
				_attackValue = value;
				UpdateAttackBar();
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
				UpdateVampireBar();
			}
		}

		public IBuffCollector BuffCollector { get; set; }
        #endregion


        #region Methods
        void IUiView.Start()
		{
			_statPrefab = Resources.Load<GameObject>("Stat");
			_healthBar = UnityEngine.Object.Instantiate<GameObject>(_statPrefab, PlayerPanelHierarchy.statsPanel).GetComponent<StatReference>();
			_armorBar = UnityEngine.Object.Instantiate<GameObject>(_statPrefab, PlayerPanelHierarchy.statsPanel).GetComponent<StatReference>();
			_attackBar = UnityEngine.Object.Instantiate<GameObject>(_statPrefab, PlayerPanelHierarchy.statsPanel).GetComponent<StatReference>();
			_vampireBar = UnityEngine.Object.Instantiate<GameObject>(_statPrefab, PlayerPanelHierarchy.statsPanel).GetComponent<StatReference>();
			UpdateAllBars();
			CreateBuffIcon();
		}

		public void EndGame()
		{
			UnityEngine.Object.Destroy(_healthBar.gameObject);
			UnityEngine.Object.Destroy(_armorBar.gameObject);
			UnityEngine.Object.Destroy(_attackBar.gameObject);
			UnityEngine.Object.Destroy(_vampireBar.gameObject);
			List<StatReference> buffIcons = _buffIcons;
			if (buffIcons != null && buffIcons.Count > 0)
			{
				foreach (StatReference statReference in _buffIcons)
				{
					UnityEngine.Object.Destroy(statReference.gameObject);
				}
				_buffIcons.Clear();
			}
			BuffCollector = null;
		}

		private void CreateBuffIcon()
		{
			if (BuffCollector.BuffNums == null)
			{
				return;
			}
			_buffIcons = new List<StatReference>();
			foreach (int key in BuffCollector.BuffNums)
			{
				BuffsRepresentation buffsRepresentation;
				BuffCollector.BuffsCollector.TryGetValue((TypeBuff)key, out buffsRepresentation);
				StatReference component = UnityEngine.Object.Instantiate<GameObject>(_statPrefab, PlayerPanelHierarchy.statsPanel).GetComponent<StatReference>();
				component.Icon.sprite = buffsRepresentation.Icon;
				component.Text.text = buffsRepresentation.Title;
				_buffIcons.Add(component);
			}
		}

		private void UpdateAllBars()
		{
			SetIconsOnDefaultBars();
			UpdateHealthBar();
			UpdateArmorBar();
			UpdateAttackBar();
			UpdateVampireBar();
		}

		private void SetIconsOnDefaultBars()
		{
			foreach (KeyValuePair<TypeCharacteristic, PlayerCharacteristics> keyValuePair in BuffCollector.PlayerCharacteristics)
			{
				switch (keyValuePair.Key)
				{
					case TypeCharacteristic.Health:
						_healthBar.Icon.sprite = keyValuePair.Value.Icon;
						break;
					case TypeCharacteristic.Armor:
						_armorBar.Icon.sprite = keyValuePair.Value.Icon;
						break;
					case TypeCharacteristic.Attack:
						_attackBar.Icon.sprite = keyValuePair.Value.Icon;
						break;
					case TypeCharacteristic.Vampirism:
						_vampireBar.Icon.sprite = keyValuePair.Value.Icon;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		private void UpdateHealthBar()
		{
			if (_healthBar)
			{
				_healthBar.Text.text = Health.ToString("F2");
			}
		}

		private void UpdateArmorBar()
		{
			if (_armorBar)
			{
				_armorBar.Text.text = Armor.ToString("N0");
			}
		}

		private void UpdateAttackBar()
		{
			if (_attackBar)
			{
				_attackBar.Text.text = AttackValue.ToString("N0");
			}
		}

		private void UpdateVampireBar()
		{
			if (_vampireBar)
			{
				_vampireBar.Text.text = VampireValue.ToString("N0");
			}
		}
        #endregion
    }
}
