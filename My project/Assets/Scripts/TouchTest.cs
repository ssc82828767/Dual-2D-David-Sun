using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    //public Vector2 TouchPosWorld2D;
    public GameObject Indicator, Indicator1, Line, Barrel, Cannon;
    private Color IndicatorColor, IndicatorColor1;
    // public Touch TouchUp, TouchDown;
    //public int TouchUpID, TouchDownID;
    public Vector2 currentBullet_initialPos;
    public Vector2 currentBlock_initialPos;
    //put it into BulletType
    public bool isRotatingBarrel, Firing, hasUpTouch, hasDownTouch;

    private int touchUpNum, touchDownNum;
    public float RotateSpeed;

    public GameObject currentBullet;
    public GameObject currentBlock;
    public Transform FiringPlace;
    public bool WorldOrientationUp;

    public GameObject BlockLineTest;
    public GameObject FireLine;

    //public float rotateZ;
    public Vector3 forward;
    public Quaternion BarrelStartRotation;

    //Lockup the currentBlock and currentBullet
    public bool currentBlockLock;
    public bool currentBulletLock;

    private BulletType bullet_scripts;
    private BlockType block_scripts;


    private void Awake()
    {
        IndicatorColor = Indicator.GetComponent<SpriteRenderer>().color;
        IndicatorColor1 = Indicator1.GetComponent<SpriteRenderer>().color;
        BarrelStartRotation = Barrel.transform.localRotation;
    }

    private void Start()
    {
        Indicator.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        Indicator1.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        currentBullet = null;

        //检测是否已经在drag
        currentBlockLock = false;
        currentBulletLock = false;

        hasUpTouch = false;
        hasDownTouch = false;
    }

    public Vector2 CaculateWorldPos(Touch t)
    {
        Vector2 ScreenPos = t.position;
        Vector3 WorldPos3D = Camera.main.ScreenToWorldPoint(new Vector3(ScreenPos.x, ScreenPos.y, 0));
        Vector2 WorldPos2D = new Vector2(WorldPos3D.x, WorldPos3D.y);

        return WorldPos2D;
    }

    void ShowIndicator(Touch touch, GameObject Indicator, Vector2 pos, Color InColor)
    {
        //Vector2 TouchPosWorld2D = CaculateWorldPos(touch);
        Indicator.transform.position = pos;

        if (touch.phase == TouchPhase.Began)
            Indicator.GetComponent<SpriteRenderer>().color = InColor;
        if (touch.phase == TouchPhase.Ended)
        {
            Indicator.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }

    }

    void DragBlock(Touch touch, Vector2 pos)
    {
        if (currentBlock != null && touch.phase == TouchPhase.Moved)
        {
            currentBlock.transform.position = pos;

            //disable collider when being draged
            if (!currentBlock.GetComponent<Collider2D>().isTrigger)
            {
                currentBlock.GetComponent<Collider2D>().isTrigger = true;
            }
        }

        if (touch.phase == TouchPhase.Ended)
        {
            //检测落点是否被阻挡
            //if (!currentBlock.GetComponent<BlockType>().CanPlaced)
            // {
            //  currentBlock.transform.position = currentBlock_initialPos;
            //   currentBlock = null;
            //  }
            //  else
            // {

            currentBlock.GetComponent<Collider2D>().isTrigger = false;
            // }

            block_scripts = currentBlock.gameObject.GetComponent<BlockType>();

            //release the currentblock lockup
            currentBlockLock = false;

            //test if been draged back to slots
            if (WorldOrientationUp)
            {
                if (currentBlock.transform.position.y >= BlockLineTest.transform.position.y)
                {
                    //animation
                    block_scripts.isBig = false;
                    currentBlock.GetComponent<Animator>().ResetTrigger("ReDrag");
                    currentBlock.GetComponent<Animator>().ResetTrigger("ScaleUp");
                    currentBlock.GetComponent<Animator>().SetTrigger("ScaleDown");
                    currentBlock.GetComponent<Animator>().SetTrigger("Return");
                    //reset block position
                    currentBlock.transform.position = currentBlock_initialPos;
                    currentBlock = null;
                }
                else
                {
                    //animation
                    block_scripts.isBig = false;
                    currentBlock.GetComponent<Animator>().ResetTrigger("ReDrag");
                    currentBlock.GetComponent<Animator>().SetTrigger("Placed");
                    currentBlock.GetComponent<Animator>().ResetTrigger("ScaleUp");
                    currentBlock.GetComponent<Animator>().ResetTrigger("ScaleDown");
                    currentBlock = null;
                }
            }
            else
            {
                if (currentBlock.transform.position.y <= BlockLineTest.transform.position.y)
                {
                    //animation
                    block_scripts.isBig = false;
                    currentBlock.GetComponent<Animator>().ResetTrigger("ReDrag");
                    currentBlock.GetComponent<Animator>().ResetTrigger("ScaleUp");
                    currentBlock.GetComponent<Animator>().SetTrigger("ScaleDown");
                    currentBlock.GetComponent<Animator>().SetTrigger("Return");
                    //reset block position
                    currentBlock.transform.position = currentBlock_initialPos;
                    currentBlock = null;
                }
                else
                {
                    //animation
                    block_scripts.isBig = false;
                    currentBlock.GetComponent<Animator>().ResetTrigger("ReDrag");
                    currentBlock.GetComponent<Animator>().SetTrigger("Placed");
                    currentBlock.GetComponent<Animator>().ResetTrigger("ScaleUp");
                    currentBlock.GetComponent<Animator>().ResetTrigger("ScaleDown");
                    currentBlock = null;
                }
            }
        }
    }

    void DragBullet(Touch touch, Vector2 pos)
    {
        if (currentBullet != null && touch.phase == TouchPhase.Moved)
        {
            currentBullet.transform.position = pos;
            //拿起状态下禁用collider
            if (!currentBullet.GetComponent<Collider2D>().isTrigger)
            {
                currentBullet.GetComponent<Collider2D>().isTrigger = true;
            }

            //reset barrel
            if (Barrel.transform.localRotation != BarrelStartRotation)
            {
                Barrel.transform.localRotation = BarrelStartRotation;
            }

            //animation of cannon
            Cannon.GetComponent<Animator>().SetTrigger("Hint");
            Cannon.GetComponent<Animator>().ResetTrigger("Charged");
            Cannon.GetComponent<Animator>().ResetTrigger("Cancel");
            Cannon.GetComponent<Animator>().ResetTrigger("Fired");
        }

        if (touch.phase == TouchPhase.Ended)
        {
            //animation
            currentBullet.GetComponent<Animator>().ResetTrigger("ScaleUp");
            currentBullet.GetComponent<Animator>().ResetTrigger("Fire");
            currentBullet.GetComponent<Animator>().SetTrigger("ScaleDown");
            Cannon.GetComponent<Animator>().ResetTrigger("Hint");
            Cannon.GetComponent<Animator>().ResetTrigger("Fired");
            Cannon.GetComponent<Animator>().ResetTrigger("Charged");
            Cannon.GetComponent<Animator>().SetTrigger("Cancel");
            //return position
            currentBullet.transform.position = currentBullet_initialPos;
            currentBullet.GetComponent<Collider2D>().isTrigger = false;
            currentBulletLock = false;
            currentBullet = null;
        }
    }

    void FireBullet()
    {
        currentBullet.transform.position = FiringPlace.position;
        currentBullet.SetActive(true);
        currentBullet.GetComponent<Collider2D>().isTrigger = false;
        Rigidbody2D bulletRigi = currentBullet.GetComponent<Rigidbody2D>();
        //https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html
        bulletRigi.AddForce(Barrel.transform.up * currentBullet.GetComponent<BulletType>().FiringSpeed);

        //animation
        currentBullet.GetComponent<Animator>().SetTrigger("ScaleUp");
        currentBullet.GetComponent<Animator>().ResetTrigger("ScaleDown");
        currentBullet.GetComponent<Animator>().SetTrigger("Fire");

        this.GetComponent<AudioSource>().Play();

        currentBullet = null;
        Firing = false;
        currentBulletLock = false;
    }

    bool checkBarrelRoatation()
    {
        if (Barrel.transform.localRotation.eulerAngles.z <= 60 && Barrel.transform.localRotation.eulerAngles.z >= 0)
        {
            return true;
        }
        else if (Barrel.transform.localRotation.eulerAngles.z >= 300 && Barrel.transform.localRotation.eulerAngles.z <= 360)
        {
            return true;
        }
        else
            return false;
    }
    void LockBarrelRotation()
    {
        float z = Barrel.transform.localRotation.eulerAngles.z;
        if (z <= 180 && z > 60)
        {
            Barrel.transform.localRotation = Quaternion.Euler(0, 0, 60);
        }
        else if (z > 180 && z < 300)
        {
            Barrel.transform.localRotation = Quaternion.Euler(0, 0, 300);
        }
    }

    void RotateBarrel(Touch touch, Vector2 pos)
    {
        if (touch.phase == TouchPhase.Moved)
        {
            //animation
            Cannon.GetComponent<Animator>().SetTrigger("Charged");

            forward = Barrel.transform.up;
            if (WorldOrientationUp)
            {
                Barrel.transform.Rotate(new Vector3(0, 0, -touch.deltaPosition.x * RotateSpeed));
                LockBarrelRotation();
            }
            else
            {
                Barrel.transform.Rotate(new Vector3(0, 0, touch.deltaPosition.x * RotateSpeed));
                LockBarrelRotation();
            }
        }
        if (touch.phase == TouchPhase.Ended)
        {
            isRotatingBarrel = false;
            Firing = true;
            bullet_scripts = currentBullet.gameObject.GetComponent<BulletType>();
            bullet_scripts.isFired = true;
            FireBullet();
            Cannon.GetComponent<Animator>().SetTrigger("Fired");
            Cannon.GetComponent<Animator>().ResetTrigger("Hint");
            Cannon.GetComponent<Animator>().ResetTrigger("Cancel");
            Cannon.GetComponent<Animator>().ResetTrigger("Charged");
        }
    }

    bool CompareY(bool Orien, Vector2 touchPos)
    {
        if (Orien)
        {
            return touchPos.y > Line.transform.position.y;
        }

        else
        {
            return touchPos.y < Line.transform.position.y;
        }
    }


    // Update is called once per frame
    void Update()
    {
        touchDownNum = 0;
        touchUpNum = 0;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch thisTouch = Input.GetTouch(i);
            Vector2 thisTouchPos2D = CaculateWorldPos(thisTouch);

            if (CompareY(WorldOrientationUp, thisTouchPos2D))
            {
                //UP-----------------------
                touchUpNum++;
                if (touchUpNum == 1)
                {
                    ShowIndicator(thisTouch, Indicator, thisTouchPos2D, IndicatorColor);
                    DragBlock(thisTouch, thisTouchPos2D);
                }
            }
            else
            {
                //DOWN---------------------
                touchDownNum++;
                if (touchDownNum == 1)
                {
                    ShowIndicator(thisTouch, Indicator1, thisTouchPos2D, IndicatorColor1);
                }

                //drag bullet
                if (!isRotatingBarrel)
                {
                    DragBullet(thisTouch, thisTouchPos2D);
                }

                if (isRotatingBarrel)
                {
                    RotateBarrel(thisTouch, thisTouchPos2D);
                }
                //release
            }
        }
    }
}
