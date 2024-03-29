using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swarmbrain : MonoBehaviour
{

    private bool hasHive = true;
    private BeeNav patrol;
    private Bot bot;

    // Start is called before the first frame update
    void Start()
    {
        patrol = GetComponent<BeeNav>();
        bot = GetComponent<Bot>();
        HivePickUp.HivePickedUp += HiveTaken;
    }


    void HiveTaken()
    {
        hasHive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasHive)
        {
            patrol.PatrolWaypoints();
        }
        else
        {
            bot.Pursue();
        }
    }
}
