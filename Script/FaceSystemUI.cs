using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceSystemUI : MonoBehaviour
{
    // HP = HitPoints, SHT = While Shooting, DMG = While taking damage
    // FW = Forward, L = Left, R = Right
    // Numbers are the HP ranges for the different faces
    
    public Image Face;
    
       int pick;

    Sprite[] sprites;
    public Sprite SHT80100;
    int i;
    float timer;

    public PlayerHealth PlayerHealth;
    //public Image healthIndicator;
    public Sprite madddead;
    void Start()
    { /*
        // have every image in an array for easy access

        //imgs = new Texture2D[26];

        imgs[0] = HP80100FW;
        imgs[1] = HP80100L;
        imgs[2] = HP80100R;

        imgs[3] = HP6079FW;
        imgs[4] = HP6079L;
        imgs[5] = HP60790R;

        imgs[6] = HP4059FW;
        imgs[7] = HP4059L;
        imgs[8] = HP4059R;

        imgs[9] = HP2039FW;
        imgs[10] = HP2039L;
        imgs[11] = HP2039R;

        imgs[12] = HP119FW;
        imgs[13] = HP119L;
        imgs[14] = HP119R;

        imgs[15] = HP0;

        imgs[16] = SHT80100;
        imgs[17] = SHT6079;
        imgs[18] = SHT4059;
        imgs[19] = SHT2039;
        imgs[20] = SHT119;

        imgs[21] = DMG80100;
        imgs[22] = DMG6079;
        imgs[23] = DMG4059;
        imgs[24] = DMG2039;
        imgs[25] = DMG119;
        */
    }
    
    void Update()
    {
        Faces();
    }

    public void Faces()
    {
        timer -= Time.deltaTime;

        // modify the timers to your liking
        
        if (PlayerHealth.health >= 80 & PlayerHealth.health <= 100 || PlayerHealth.health >100)
        {
            if (Input.GetMouseButton(0) && timer <1f)
            {
                timer = 1f;
                pick = 16;
                Face.sprite = SHT80100;
                timer-=Time.deltaTime;
            }

            if (PlayerHealth.isDamaged == true)   // add a bool for when damaged in your health script!
            {
                timer = 0.5f;
                pick = 21;
            }

            if (timer < 0 & !Input.GetMouseButton(0))
            {
                timer = 1.5f; 

                // get a random number not equal to current
                i = pick;
                while (i == pick)
                {
                    pick = Random.Range(0, 3);
                }

            }
        }
        if (PlayerHealth.health >= 60 & PlayerHealth.health <= 79)
        {
            if (Input.GetMouseButton(0))
            {
                timer = 1f;
                pick = 17;
            }

            if (PlayerHealth.isDamaged == true)
            {
                timer = 0.5f;
                pick = 22;
            }

            if (timer < 0 & !Input.GetMouseButton(0))
            {
                timer = 1.5f; 

                // get a random number not equal to current
                i = pick;
                while (i == pick)
                {
                    pick = Random.Range(3, 6);
                }
            }
        }
        if (PlayerHealth.health >= 40 & PlayerHealth.health <= 59)
        {
            if (Input.GetMouseButton(0))
            {
                timer = 1f;
                pick = 18;
                
            }

            if (PlayerHealth.isDamaged == true)
            {
                timer = 0.5f;
                pick = 23;
            }

            if (timer < 0 & !Input.GetMouseButton(0))
            {
                timer = 1.5f; 

                // get a random number not equal to current
                i = pick;
                while (i == pick)
                {
                    pick = Random.Range(6, 9);
                }
            }
        }
        if (PlayerHealth.health >= 20 & PlayerHealth.health <= 39)
        {
            if (Input.GetMouseButton(0))
            {
                timer = 1f;
                pick = 19;
            }

            if (PlayerHealth.isDamaged == true)
            {
                timer = 0.5f;
                pick = 24;
            }

            if (timer < 0 & !Input.GetMouseButton(0))
            {
                timer = 1.5f; 

                // get a random number not equal to current
                i = pick;
                while (i == pick)
                {
                    pick = Random.Range(9, 12);
                }
            }
        }
        if (PlayerHealth.health >= 1 & PlayerHealth.health <= 19)
        {
            if (Input.GetMouseButton(0))
            {
                timer = 1f;
                pick = 20;
            }

            if (PlayerHealth.isDamaged == true)
            {
                timer = 0.5f;
                pick = 25;
            }

            if (timer < 0 & !Input.GetMouseButton(0))
            {
                timer = 1.5f; 

                // get a random number not equal to current
                i = pick;
                while (i == pick)
                {
                    pick = Random.Range(12, 15);
                }
            }
        }
        if (PlayerHealth.health <= 0)
        {
            pick = 15;
        }
    }
   
    private void OnGUI()
    {
        if(PlayerHealth.health >0)
        {
            // GUI.DrawTexture(new Rect(695,830, 515, 315), imgs[pick]);
        }
        else
        {
           // healthIndicator.sprite= madddead;
        }
    }
}