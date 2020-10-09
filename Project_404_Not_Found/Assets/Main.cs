using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space Key");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Holding Down E");
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("F Key Released");
        }
    }
}
