using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shoot : MonoBehaviour
{
    AudioSource sesKaynagi;
    public AudioClip atesSes;
    public AudioClip reloadSes;
    public int defaultAmmo = 120;
    public int magSize = 30;
    public int currentAmmo;
    public int currentMagAmmo;
    public TextMeshProUGUI ammoDisplay;
    public Camera camera;
    public int range;
    int minAngle = -1;
    int maxAngle = 1;
    [Header("Gun Damage On Hit")]
    public int damage;
    public GameObject bloodPrefab;
    public GameObject decalPrefab;
    public GameObject magObject;
    public ParticleSystem muzzleParticle;
    void Start()
    {
        currentAmmo = defaultAmmo-magSize;
        currentMagAmmo = magSize;
        sesKaynagi=this.gameObject.GetComponent<AudioSource>();
        
    }

    
    void Update()
    {
        ammoDisplay.text= currentMagAmmo.ToString();
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (CanFire())
            {
               Fire();  
            }
            
        }
    }

    private void Reload()
    {
        if (currentAmmo ==0 || currentMagAmmo==magSize)
        {
            return;
        }
        if (currentAmmo < magSize)
        {
            sesKaynagi.PlayOneShot(reloadSes);
            currentMagAmmo = currentMagAmmo + currentAmmo;
            currentMagAmmo = 0;
        }
        else 
        {
            sesKaynagi.PlayOneShot(reloadSes);
            currentAmmo -= magSize - currentMagAmmo;
            currentMagAmmo = magSize;
        }
        GameObject newMagObject = Instantiate(magObject);
        newMagObject.transform.position=magObject.transform.position;
        newMagObject.AddComponent<Rigidbody>();   

    }
    public void ResetAmmo()
    {
        currentAmmo = 120;
    }

    private bool CanFire()
    {
        if (currentMagAmmo > 0)
        {
            return true;
        }
        return false;
    }

    private void Fire()
    {
        muzzleParticle.Emit(1);
        sesKaynagi.PlayOneShot(atesSes);
        currentMagAmmo -= 1;
        
        Debug.Log("Remaining bullet: " + currentMagAmmo);
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position,camera.transform.forward,out hit,75))
        {
            if (hit.transform.tag == "Zombie")
            {
                hit.transform.GetComponent<ZombieHealth>().Hit(damage);
                GenerateBloodEffect(hit);
            }
            else
            {
                GenerateHitEffect(hit);
            }
        }
        transform.localEulerAngles = new Vector3(Random.Range(minAngle, maxAngle), Random.Range(minAngle, maxAngle), Random.Range(minAngle, maxAngle));
        
    }

    private void GenerateHitEffect(RaycastHit hit)
    {
        
        GameObject hitObject = Instantiate(decalPrefab, hit.point, Quaternion.identity);
        hitObject.transform.rotation = Quaternion.FromToRotation(decalPrefab.transform.forward*-1, hit.normal);
    }

    private void GenerateBloodEffect(RaycastHit hit)
    {
        GameObject bloodObject = Instantiate(bloodPrefab, hit.point, hit.transform.rotation);
    }
}
