using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOri : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.PortraitUpsideDown;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
