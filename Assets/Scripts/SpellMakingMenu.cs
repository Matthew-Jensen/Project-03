using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] XRay detectLifeEffect;
    [SerializeField] GameObject fireEffect;
    [SerializeField] GameObject frostEffect;
    [SerializeField] GameObject lightEffect;
    [SerializeField] GameObject nightEyeEffect;
    [SerializeField] GameObject soulTrapEffect;

    [SerializeField] TrackEffectValues DL;
    [SerializeField] TrackEffectValues FD;
    [SerializeField] TrackEffectValues FrD;
    [SerializeField] TrackEffectValues L;
    [SerializeField] TrackEffectValues NE;
    [SerializeField] TrackEffectValues ST;

    [SerializeField] GameObject DL_Btn;
    [SerializeField] GameObject FD_Btn;
    [SerializeField] GameObject FrD_Btn;
    [SerializeField] GameObject L_Btn;
    [SerializeField] GameObject NE_Btn;
    [SerializeField] GameObject ST_Btn;

    [SerializeField] GameObject DL_Desc;
    [SerializeField] GameObject FD_Desc;
    [SerializeField] GameObject FrD_Desc;
    [SerializeField] GameObject L_Desc;
    [SerializeField] GameObject NE_Desc;
    [SerializeField] GameObject ST_Desc;

    private GameObject currentSubmenu;
    public GameObject[] customSpellArray;
    private GameObject customSpell;

    private float range;
    public float[] temp = { 0, 0, 0, 0 };
    
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

    public GameObject CreateSpell()
    {
        //Generating Empty Spell
        GameObject spellInstance = new GameObject();
        //Attaching SpellAttributes Component
        spellInstance.AddComponent<SpellAttributes>();
        switch (temp[0])
        {
            case 0f: spellInstance.GetComponent<SpellAttributes>().isTouch = true;  break;
            case 2f: spellInstance.GetComponent<SpellAttributes>().isSelf = true; break;

            default: break;
        }
        spellInstance.GetComponent<SpellAttributes>().magnitude = temp[1];
        spellInstance.GetComponent<SpellAttributes>().area = temp[2];
        spellInstance.GetComponent<SpellAttributes>().duration = temp[3];

        //Return Spell
        return spellInstance;
        
    }

    public void AddEffect_DetectLife()
    {
        //OPENS SUB MENU FOR ATTRIBUTES
        spellMakingUI.SetActive(false);
        subSpell_DL.SetActive(true);
        currentSubmenu = GameObject.Find("SubSM_Menu_DetectLife");
    }

    public void AddEffect_FireDamage()
    {
        //OPENS SUB MENU FOR ATTRIBUTES
        spellMakingUI.SetActive(false);
        subSpell_FD.SetActive(true);
        currentSubmenu = GameObject.Find("SubSM_Menu_FireDamage");
    }

    public void AddEffect_FrostDamage()
    {
        //OPENS SUB MENU FOR ATTRIBUTES
        spellMakingUI.SetActive(false);
        subSpell_FrD.SetActive(true);
        currentSubmenu = GameObject.Find("SubSM_Menu_FrostDamage");
    }

    public void AddEffect_Light()
    {
        //OPENS SUB MENU FOR ATTRIBUTES
        spellMakingUI.SetActive(false);
        subSpell_L.SetActive(true);
        currentSubmenu = GameObject.Find("SubSM_Menu_Light");
    }

    public void AddEffect_NightEye()
    {
        //OPENS SUB MENU FOR ATTRIBUTES
        spellMakingUI.SetActive(false);
        subSpell_NE.SetActive(true);
        currentSubmenu = GameObject.Find("SubSM_Menu_Night-Eye");
    }

    public void AddEffect_SoulTrap()
    {
        //OPENS SUB MENU FOR ATTRIBUTES
        spellMakingUI.SetActive(false);
        subSpell_ST.SetActive(true);
        currentSubmenu = GameObject.Find("SubSM_Menu_SoulTrap");
    }

    public void CancelEffect()
    {
        currentSubmenu.transform.Find("RangeBtn").GetComponentInChildren<Text>().text =
            "Range:                                                      Touch";
        currentSubmenu.transform.Find("Slider_Magnitude").GetComponent<Slider>().value = 
            currentSubmenu.transform.Find("Slider_Magnitude").GetComponent<Slider>().minValue;
        currentSubmenu.transform.Find("Slider_Area").GetComponent<Slider>().value =
            currentSubmenu.transform.Find("Slider_Area").GetComponent<Slider>().minValue;
        currentSubmenu.transform.Find("Slider_Duration").GetComponent<Slider>().value =
            currentSubmenu.transform.Find("Slider_Duration").GetComponent<Slider>().minValue;
        switch (currentSubmenu.transform.name)
        {
            case "SubSM_Menu_DetectLife": DL_Desc.SetActive(false); DL_Btn.SetActive(true); break;
            case "SubSM_Menu_FireDamage": FD_Desc.SetActive(false); FD_Btn.SetActive(true); break;
            case "SubSM_Menu_FrostDamage": FrD_Desc.SetActive(false); FrD_Btn.SetActive(true); break;
            case "SubSM_Menu_Light": L_Desc.SetActive(false); L_Btn.SetActive(true); break;
            case "SubSM_Menu_Night-Eye": NE_Desc.SetActive(false); NE_Btn.SetActive(true); break;
            case "SubSM_Menu_SoulTrap": ST_Desc.SetActive(false); ST_Btn.SetActive(true); break;
        }
        currentSubmenu.SetActive(false);
        spellMakingUI.SetActive(true);
    }

    public void ConfirmEffect()
    {
        float rangeType = range;
        float magnitude = currentSubmenu.transform.Find("Slider_Magnitude").GetComponent<Slider>().value;
        float area = currentSubmenu.transform.Find("Slider_Area").GetComponent<Slider>().value;
        float duration = currentSubmenu.transform.Find("Slider_Duration").GetComponent<Slider>().value;
        temp[0] = rangeType;
        temp[1] = magnitude;
        temp[2] = area;
        temp[3] = duration;
        spellMakingUI.SetActive(true);
        switch (currentSubmenu.transform.name)
        {
            case "SubSM_Menu_DetectLife": DL_Desc.SetActive(true); DL.UpdateValues_FT(); DL_Btn.SetActive(false); break;
            case "SubSM_Menu_FireDamage": FD_Desc.SetActive(true); FD.UpdateValues(); FD_Btn.SetActive(false); break;
            case "SubSM_Menu_FrostDamage": FrD_Desc.SetActive(true); FrD.UpdateValues(); FrD_Btn.SetActive(false); break;
            case "SubSM_Menu_Light": L_Desc.SetActive(true); L.UpdateValues_FT(); L_Btn.SetActive(false); break;
            case "SubSM_Menu_Night-Eye": NE_Desc.SetActive(true); NE.UpdateDurationOnly(); NE_Btn.SetActive(false); break;
            case "SubSM_Menu_SoulTrap": ST_Desc.SetActive(true); ST.UpdateDurationTarget(); ST_Btn.SetActive(false); break;
        }
        currentSubmenu.SetActive(false);
        
        
    }

    public void CycleRange()
    {
        float rangeType = 0f;
        switch (currentSubmenu.transform.Find("RangeBtn").GetComponentInChildren<Text>().text)
        {
            case "Range:                                                      Touch":
                currentSubmenu.transform.Find("RangeBtn").GetComponentInChildren<Text>().text =
                   "Range:                                                      Target"; rangeType = 1f; break;

            case "Range:                                                      Target":
                currentSubmenu.transform.Find("RangeBtn").GetComponentInChildren<Text>().text =
                   "Range:                                                      Self"; rangeType = 2f;  break;

            case "Range:                                                      Self":
                currentSubmenu.transform.Find("RangeBtn").GetComponentInChildren<Text>().text =
                   "Range:                                                      Touch"; rangeType = 3f;  break;
        }
        range = rangeType;
    }
}
