using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponsManager
{
    public static List<Weapon> weapons = new List<Weapon>() {
                new Weapon(0, "Old Short Sword", 5, 50, true, Weapon.WeaponType.Sword),
                new Weapon(1, "Golden Short Sword", 5, 50, true, Weapon.WeaponType.Sword)
            };



    public static Weapon GetWeapon(int id)
    {
        return weapons.Find(Weapon => Weapon.Id == id);
    }

    public static Weapon GetWeapon(string weaponName)
    {
        return weapons.Find(Weapon => Weapon.Name == weaponName);
    }
}
