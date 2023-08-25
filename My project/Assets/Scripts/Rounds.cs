using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rounds : MonoBehaviour
{
    public float phase0 = 4.0f;
    public float phase1 = 5.0f;
    public float phase2 = 50.0f;
    private TouchTest touch_scripts;
    private bool phase0passed = false;
    private bool phase1passed = false;
    private bool phase2passed = false;
    public GameObject endgameblocker;
    public GameObject phase1blocker;

    public Text CountdownText;
    public Text CountdownText2;

    public Text playerApoint;
    public Text playerBpoint;

    public GameObject canvas5;
    public GameObject canvas6;
    public GameObject canvas2;
    public GameObject canvas7;

    private DontDestorySc DDscript;

    // Start is called before the first frame update
    void Start()
    {
        touch_scripts = GameObject.Find("TouchControl").GetComponent<TouchTest>();
        touch_scripts.Indicator1.SetActive(false);
        touch_scripts.Indicator.SetActive(false);
        DDscript = GameObject.Find("DontDestory").GetComponent<DontDestorySc>();

        canvas2.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        playerApoint.text = ((int)DDscript.PlayerAPoints).ToString();
        playerBpoint.text = ((int)DDscript.PlayerBPoints).ToString();

        phase0 -= Time.deltaTime;

        //canvas2.GetComponent<AudioSource>().Play();
        if (phase0 <= 0 && phase0passed == false)
        {
            phase0passed = true;
            touch_scripts.Indicator.SetActive(true);
            endgameblocker.SetActive(false);
        }

        if (phase0passed && !phase1passed)
        {
            phase1 -= Time.deltaTime;
            phase1blocker.SetActive(true);
            canvas6.SetActive(true);
            this.GetComponent<AudioSource>().Play();
        }

        //CountdownText.text = ((int)phase1 + 1).ToString();
        CountdownText2.text = ((int)phase1 + 1).ToString();

        if (phase1 <= 0 && phase1passed == false)
        {
            touch_scripts.Indicator1.SetActive(true);
            phase1passed = true;
            canvas6.SetActive(false);
            phase1blocker.SetActive(false);
        }

        if (phase1passed && !phase2passed)
        {
            phase2 -= Time.deltaTime;
            canvas5.SetActive(true);
        }
        CountdownText.text = ((int)phase2 + 1).ToString();
        if (phase2 <= 0 && phase2passed == false)
        {
            if (touch_scripts.WorldOrientationUp)
            {
                DDscript.PlayerBPoints += 1;
            }
            else
            {
                DDscript.PlayerAPoints += 1;
            }
            roundend();

        }
    }
    public void roundend()
    {
        touch_scripts.Indicator1.SetActive(false);
        touch_scripts.Indicator.SetActive(false);
        phase2passed = true;
        endgameblocker.SetActive(true);
        canvas5.SetActive(false);
        canvas2.SetActive(false);
        canvas7.SetActive(true);
        canvas7.GetComponent<AudioSource>().Play();
        Invoke("NewRound", 2f);
    }

    // public void FinishRound()
    //{
    //Time.timeScale = 0;
    //showing score
    //show UI Image/Button
    //Invoke("NewRound", 2f);
    // }


    public void NewRound()
    {
        //DontDestorySc DD_script = GameObject.Find("DontDestory").GetComponent<DontDestorySc>();
        DDscript.RoundsToGo--;

        if (DDscript.RoundsToGo > 0)
        {
            if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                SceneManager.LoadScene("SampleScene_Reverted");
            }
            else
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        else if (DDscript.RoundsToGo == 0)
        {
            SceneManager.LoadScene("Finish");
        }
    }
}