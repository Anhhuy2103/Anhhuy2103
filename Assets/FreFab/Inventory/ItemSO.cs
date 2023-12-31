using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "item")]
public class ItemSO : ScriptableObject
{     
   

    [field: SerializeField]
    public bool IsStackable { get; set; }

    public int ID => GetInstanceID();

    [field: SerializeField]
    public int maxStackSize { get; set; } = 1;

    [field: SerializeField]
    public string name { get; set; }

    [field: SerializeField]
    [field: TextArea]
    public string Description { get; set; }

    [field: SerializeField]
    public Sprite itemImage { get; set; }

   
}
