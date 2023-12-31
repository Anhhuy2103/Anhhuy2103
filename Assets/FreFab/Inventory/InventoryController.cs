using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private inventoryPage inventoryUI;
    [SerializeField] private InventorySO inventoryData;
   
    public List<InventoryItem> initialize = new List<InventoryItem>();

    private void Start()
    {
        PrepageUI();
        //PrepareInventoryData();
    }

    private void PrepareInventoryData()
    {
        inventoryData.Initialize();
        inventoryData.OnInventoryChanged += UpdateInventoryUi; 
        foreach (InventoryItem item in initialize )
        {
            if (item.IsEmpty)
                continue;
            inventoryData.addItem(item);

        }
    }

    private void UpdateInventoryUi(Dictionary<int, InventoryItem> inventoryStage)
    {
        inventoryUI.Reseallitem();
        foreach (var item in inventoryStage)
        {
            inventoryUI.updateData(item.Key, item.Value.item.itemImage,
                item.Value._quantity);  
        }
    }

    private void PrepageUI()
    {
        inventoryUI.InitializeInventoryUI(inventoryData.Size);
        this.inventoryUI.OnDescriptionRequest += HandleDescriptionRequest;
        this.inventoryUI.OnSwapItem += HandleSwap;
        this.inventoryUI.OnStartDragging += HandleDraggin;
        this.inventoryUI.OnItemActionRequest += HandleActionRequest;
    }
    
    private void HandleActionRequest(int itemIndex)
    {
     
    }

    private void HandleDraggin(int itemIndex)
    {
       InventoryItem inventoryItem =inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty)
            return;
        inventoryUI.CreateDragginIten(inventoryItem.item.itemImage,
            inventoryItem._quantity);
    }

    private void HandleSwap(int itemIndex_1, int itemIndex_2)
    {
        inventoryData.SwapItem(itemIndex_1, itemIndex_2);   
    }

    private void HandleDescriptionRequest(int itemIndex)
    {
        InventoryItem inventoryitem = inventoryData.GetItemAt(itemIndex);
        if (inventoryitem.IsEmpty)
        {
            inventoryUI.Reseallitem(); 
            return;
        }           
        ItemSO itemso = inventoryitem.item;
        inventoryUI.UpdateDescription(itemIndex, itemso.itemImage,
            itemso.name, itemso.Description);      
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
                foreach (var item in inventoryData.GetCurrentInventoryState())
                {
                    inventoryUI.updateData(item.Key,
                        item.Value.item.itemImage,
                        item.Value._quantity);
                }
            }
            else
            {
                inventoryUI.Hide();
            }
        }
    }
    
}
