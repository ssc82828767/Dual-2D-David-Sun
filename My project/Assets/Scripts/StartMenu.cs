using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SelectRoundPage;
    public DontDestorySc DDscript;
    private int coin;

    private void Start()
    {
        SelectRoundPage.SetActive(false);
        coin = Random.Range(0, 1);
    }
    public void StartGame()
    {
        SelectRoundPage.SetActive(true);
    }
    public void BacktoStart()
    {
        SelectRoundPage.SetActive(false);
    }

    public void Start3Rounds()
    {
        DDscript.RoundsToGo = 3;
        if (coin == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            SceneManager.LoadScene("SampleScene_Reverted");
        }
    }
    public void Start5Rounds()
    {
        DDscript.RoundsToGo = 5;
        if (coin == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            SceneManager.LoadScene("SampleScene_Reverted");
        }

    }

    public void Start7Rounds()
    {
        DDscript.RoundsToGo = 7;
        if (coin == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            SceneManager.LoadScene("SampleScene_Reverted");
        }

    }

    public void StartHelp()
    {
           SceneManager.LoadScene("Help");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
