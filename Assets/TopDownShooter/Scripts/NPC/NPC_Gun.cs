using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;

public class NPC_Gun : MonoBehaviour
{
	public NPC npc;
	public Animator anim;
	public bool Pistol;
	public bool Rifle;
	public bool Flamethrower;
    public float weaponCheckRadius;

	[Header("Stats")]
    public Transform muzzle;
    public Transform gunMuzzle;
    public float fireRate;
    public float Damage;
    public float range;
    public int currentAmmo;
    public int maxAmmo;
    public float reloadTime;
    public bool isReloading;
    public float Recoil;

    [Header("VFX")]
    public ParticleSystem muzzleFlash;
    public ParticleSystem FlameVFX;
    public GameObject sparkEffect;
    public GameObject wallEffect;
    public GameObject bloodEffect;
    public GameObject vehicleEffect;
    public GameObject OBJEffect;
    public TrailRenderer BulletTrail;

    [Header("AudioClips")]
    public AudioClip fireSFX;
    public AudioClip reloadSFX;
    public AudioClip[] bloodHitSFX;
    public AudioClip[] metalHitSFX;
    public AudioClip[] wallHitSFX;

    [Header("UI")]
    public Image weaponImage;
    public Sprite weaponSprite;

    float nextTimeToFire = 0f;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        //anim = GetComponent<Animator>();

        currentAmmo = maxAmmo;

        if(!Flamethrower)
        {
            weaponCheckRadius = 5f;
        }else
        {
            weaponCheckRadius = 5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
    	if(npc.dead)return;

        npc.weaponCheckRadius = weaponCheckRadius;

        if(!npc.civil)
    	weaponImage.sprite = weaponSprite;

        if(Pistol)
        {
            anim.SetLayerWeight(anim.GetLayerIndex("Rifle"), 0);
            anim.SetLayerWeight(anim.GetLayerIndex("Melee"), 0);
            anim.SetLayerWeight(anim.GetLayerIndex("Pistol"), 1);
        }

        if(Rifle)
        {
            anim.SetLayerWeight(anim.GetLayerIndex("Rifle"), 1);
            anim.SetLayerWeight(anim.GetLayerIndex("Melee"), 0);
            anim.SetLayerWeight(anim.GetLayerIndex("Pistol"), 0);
        }

        npc.melee = false;
        npc.gun = true;

        //Reloading
        if (currentAmmo <= 0 && !isReloading)
        {
            StartCoroutine(reload());
        }

        if(npc.canFire && Time.time >= nextTimeToFire && !isReloading && currentAmmo > 0)
        {
            if (!Flamethrower)
                Fire();
            else
                Flame();

            nextTimeToFire = Time.time + 1f / fireRate;
        }
        else if (Flamethrower)
        {
            FlameVFX.Stop();
        }
    }

    void Fire()
    {
        Vector3 shootDirection = muzzle.forward;
        shootDirection.x += Random.Range(Recoil, -Recoil);
        shootDirection.y += Random.Range(Recoil, -Recoil);

        currentAmmo--;
        muzzleFlash.Play();
        audio.PlayOneShot(fireSFX);
        anim.SetTrigger("Fire");

        RaycastHit hit;
        if (Physics.Raycast(muzzle.position, shootDirection, out hit, range))
        {
            //Trail
            if (hit.transform.tag == "Metal")
            {
                GameObject hitEffect = Instantiate(sparkEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 2f);
                audio.PlayOneShot(metalHitSFX[Random.Range(0, metalHitSFX.Length)]);
            }

            if (hit.transform.tag == "Shop")
            {
                GameObject hitEffect = Instantiate(sparkEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 2f);
                audio.PlayOneShot(metalHitSFX[Random.Range(0, metalHitSFX.Length)]);
            }

            if (hit.transform.tag == "Wall")
            {
                GameObject hitEffect = Instantiate(wallEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 2f);
                audio.PlayOneShot(wallHitSFX[Random.Range(0, wallHitSFX.Length)]);
            }

            if (hit.transform.tag == "Vehicle")
            {
                GameObject hitEffect = Instantiate(vehicleEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 2f);
                audio.PlayOneShot(metalHitSFX[Random.Range(0, metalHitSFX.Length)]);
            }

            Zombie_BP zom = hit.transform.GetComponentInChildren<Zombie_BP>();
            if (zom != null)
            {
                zom.TakeDamage(Damage);

                GameObject hitEffect = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 2f);
                audio.PlayOneShot(bloodHitSFX[Random.Range(0, bloodHitSFX.Length)]);
            }

            CarController veh = hit.transform.GetComponent<CarController>();
            if (veh != null)
            {
                veh.TakeDamage(Damage);

                GameObject hitEffect = Instantiate(vehicleEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 2f);
                audio.PlayOneShot(metalHitSFX[Random.Range(0, metalHitSFX.Length)]);
            }

            HelicopterController hel = hit.transform.GetComponent<HelicopterController>();
            if (hel != null)
            {
                hel.TakeDamage(Damage);

                GameObject hitEffect = Instantiate(vehicleEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 2f);
                audio.PlayOneShot(metalHitSFX[Random.Range(0, metalHitSFX.Length)]);
            }

            BodyParts targetBoss = hit.transform.GetComponentInChildren<BodyParts>();
            if (targetBoss != null)
            {
                targetBoss.TakeDamage(Damage);

                GameObject hitEffect = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 2f);
                audio.PlayOneShot(bloodHitSFX[Random.Range(0, bloodHitSFX.Length)]);
            }

