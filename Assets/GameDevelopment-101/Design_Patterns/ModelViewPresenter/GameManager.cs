using System;
using UnityEngine;

namespace GameDevelopment_101.Design_Patterns.ModelViewPresenter
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InventoryView inventoryView;
        private InventoryPresenter _inventoryPresenter;

        private void Start()
        {
            var inventoryModel = new InventoryModel(100);

            _inventoryPresenter = new InventoryPresenter(inventoryModel, inventoryView);
        }
    }
}