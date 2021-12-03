using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttributes : MonoBehaviour
{
    public bool isDamaging;
    public bool isTouch;
    public bool isSelf;
    public bool isPostMortem;
    public bool soulTrap;
    public float duration = 5f;
    public float magnitude;
    public float damage = 30f;
    public float area; // NOT USED IN REFERENCE VIDEO

    private Transform pos;
    [SerializeField] GameObject soulTrapObject;
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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We Hit: " + collision.gameObject.name);
        Debug.Log("isPostMortem is set to: " + isPostMortem);
        Debug.Log("Damage is currently: " + damage);
        Debug.Log("The HP of the Skeleton is: " + collision.gameObject.GetComponent<HP>().hp);
        if (isPostMortem && damage >= collision.gameObject.GetComponent<HP>().hp)
        { 
            soulTrap = true;
            pos = collision.gameObject.transform;
        }
        collision.gameObject.GetComponent<HP>().TakeDamage(DealDamage());
        if (soulTrap == true)
        {
            Debug.Log("The Position Is: " + pos.position);
            var obj = Instantiate(soulTrapObject, pos.position, Quaternion.identity) as GameObject;
        }
    }

    float DealDamage()
    {
        if (isDamaging == true)
            return damage;
        else
            return 0f;
    }
}
