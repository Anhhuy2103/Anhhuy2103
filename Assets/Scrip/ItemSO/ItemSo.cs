using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="itemSO")]
public class ItemSo : ScriptableObject
{

    [SerializeField] private int Id;
    public int id
    {
        get => id;
        private set => id = value;
    }

    [SerializeField] private string playerName;
    public string Name
    {
        get => playerName;
        private set => playerName = value;
    }

    [SerializeField] private int ValuePoint;
    public int valuepoint
    {
        get => ValuePoint;
        private set => ValuePoint = value;
    }

    [SerializeField] private Sprite itemSprite;
        public Sprite itemsprite
    {
        get => itemsprite;
        set => itemsprite = value;
    }


    public ItemSo(string name, int ValuePoint,Sprite Itemsprite)
    {
        this.Name = name;
        this.ValuePoint = ValuePoint;
        this.itemsprite = Itemsprite;
    }
}
