using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    AudioSource source;
    public AudioClip gachiMeme;
   // GameObject button;
    
    void Start()
    {
        source= GetComponent<AudioSource>();
    }
    
void OnTriggerEnter()
{   GameObject.Find("FaceSystem").active = false;
    source.PlayOneShot(gachiMeme);
    gameManager.CompleteLevel();
}
    // Update is called once per frame
    void Update()
    {
     
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Level_01");
    }
     public void ExitButton()
    {
        Application.Quit();
    }
}
