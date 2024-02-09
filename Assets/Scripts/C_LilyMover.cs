using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_LilyMover : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if(transform.position.x < -80 || transform.position.x > 80)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject child = collision.gameObject;
            child.transform.SetParent(gameObject.transform);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject child = collision.gameObject;
            child.transform.SetParent(null);

        }


    }
}
