using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameDevelopment_101.Design_Patterns.ModelViewPresenter
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI goldText;
        [SerializeField] private Button addGoldButton;

        public event Action OnAddGoldClicked;

        private void Awake()
        {
            addGoldButton.onClick.AddListener(() => OnAddGoldClicked?.Invoke());
        }
        
        public void UpdateGoldDisplay(int amount)
        {
            goldText.text = $"Gold: {amount}";
        }
    }
}