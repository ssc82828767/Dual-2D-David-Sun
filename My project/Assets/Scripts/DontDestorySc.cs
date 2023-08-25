using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestorySc : MonoBehaviour
{
    // Start is called before the first frame update
    public int RoundsToGo;
    public int PlayerAPoints, PlayerBPoints;
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
