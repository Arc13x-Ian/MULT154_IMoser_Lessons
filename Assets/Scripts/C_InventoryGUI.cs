using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_InventoryGUI : MonoBehaviour
{

    public List<GameObject> items;

    // Start is called before the first frame update
    void Start()
    {
        C_Itemcollector.ItemCollected += IncrementItem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncrementItem(C_Carrot.VegetableType itemType)
    {
        C_CountGUI cg = items[(int)itemType].GetComponent<C_CountGUI>();
        cg.UpdateCount();

    }
}
