using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttributes : MonoBehaviour
{
    public bool isDamaging;
    public bool isTouch;
    public bool isSelf;
    public float duration = 5f;
    public float magnitude;
    public float area; // NOT USED IN REFERENCE VIDEO
    // Start is called before the first frame update
    void Start()
    {
        DestroySpell();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroySpell()
    {
        Destroy(gameObject, duration);
    }
}
