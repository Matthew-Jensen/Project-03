using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellMakingMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject spellMakingUI;
    public GameObject subSpell_DL;
    public GameObject subSpell_FD;
    public GameObject subSpell_FrD;
    public GameObject subSpell_L;
    public GameObject subSpell_NE;
    public GameObject subSpell_ST;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                StopGame();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        spellMakingUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void StopGame()
    {
        Cursor.lockState = CursorLockMode.None;
        spellMakingUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void CreateSpell()
    { 
        
    }

    public void AddEffect_DetectLife()
    {
        //OPENS SUB MENU FOR ATTRIBUTES
        spellMakingUI.SetActive(false);
        subSpell_DL.SetActive(true);
    }

    public void AddEffect_FireDamage()
    {
        //OPENS SUB MENU FOR ATTRIBUTES
        spellMakingUI.SetActive(false);
        subSpell_FD.SetActive(true);
    }

    public void AddEffect_FrostDamage()
    {
        //OPENS SUB MENU FOR ATTRIBUTES
        spellMakingUI.SetActive(false);
        subSpell_FrD.SetActive(true);
    }

    public void AddEffect_Light()
    {
        //OPENS SUB MENU FOR ATTRIBUTES
        spellMakingUI.SetActive(false);
        subSpell_L.SetActive(true);
    }

    public void AddEffect_NightEye()
    {
        //OPENS SUB MENU FOR ATTRIBUTES
        spellMakingUI.SetActive(false);
        subSpell_NE.SetActive(true);
    }

    public void AddEffect_SoulTrap()
    {
        //OPENS SUB MENU FOR ATTRIBUTES
        spellMakingUI.SetActive(false);
        subSpell_ST.SetActive(true);
    }
}
