using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    public int Hitpoint;
    private BulletType bullet_scripts;
    private Rounds round_script;

    public GameObject Healthbar;
    public Text HealthText;

    private DontDestorySc DDscript;
    private TouchTest touch_scripts;

    // Start is called before the first frame update
    void Start()
    {
        round_script = GameObject.Find("field").GetComponent<Rounds>();
        DDscript = GameObject.Find("DontDestory").GetComponent<DontDestorySc>();
        touch_scripts = GameObject.Find("TouchControl").GetComponent<TouchTest>();
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.transform.localScale = new Vector3((float)Hitpoint / 10, 1, 1);
        HealthText.text = (((float)Hitpoint / 10) * 100).ToString() + "%";

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //when hit by a bullet
        if (other.gameObject.tag == "Bullet")
        {
            //animation
            this.GetComponent<Animator>().SetTrigger("Hit");
            this.GetComponent<AudioSource>().Play();

            bullet_scripts = other.gameObject.GetComponent<BulletType>();
            Hitpoint = Hitpoint - bullet_scripts.Hitpoint;
            if (Hitpoint <= 0)
            {
                Destroy(gameObject);
                if (touch_scripts.WorldOrientationUp)
                {
                    DDscript.PlayerAPoints += 1;
                }
                else
                {
                    DDscript.PlayerBPoints += 1;
                }
                //new round
                round_script.roundend();
            }
        }
    }
}
