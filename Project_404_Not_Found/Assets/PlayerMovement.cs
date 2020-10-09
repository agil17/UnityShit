using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime);

        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0, 0, verticalInput) * speed * Time.deltaTime);
    }
}
