using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class FaceSystem : MonoBehaviour
{
    // HP = HitPoints, SHT = While Shooting, DMG = While taking damage
    // FW = Forward, L = Left, R = Right
    // Numbers are the HP ranges for the different faces
    public Image Face;
    public Texture2D HP80100FW;
    public Texture2D HP80100L;
    public Texture2D HP80100R;

    public Texture2D HP6079FW;
    public Texture2D HP6079L;
    public Texture2D HP60790R;

    public Texture2D HP4059FW;
    public Texture2D HP4059L;
    public Texture2D HP4059R;

    public Texture2D HP2039FW;
    public Texture2D HP2039L;
    public Texture2D HP2039R;

    public Texture2D HP119FW;
    public Texture2D HP119L;
    public Texture2D HP119R;

    public Texture2D HP0;

    public Texture2D SHT80100;
    public Texture2D SHT6079;
    public Texture2D SHT4059;
    public Texture2D SHT2039;
    public Texture2D SHT119;

    public Texture2D DMG80100;
    public Texture2D DMG6079;
    public Texture2D DMG4059;
    public Texture2D DMG2039;
    public Texture2D DMG119;

    int pick;

    Texture2D[] imgs;
    int i;
    float timer;

    public PlayerHealth PlayerHealth;
    public Image healthIndicator;
    public Sprite madddead;
    
    void Start()
    {
        // have every image in an array for easy access

        imgs = new Texture2D[26];

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
            if (Input.GetMouseButton(0))
            {
                timer = 1f;
                
                pick = 16;
                
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
    private void FacesUI(int pick)
    {
        switch(pick)
        {case 0:

        break;
         case 1:

         break;
         case 2:

         break;
         case 3:

         break;
         case 4:

         break;
         case 5:

         break;
         case 6:

         break;
         case 7:

         break;
         case 8:

         break;
         case 9:

         break;
         case 10:

         break;
         case 11:

         break;
         case 12:

         break;
         case 13:

        break;
         case 14:

         break;
         case 15:

         break;
         case 16:

         break;
         case 17:

         break;
         case 18:

         break;
         case 19:

         break;
         case 20:

         break;
         case 21:

         break;
         case 22:

         break;
         case 23:

         break;
         case 24:

         break;
         case 25:

         break;






        }
        

    }
    
    private void OnGUI()
    {
        if(PlayerHealth.health >0)
        {
             GUI.DrawTexture(new Rect(713,830, 490, 310), imgs[pick]);
        }
        else
        {
            healthIndicator.sprite= madddead;
        }
    }
}