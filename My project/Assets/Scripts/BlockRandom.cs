using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRandom : MonoBehaviour
{

    private float xcord;
    private float ycord;
    // Start is called before the first frame update
    void Start()
    {
       xcord = Random.Range(-4, 4);
       ycord = Random.Range(2, 5);

        this.transform.localPosition = new Vector2(xcord, ycord);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
