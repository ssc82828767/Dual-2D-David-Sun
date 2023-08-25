using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBullet : MonoBehaviour
{
    public GameObject slot0;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject newbullet;
    public GameObject newbullet1;
    public GameObject newbullet2;
    public float lastBackupTime, BackUpCoolDown;

    // Start is called before the first frame update

    // private GameObject RandomBullet()
    // {
    //     return xx
    // }

    void Start()
    {
        //在四个位置各生成一个子弹
    }

    // Update is called once per frame
    void Update()
    {
        //case of backup slot empty
        if (slot0.GetComponentsInChildren<Transform>(true).Length <= 1)
        {
                float index = Random.Range(0, 10);
                if ( index <= 5)
                {
                    GameObject new1 = GameObject.Instantiate(newbullet);
                    new1.transform.parent = slot0.transform;
                    new1.transform.localPosition = new Vector3(0, 0, 0);
                }
                else if ( index <= 8 && index > 5)
                {
                    GameObject new1 = GameObject.Instantiate(newbullet1);
                    new1.transform.parent = slot0.transform;
                    new1.transform.localPosition = new Vector3(0, 0, 0);
                }
                else
                {
                    GameObject new1 = GameObject.Instantiate(newbullet2);
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
    }
}