            OBJ obj = hit.transform.GetComponent<OBJ>();
            if (obj != null)
            {
                obj.TakeDamage(Damage);

                GameObject hitEffect = Instantiate(OBJEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 2f);
                audio.PlayOneShot(wallHitSFX[Random.Range(0, wallHitSFX.Length)]);
            }

            Bandit_BP bp = hit.transform.GetComponentInChildren<Bandit_BP>();
            if (bp != null)
            {
                bp.TakeDamage(Damage);

                GameObject hitEffect = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 2f);
                audio.PlayOneShot(bloodHitSFX[Random.Range(0, bloodHitSFX.Length)]);
            }

            TrailRenderer trail = Instantiate(BulletTrail, gunMuzzle.position, gunMuzzle.rotation);

            StartCoroutine(SpawnTrail(trail, hit));
        }
    }

    void Flame()
    {
        currentAmmo--;
        FlameVFX.Play();
        audio.PlayOneShot(fireSFX);
        //anim.SetTrigger("Fire");

        anim.SetTrigger("Fire");

        RaycastHit hit;
        if (Physics.Raycast(muzzle.position, muzzle.forward, out hit, range))
        {
            //Trail
            // if(hit.transform.tag == "Metal")
            //   {
            //     GameObject hitEffect = Instantiate(sparkEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //     Destroy(hitEffect, 2f);
            //     audio.PlayOneShot(metalHitSFX[Random.Range(0, metalHitSFX.Length)]);
            //   }

            //   if(hit.transform.tag == "Wall")
            //   {
            //     GameObject hitEffect = Instantiate(wallEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //     Destroy(hitEffect, 2f);
            //     audio.PlayOneShot(wallHitSFX[Random.Range(0, wallHitSFX.Length)]);
            //   }

            Zombie_BP target = hit.transform.GetComponentInChildren<Zombie_BP>();
            if (target != null)
            {
                Debug.Log("Hit");
                target.Burn(Damage);
            }

            Bandit_BP bandit = hit.transform.GetComponentInChildren<Bandit_BP>();
            if (bandit != null)
            {
                Debug.Log("Hit");
                bandit.Burn(Damage);
            }

            CarController veh = hit.transform.GetComponent<CarController>();
            if (veh != null)
            {
                veh.TakeDamage(Damage);
            }

            BodyParts targetBoss = hit.transform.GetComponentInChildren<BodyParts>();
            if (targetBoss != null)
            {
                targetBoss.TakeDamage(Damage);

                GameObject hitEffect = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 2f);
                audio.PlayOneShot(bloodHitSFX[Random.Range(0, bloodHitSFX.Length)]);
            }
        }
    }

    IEnumerator reload()
    {
        isReloading = true;
        anim.SetBool("Reload", true);

        audio.PlayOneShot(reloadSFX);

        yield return new WaitForSeconds(reloadTime);

        anim.SetBool("Reload", false);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 StartPosition = Trail.transform.position;

        while (time < 0.1f)
        {
            Trail.transform.position = Vector3.Lerp(StartPosition, hit.point, time);
            time += Time.deltaTime / Trail.time;

            yield return null;
        }
        Trail.transform.position = hit.point;

        Destroy(Trail.gameObject, Trail.time);
    }
}
