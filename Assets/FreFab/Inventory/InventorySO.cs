using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

     [CreateAssetMenu]
    public class InventorySO : ScriptableObject
    {
        [SerializeField]
        private List<InventoryItem> listinventoryitems;

        [field: SerializeField]
        public int Size { get; private set; } = 10;

        public event Action<Dictionary<int, InventoryItem>> OnInventoryChanged;
        public void Initialize()
        {
            listinventoryitems = new List<InventoryItem>();
            for (int i = 0; i < Size; i++)
            {
                listinventoryitems.Add(InventoryItem.getEmptyItem());
            }
        }
        public void addItem(ItemSO _item, int quantity)
        {        
                for (int i = 0; i < listinventoryitems.Count; i++)
                {
                    if (listinventoryitems[i].IsEmpty)
                    {
                        listinventoryitems[i] = new InventoryItem();
                        {
                            _item = _item;
                            quantity = quantity;
                        }                                    
            }             
        }
    }
        
        public Dictionary<int, InventoryItem> GetCurrentInventoryState()
        {
            Dictionary<int, InventoryItem> returnValue =
                new Dictionary<int, InventoryItem>();
            for (int i = 0; i < listinventoryitems.Count; i++)
            {
                if (listinventoryitems[i].IsEmpty)
                    continue;
                returnValue[i] = listinventoryitems[i];
            }
            return returnValue;
        }

        public InventoryItem GetItemAt(int indexItem)
        {
            return listinventoryitems[indexItem];
        }

        public void addItem(InventoryItem item)
        {
            addItem(item.item, item._quantity);
        }

        public void SwapItem(int itemIndex_1, int itemIndex_2)
        {
            InventoryItem item1 = listinventoryitems[itemIndex_1];
            listinventoryitems[itemIndex_1] = listinventoryitems[itemIndex_2];
            listinventoryitems[itemIndex_2] = item1;
            Informaboutchange();
        }

        private void Informaboutchange()
        {
            OnInventoryChanged?.Invoke(GetCurrentInventoryState());
        }
    }

    [Serializable]
    public struct InventoryItem
    {
        public int _quantity;
        public ItemSO item;
        public bool IsEmpty => item == null;

        public InventoryItem changeQuantity(int newQuantity)
        {
            return new InventoryItem
            {
                item = this.item,
                _quantity = newQuantity,
            };
        }
        public static InventoryItem getEmptyItem()
          => new InventoryItem
          {
              item = null,
              _quantity = 0,
          };
    }


    

 

