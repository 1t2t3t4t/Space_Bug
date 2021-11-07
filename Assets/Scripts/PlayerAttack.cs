using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject BulletPrefab;
    public ParticleSystem GunFlash;

    [SerializeField]
    private Weapon CurrentWeapon;
    
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var aimDir = _camera.transform.forward;
        if (Input.GetMouseButtonDown(0))
        {
            Fire(aimDir);
        }
        Debug.DrawRay(GunFlash.transform.position, aimDir, Color.red);
    }

    private void Fire(Vector3 aimDir)
    {
        var bullet = Instantiate(BulletPrefab);
        bullet.transform.position = GunFlash.transform.position;
        bullet.transform.rotation = Quaternion.LookRotation(aimDir);
        bullet.GetComponent<Rigidbody>().velocity = aimDir.normalized * CurrentWeapon.BulletSpeed;
        Destroy(bullet, 10);
        GunFlash.Play();
    }
}
