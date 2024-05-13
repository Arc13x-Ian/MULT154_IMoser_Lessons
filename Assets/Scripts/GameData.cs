using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{

    public static float gamePlayStart { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("Player started " + gamePlayStart + "ago!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
