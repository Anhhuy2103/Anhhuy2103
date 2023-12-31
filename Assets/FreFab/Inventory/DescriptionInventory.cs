using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DescriptionInventory : MonoBehaviour
{
    [SerializeField] private TMP_Text description;
    [SerializeField] private  TMP_Text itemName;
    [SerializeField] private  Image itemImage;
    
    public void Awake()
    {
        ResetDescription();
    }
    public void ResetDescription()
    {
        this.itemImage.gameObject.SetActive(false);
        this.itemName.text = "";
        this.description.text = "";

    }
    public void SetDescription(Sprite sprite, string itemname  , string itemdescription)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.itemName.text = itemname;
        this.description.text = itemdescription;

    }
}
