using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinshScene : MonoBehaviour
{
    private DontDestorySc DDscript;
    private GameObject DDObj;

    public GameObject Page1;
    public GameObject Page2;
    public Text playerApoint;
    public Text playerBpoint;
    public Text playerA;
    public Text playerB;

    // Start is called before the first frame update
    void Start()
    {
        DDObj = GameObject.Find("DontDestory");
        DDscript = DDObj.GetComponent<DontDestorySc>();
    }

    // Update is called once per frame
    void Update()
    {
        playerApoint.text = ((int)DDscript.PlayerAPoints).ToString();
        playerBpoint.text = ((int)DDscript.PlayerBPoints).ToString();
        if (DDscript.PlayerAPoints > DDscript.PlayerBPoints)
        {
            playerA.text = ("Win").ToString();
            playerB.text = ("Lose").ToString();
        }
        else
        {
            playerB.text = ("Win").ToString();
            playerA.text = ("Lose").ToString();
        }


    }

    public void BacktoStartScene()
    {
        Destroy(DDObj);
        SceneManager.LoadScene("Start");
    }
}
