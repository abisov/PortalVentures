using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour
{
   void MeleAtack()
    {
        this.transform.GetComponentInParent<Player>().Melee();
    }

    void EndAtack()
    {
        this.transform.GetComponentInParent<Player>().isAtacking = false;
    }
}
