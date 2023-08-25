using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlock : MonoBehaviour
{
    public GameObject slot0;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject newblock;
    public GameObject newblock1;
    public GameObject newblock2;
    public float lastBackupTime, BackUpCoolDown;

    private TouchTest touch_scripts;
    public GameObject BlockLineTest;
    // Start is called before the first frame update
    void Start()
    {
        touch_scripts = GameObject.Find("TouchControl").GetComponent<TouchTest>();

        //initial slot1 block generation
        float i1 = Random.Range(0, 10);
        if (i1 <= 5)
        {
            GameObject new1 = GameObject.Instantiate(newblock);
            new1.transform.parent = slot1.transform;
            new1.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (i1 <= 8 && i1 > 5)
        {
            GameObject new1 = GameObject.Instantiate(newblock1);
            new1.transform.parent = slot1.transform;
            new1.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            GameObject new1 = GameObject.Instantiate(newblock2);
            new1.transform.parent = slot1.transform;
            new1.transform.localPosition = new Vector3(0, 0, 0);
        }

        //initial slot2 block generation
        float i2 = Random.Range(0, 10);
        if (i2 <= 5)
        {
            GameObject new1 = GameObject.Instantiate(newblock);
            new1.transform.parent = slot2.transform;
            new1.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (i2 <= 8 && i2 > 5)
        {
            GameObject new1 = GameObject.Instantiate(newblock1);
            new1.transform.parent = slot2.transform;
            new1.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            GameObject new1 = GameObject.Instantiate(newblock2);
            new1.transform.parent = slot2.transform;
            new1.transform.localPosition = new Vector3(0, 0, 0);
        }

        //initial slot3 block generation
        float i3 = Random.Range(0, 10);
        if (i3 <= 5)
        {
            GameObject new1 = GameObject.Instantiate(newblock);
            new1.transform.parent = slot3.transform;
            new1.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (i3 <= 8 && i3 > 5)
        {
            GameObject new1 = GameObject.Instantiate(newblock1);
            new1.transform.parent = slot3.transform;
            new1.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            GameObject new1 = GameObject.Instantiate(newblock2);
            new1.transform.parent = slot3.transform;
            new1.transform.localPosition = new Vector3(0, 0, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //case of backup slot empty
        if (slot0.GetComponentsInChildren<Transform>(true).Length <= 1)
        {
                float index = Random.Range(0, 10);
                if (index <= 5)
                {
                    GameObject new1 = GameObject.Instantiate(newblock);
                    new1.transform.parent = slot0.transform;
                    new1.transform.localPosition = new Vector3(0, 0, 0);
                }
                else if (index <= 7 && index > 5)
                {
                    GameObject new1 = GameObject.Instantiate(newblock1);
                    new1.transform.parent = slot0.transform;
                    new1.transform.localPosition = new Vector3(0, 0, 0);
                }
                else
                {
                    GameObject new1 = GameObject.Instantiate(newblock2);
                    new1.transform.parent = slot0.transform;
                    new1.transform.localPosition = new Vector3(0, 0, 0);
                }
        }
        //case of do have backup
        else
        {
            if (Time.time >= lastBackupTime + BackUpCoolDown)
            {
                lastBackupTime = Time.time;

                if (slot1.GetComponentsInChildren<Transform>(true).Length <= 1)
                {
                    // GameObject new1 = slot0.transform.child;
                    slot0.transform.GetChild(0).transform.parent = slot1.transform;
                    slot1.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
                }
                else if (slot2.GetComponentsInChildren<Transform>(true).Length <= 1)
                {
                    slot0.transform.GetChild(0).transform.parent = slot2.transform;
                    slot2.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
                }
                else if (slot3.GetComponentsInChildren<Transform>(true).Length <= 1)
                {
                    slot0.transform.GetChild(0).transform.parent = slot3.transform;
                    slot3.transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
                }
            }
         }

        // to test if block been draged out
        if (touch_scripts.WorldOrientationUp)
        {
            if (slot1.transform.GetChild(0).transform.position.y <= BlockLineTest.transform.position.y)
            {
                slot1.transform.DetachChildren();
            }
            if (slot2.transform.GetChild(0).transform.position.y <= BlockLineTest.transform.position.y)
            {
                slot2.transform.DetachChildren();
            }
            if (slot3.transform.GetChild(0).transform.position.y <= BlockLineTest.transform.position.y)
            {
                slot3.transform.DetachChildren();
            }
        }
        else
        {
            if (slot1.transform.GetChild(0) != null)
            {
                if (slot1.transform.GetChild(0).transform.position.y >= BlockLineTest.transform.position.y)
                {
                    slot1.transform.DetachChildren();
                }
                if (slot2.transform.GetChild(0).transform.position.y >= BlockLineTest.transform.position.y)
                {
                    slot2.transform.DetachChildren();
                }
                if (slot3.transform.GetChild(0).transform.position.y >= BlockLineTest.transform.position.y)
                {
                    slot3.transform.DetachChildren();
                }
            }
        }

    }
}
