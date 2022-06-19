using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{

    public GameObject tree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("triggered");
        if (other.gameObject.tag == "tree")
        {
            //Debug.Log("hit tree");
            other.gameObject.GetComponent<Tree>().health -= 10;
        }
    }
}
