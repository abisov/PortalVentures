using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    [SerializeField]
    private string targetTag = "Damageable";
    private Character character;

    

    private void Start()
    {
        character = this.GetComponentInParent<Character>();
    }
    protected void OnTriggerEnter(Collider col)
    {
        var Damageables = character.Damageables;
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == targetTag)
        {
            Damageables.Add(col.GetComponentInParent<Damageable>());
        }


    }
    protected void OnTriggerExit(Collider col)
    {
        var Damageables = character.Damageables;

        if (col.gameObject.tag == targetTag)
            Damageables.Remove(col.GetComponent<Damageable>());

    }
}
