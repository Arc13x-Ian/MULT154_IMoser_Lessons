using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class C_Itemcollector : NetworkBehaviour
{
    private Dictionary<C_Carrot.VegetableType, int> ItemInventory = new Dictionary<C_Carrot.VegetableType, int>();

    public delegate void CollectItem(C_Carrot.VegetableType item);
    public static event CollectItem ItemCollected;

    Collider itemCollider = null;


    // Start is called before the first frame update
    void Start()
    {
        foreach (C_Carrot.VegetableType item in System.Enum.GetValues(typeof(C_Carrot.VegetableType)))
        {
            ItemInventory.Add(item, 0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        if (itemCollider && Input.GetKeyDown(KeyCode.Space))
        {
            C_Carrot item = itemCollider.gameObject.GetComponent<C_Carrot>();
            AddToInventory(item);
            PrintInventory();

            CmdItemCollected(item.typeOfVeggie);
        }

    }

    [Command]
    void CmdItemCollected(C_Carrot.VegetableType itemType)
    {
        RpcItemCollected(itemType);

    }

    [ClientRpc]
    void RpcItemCollected(C_Carrot.VegetableType itemType)
    {
        ItemCollected?.Invoke(itemType);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (other.CompareTag("Item"))
        {
            itemCollider = other;


        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (!isLocalPlayer)
        {
            return;
        }

        if (other.CompareTag("Item"))
        {
            itemCollider = null;

        }
    }
        private void AddToInventory(C_Carrot item)
        {
            ItemInventory[item.typeOfVeggie]++;

        }

        private void PrintInventory()
        {
            string output = "";

            foreach (KeyValuePair<C_Carrot.VegetableType, int> kvp in ItemInventory)
            {
                output += string.Format("{0}: {1}", kvp.Key, kvp.Value);
            }
            Debug.Log(output);
        }
    
}

    
