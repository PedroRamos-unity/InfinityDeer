using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public WeaponStats weapon;

    [SerializeField] private Transform playerHand;

    private Vector3 gunRot = new Vector3(-3.374f, 107.698f, 40.918f);
    private Vector3 gunPos = new Vector3(0.02659734f, -0.04856205f, 0.0502904f);

    private Character character;
    private bool shooting;

    private float nextTimeToShoot;

    [HideInInspector]public BoxCollider boxCol;
    [HideInInspector]public Rigidbody rb;

    [SerializeField] private Transform projectileSpawn;
     
    [HideInInspector] public float FireRate;
    [HideInInspector]public float ShotSpread;
     
    [HideInInspector] public int Damage;
    [HideInInspector]public int MagazineSize;
    [HideInInspector]public int MagazineAmmount;
    [HideInInspector] public int BulletsInMagazine;
    [HideInInspector]public int TotalBullets;
    [HideInInspector]public int BulletsLeft;
     
    [HideInInspector] public bool IsEquiped;
    [HideInInspector] public bool AllowButtonHold;
    [HideInInspector] public bool IsReloading;

    private void Awake()
    {
        
        boxCol = GetComponent<BoxCollider>();
        character = FindObjectOfType<Character>();
        playerHand = FindObjectOfType<PlayerHand>().transform;

        SetValues(weapon.FireRate, weapon.ShotSpread, weapon.Damage, weapon.MagazineSize, weapon.MagazineAmmount, weapon.AllowButtonHold);
        BulletsInMagazine = MagazineAmmount * MagazineSize;
        TotalBullets = BulletsInMagazine;
        BulletsLeft = MagazineSize;
        BulletsInMagazine -= BulletsLeft;

    }

    private  void Update()
    {
        
        MyInputs();
    }

    private void MyInputs()
    {
        if (AllowButtonHold) shooting = Input.GetButton("Fire1");
        else shooting = Input.GetButtonDown("Fire1");

        if(Input.GetKeyDown(KeyCode.R) && BulletsLeft < MagazineSize && !IsReloading && IsEquiped && BulletsInMagazine > 0)
        {
            
            StartCoroutine("ReloadTime");
        }
        
        if( shooting && !IsReloading && BulletsLeft > 0 && BulletsInMagazine >= 0 && Time.time >= nextTimeToShoot && IsEquiped)
        {

            nextTimeToShoot = Time.time + 1f / weapon.FireRate;           
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            DropGun();
        }

    }
    public void OnPickUp(Guns obj)
    {
        if(character.EquipedWeapon == null)
        {
            obj.rb = obj.GetComponent<Rigidbody>();
            ChangeRigidbodyStats(obj.rb);
            obj.boxCol.enabled = false;
            obj.transform.SetParent(playerHand);
            obj.transform.localPosition = gunPos;
            obj.transform.localRotation = Quaternion.Euler(gunRot);
            character.EquipedWeapon = obj;
            obj.IsEquiped = true;
            Actions.HandleAmmoChanged?.Invoke(obj);
        }
        else
        {
            DropGun();
            
        }

    }

    public void DropGun()
    {
        if(character.EquipedWeapon != null)
        {
            Guns gun = character.EquipedWeapon;
            ChangeRigidbodyStats(gun.rb);
            gun.boxCol.enabled = true;
            gun.transform.SetParent(null);
            gun.transform.rotation = Quaternion.identity;
            gun.IsEquiped = false;
            gun.rb.AddForce(character.transform.forward * 5f, ForceMode.Impulse);
            gun.character.EquipedWeapon = null;
            Actions.HandleAmmoChanged?.Invoke(null);
        }

    }

    public void Shoot()
    {
        SoundManager.instance.PlaySound("GunFire",character.EquipedWeapon.transform.position);
        var bullet = BulletPool.Instance.GetFromPool();
        bullet.transform.position = projectileSpawn.position;
        BulletsLeft--;
        TotalBullets--;
        Actions.HandleAmmoChanged?.Invoke(this);

        if (BulletsLeft <= 0 && BulletsInMagazine > 0) 
        {
            StartCoroutine("ReloadTime");
        }
        
    }

    protected IEnumerator ReloadTime()
    {
        yield return new WaitForSeconds(1.5f);
         
        int reloadAmmo = MagazineSize - BulletsLeft;
        if(reloadAmmo > BulletsInMagazine)
        {
            reloadAmmo = BulletsInMagazine;
            BulletsLeft += BulletsInMagazine;
        }
        else
        {
            BulletsLeft = MagazineSize;
        }
       BulletsInMagazine -= reloadAmmo;
       Debug.Log(BulletsInMagazine);
        



        Actions.HandleAmmoChanged?.Invoke(this);
    }

    public void InteractWithAmmoBox()
    {
        BulletsInMagazine = MagazineAmmount * MagazineSize;
        BulletsLeft = MagazineSize;
        Actions.HandleAmmoChanged?.Invoke(this);
    }

    public void SetValues(float FireRate, float ShotSpread, int Damage, int MagazineSize, int MagazineAmmount, bool AllowButtonHold)
    {
        this.FireRate = FireRate;
        this.ShotSpread = ShotSpread;
        this.Damage = Damage;
        this.MagazineSize = MagazineSize;
        this.MagazineAmmount = MagazineAmmount;
        this.AllowButtonHold = AllowButtonHold;
    }

    private void ChangeRigidbodyStats(Rigidbody rbToDisable)
    {
        if (rbToDisable.useGravity == false && rbToDisable.detectCollisions == false)
        {
            rbToDisable.useGravity = true;
            rbToDisable.detectCollisions = true;
        }
        else
        {
            rbToDisable.useGravity = false;
            rbToDisable.detectCollisions = false;
        }

    }

}
