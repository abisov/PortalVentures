using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat
{
    private Character character;
    private int baseDamage = 1;

    public Combat(Character character)
    {
        this.character = character;
    }

    public Combat(Character character, int baseDamage)
    {
        this.character = character;
        this.baseDamage = baseDamage;
    }
    public void Melee()
    {

        Vector3 pos = character.transform.position;

        for (int i = 0; i < character.Damageables.Count; i++)
        {
            Vector3 vec = character.Damageables[i].transform.position;
            Vector3 direction = vec - pos;

            if (Vector3.Dot(direction, character.transform.forward) < 2.7)
            {
                Debug.Log(character.chInventory);
                var bonusDamage = character.chInventory != null ? character.damage * character.chInventory.equipedWeapon.damage : character.damage;
                character.Damageables[i].GetComponent<Damageable>().ApplyDamage(bonusDamage + baseDamage);
                if (character.Damageables[i].health <= 0)
                {
                    character.Damageables.RemoveAt(i);
                }
            }
        }


    }


}
