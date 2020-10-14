using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat
{
    private Character character;

    public Combat(Character character)
    {
        this.character = character;
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
                character.Damageables[i].GetComponent<Damageable>().ApplyDamage(character.damage);
                if (character.Damageables[i].health <= 0)
                {
                    character.Damageables.RemoveAt(i);
                }
            }
        }


    }
}
