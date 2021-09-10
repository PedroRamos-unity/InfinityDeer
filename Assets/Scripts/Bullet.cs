using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;

    private Camera cam;

    private float lifeTime = 5f;
    private float time;

    private float x, y;
    private Character character;
    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody>();
        character = FindObjectOfType<Character>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time >= lifeTime)
        {
            BulletPool.Instance.AddToPool(gameObject);
            time = 0f;
        }
    }

    private void OnEnable()
    {
        transform.SetParent(null);
        if (character.EquipedWeapon != null)
        {
            x = Random.Range(-character.EquipedWeapon.weapon.ShotSpread, character.EquipedWeapon.weapon.ShotSpread);
            y = Random.Range(-character.EquipedWeapon.weapon.ShotSpread, character.EquipedWeapon.weapon.ShotSpread);
        }
        Vector3 dir = cam.transform.forward;

        rb.AddForce(dir * 30, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Enemy>() != null)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(character.EquipedWeapon.weapon.Damage);
        }
        BulletPool.Instance.AddToPool(gameObject);

    }
}
