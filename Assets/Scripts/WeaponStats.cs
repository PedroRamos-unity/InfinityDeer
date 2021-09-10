using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObject/Weapon")]
[System.Serializable]
public class WeaponStats : ScriptableObject
{

    [Header("Basic weapon traits")]
    public GameObject BulletPrefab;
    

    public float FireRate;
    public float ShotSpread;

    public int Damage;
    public int MagazineSize;
    public int MagazineAmmount;

    public bool AllowButtonHold;




}
