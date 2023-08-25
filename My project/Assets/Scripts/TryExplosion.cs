using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigi;
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
