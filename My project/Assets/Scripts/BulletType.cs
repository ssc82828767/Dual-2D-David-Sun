using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType : MonoBehaviour
{
    // Start is called before the first frame update
    //information about this bullet
    public bool Click, isBackUp, isFired;
    private TouchTest touch_scripts;
    public float FiringSpeed;
    public int Hitpoint;
    public float lastBackupTime, BackUpCoolDown;

    private void Start()
    {
        touch_scripts = GameObject.Find("TouchControl").GetComponent<TouchTest>();
        Click = false;
        isFired = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Indicator" && !isBackUp)
        {
            if (!touch_scripts.currentBulletLock && !isFired)
            {
                touch_scripts.currentBulletLock = true;
                touch_scripts.currentBullet = this.gameObject;
                touch_scripts.currentBullet_initialPos = this.transform.position;

                //animation
                this.GetComponent<Animator>().ResetTrigger("ScaleDown");
                this.GetComponent<Animator>().ResetTrigger("Fire");
                this.GetComponent<Animator>().SetTrigger("ScaleUp");
            }
        }

        if (other.gameObject.tag == "Cannon" && !touch_scripts.Firing)
        {
            touch_scripts.isRotatingBarrel = true;
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Indicator")
        {

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //when hit
        if (other.gameObject.tag == "Block")
        {
            if (Time.time >= lastBackupTime + BackUpCoolDown)
            {
                lastBackupTime = Time.time;
                Destroy(gameObject);
            }
            
        }
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Debug.Log("get key");
        //     this.GetComponent<Rigidbody2D>().AddForce(this.transform.up * 1000);
        // }


        if (this.transform.parent.name == "BulletSlot0")
        {
            isBackUp = true;
        }
        else
        {
            isBackUp = false;
        }
    }


}
