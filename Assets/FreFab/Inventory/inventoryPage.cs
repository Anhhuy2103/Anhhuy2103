using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class inventoryPage : MonoBehaviour
{
    [SerializeField] private UIInventoryItem itemPrefab;
    [SerializeField] private RectTransform contentPanel;
    [SerializeField] private DescriptionInventory itemdescription;
    [SerializeField] private MouseFollower mouseFLW;

    List<UIInventoryItem> listUIItem = new List<UIInventoryItem>();

    public event Action<int> 
        OnDescriptionRequest,
        OnItemActionRequest,
        OnStartDragging;
    public event Action<int, int> OnSwapItem;
     
    [SerializeField] private int currentlyDraggedItemIndex = -1; 
    private void Awake()
    {
        Hide();
        mouseFLW.Toggle(false);
        itemdescription.ResetDescription();
    }
    public void InitializeInventoryUI (int inventorySize)
    {

        for(int i = 0; i < inventorySize; i++)
        {
            UIInventoryItem uiItem =
            Instantiate(itemPrefab,Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listUIItem.Add(uiItem);

            uiItem.OnItemClicked   += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemAction;



        }
    }

    public void updateData( int itemIndex,Sprite itemImage,int itemquantity)
    {
        if(listUIItem.Count > itemIndex)
        {
            listUIItem[itemIndex].SetData(itemImage, itemquantity);
        }
    }
    private void HandleShowItemAction(UIInventoryItem obj)
    {
        
    }

    private void HandleEndDrag(UIInventoryItem inventoryItemUI)
    {
        ResetDragedItem();
    }

    private void HandleSwap(UIInventoryItem inventoryItemUI)
    {
       int index = listUIItem.IndexOf(inventoryItemUI);
        if(index == -1)
        {         
            return;
        }
        OnSwapItem?.Invoke(currentlyDraggedItemIndex, index);
        HandleItemSelection(inventoryItemUI);   
    }

    private void ResetDragedItem()
    {
        mouseFLW.Toggle(false);
        currentlyDraggedItemIndex = -1;
    }

    private void HandleBeginDrag(UIInventoryItem inventoryItemUI)
    {
        int index = listUIItem.IndexOf(inventoryItemUI);
        if(index == -1)
        {
            return;
        }
        currentlyDraggedItemIndex =index;
        HandleItemSelection(inventoryItemUI);
        OnStartDragging?.Invoke(index);
    }

    public void CreateDragginIten (Sprite sprite,int quantity)
    {
        mouseFLW.Toggle(true);
        mouseFLW.SetData(sprite, quantity);
    }


    private void HandleItemSelection(UIInventoryItem inventoryItemUI)
    {
        int index = listUIItem.IndexOf(inventoryItemUI);
        if(index == -1)
        {
            return;
        }
        OnDescriptionRequest?.Invoke(index);
        
    }

    public void Show()
    {
        gameObject.SetActive(true);
        ResetALLITEM();
    }

    public void ResetALLITEM()
    {
        itemdescription.ResetDescription();
        DeselecAllItem();
    }

    private void DeselecAllItem()
    {
       foreach (UIInventoryItem item in listUIItem)
        {
                item.Deselect();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        ResetDragedItem();
    }

    internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
    {
        itemdescription.SetDescription(itemImage,name, description);
        DeselecAllItem();
        listUIItem[itemIndex].Select();
    }

    internal void Reseallitem()
    {
        foreach (var item in listUIItem)
        {
            item.ResetData();
            item.Deselect();
        }
    }
}
