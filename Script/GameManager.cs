using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    private GameObject deathScreen;
    public GameObject Leveltheme;
    public GameObject completeLevelUI;
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        } else if (_instance != this)
        {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(this);
        InitGame();
    }
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        Leveltheme.SetActive(false);
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<Controller>().enabled = false;
        player.GetComponent<PlayerHealth>().enabled = false;
        foreach (Transform child in player.transform)
        {
            if (child.tag != "MainCamera")
                child.gameObject.SetActive(false);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.tag = "Untagged";
    }

    private void Start()
    {
        deathScreen = transform.Find("DeathScreen").gameObject;
        //completeLevelUI = transform.Find("Endlevel").gameObject;
    }

    void InitGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PlayerDeath()
    {
        deathScreen.SetActive(true);
        Leveltheme.SetActive(false);
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<Controller>().enabled = false;
        player.GetComponent<PlayerHealth>().enabled = false;
        foreach (Transform child in player.transform)
        {
            if (child.tag != "MainCamera")
                child.gameObject.SetActive(false);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.tag = "Untagged";
    }
}