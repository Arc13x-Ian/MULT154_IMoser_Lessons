using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PlayerMover : MonoBehaviour
{
    private Rigidbody rbPlayer;
    private Vector3 direction = Vector3.zero;
    public float speed = 10.0f;
    public GameObject spawnPoint = null;
    private Dictionary<C_Carrot.VegetableType, int> ItemInventory = new Dictionary<C_Carrot.VegetableType, int>();

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();

        foreach(C_Carrot.VegetableType item in System.Enum.GetValues(typeof(C_Carrot.VegetableType)))
        {
            ItemInventory.Add(item, 0);

        }
    }
    
    private void AddToInventory(C_Carrot item)
    {
        ItemInventory[item.typeOfVeggie]++;

    }

    private void PrintInventory()
    {
        string output = "";

        foreach(KeyValuePair<C_Carrot.VegetableType, int> kvp in ItemInventory)
        {
            output += string.Format("{0}: {1}", kvp.Key, kvp.Value);
        }
        Debug.Log(output);
    }
    private void Update()
    {
        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        direction = new Vector3(horMove, 0, verMove);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbPlayer.AddForce(direction * speed, ForceMode.Force);

        if(transform.position.z > 40)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 40);
        }

        else if(transform.position.z < -40)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -40);
        }
    }

    private void Respawn()
    {
        rbPlayer.MovePosition(spawnPoint.transform.position);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            C_Carrot item = other.gameObject.GetComponent<C_Carrot>();
            AddToInventory(item);
            PrintInventory();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Hazard"))
        {
            Respawn();
        }

    }


}
