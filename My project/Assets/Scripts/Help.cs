using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Help : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;

    private DontDestorySc DDscript;
    private GameObject DDObj;

    // Start is called before the first frame update
    void Start()
    {
        DDObj = GameObject.Find("DontDestory");
        DDscript = DDObj.GetComponent<DontDestorySc>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void topage1()
    {
        Page1.SetActive(true);
        Page2.SetActive(false);
        Page3.SetActive(false);
    }
    public void topage2()
    {
        Page2.SetActive(true);
        Page1.SetActive(false);
        Page3.SetActive(false);
    }
    public void topage3()
    {
        Page3.SetActive(true);
        Page2.SetActive(false);
        Page1.SetActive(false);
    }
    public void BacktoStartScene()
    {
        Destroy(DDObj);
        SceneManager.LoadScene("Start");
    }
}
