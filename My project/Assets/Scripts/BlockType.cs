using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockType : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Click, CanPlaced, isBackUp;
    private TouchTest touch_scripts;
    private BulletType bullet_scripts;
    public int Hitpoint;
    public bool isBig;

    private void Start()
    {
        touch_scripts = GameObject.Find("TouchControl").GetComponent<TouchTest>();
        Click = false;
        isBig = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //test if draging a block
        if (!touch_scripts.currentBlockLock)
        {
            if (other.gameObject.tag == "Indicator" && !isBackUp)
            {
                touch_scripts.currentBlockLock = true;
                touch_scripts.currentBlock = this.gameObject;

                //animator control
                if (!isBig)
                {
                    isBig = true;
                    this.GetComponent<Animator>().ResetTrigger("Placed");
                    this.GetComponent<Animator>().ResetTrigger("ScaleDown");
                    this.GetComponent<Animator>().SetTrigger("ScaleUp");
                    this.GetComponent<Animator>().SetTrigger("ReDrag");
                }

                touch_scripts.currentBlock_initialPos = this.transform.position;
            }
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        //other.gameObject.tag == "Block")
        //
         // CanPlaced = false;
        //
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //when hit by a bullet
        if (other.gameObject.tag == "Bullet")
        {
            //Debug.Log("hithithit");
            bullet_scripts = other.gameObject.GetComponent<BulletType>();

            //animation
            this.GetComponent<Animator>().SetTrigger("Hit");
            this.GetComponent<AudioSource>().Play();

            Hitpoint = Hitpoint - bullet_scripts.Hitpoint;
            if (Hitpoint <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block")
        {
            CanPlaced = true;
        }
    }
    private void Update()
    {
        if (this.transform.parent.name == "BlockSlot0")
        {
            isBackUp = true;
        }
        else
        {
            isBackUp = false;
        }
    }
}