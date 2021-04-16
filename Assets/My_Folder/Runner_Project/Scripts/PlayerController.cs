using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My_UtilityScript;
public class PlayerController : MonoBehaviour
{
    public Animator anim;


    [Header("Spawn Bullet Gun Shot Smoke with Obj Pool")]
    public Light muzzleFlashLight;
    public ObjectPooler bulletPool;
    public Transform firePoint;

    [Header("Spawn Bullet Trail with Obj Pool")]

    public ParticleSystem bulletParticle;
    public ParticleSystem muzzleFlashParticle;
    public ParticleSystem bulletShellParticle;

    public static bool isFire = false;
    public static bool endWave = false;

    float searchCountDown;
    Transform zombiePos;

    Quaternion startRot;

    private void Start()
    {
        startRot = this.transform.rotation;
    }


    void Update()
    {

        if (!PlayerGunPrep.isPrep)
        {
            if (isFire)
            {
                anim.SetTrigger("isFire");

                //bulletParticle.Play();
                muzzleFlashParticle.Play();
                bulletShellParticle.Play();

                SpawnBullet(bulletPool,firePoint);
                AudioManager.instance.PlayWithoutRandomPitch("Shoot");
                StartCoroutine(SpawnMuzzleFlash(muzzleFlashLight, 0.02f));

                isFire = false;
            }
            else
            {
                anim.ResetTrigger("isFire");

                //bulletParticle.Stop();
                muzzleFlashParticle.Stop();
                bulletShellParticle.Stop();
            }

            this.transform.LookAt(GetTargetPosition());

            if (endWave)
            {
                this.transform.rotation = startRot;
            }
            else
            {
                return;
            }

        }
    }

    Transform GetTargetPosition()
    {
        searchCountDown -= Time.deltaTime;

        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("ZombieHit") != null)
            {
                zombiePos = GameObject.FindGameObjectWithTag("ZombieHit").GetComponent<Transform>();
            }
            else
            {
                return null;
            }
            
        }

        return zombiePos;
    }


    //void SpawnBulletFx(ObjectPooler _bulletFxPooler, Transform _spawnPos)
    //{
    //    GameObject bulletObj = _bulletFxPooler.GetPooledObject();
    //    bulletObj.transform.position = _spawnPos.position;
    //    bulletObj.transform.rotation = _spawnPos.rotation;
    //    bulletObj.SetActive(true);
    //}


    void SpawnBullet(ObjectPooler _bulletTrailPooler, Transform _spawnPos)
    {
        
        GameObject trail = _bulletTrailPooler.GetPooledObject();
        trail.transform.position = _spawnPos.position;
        trail.transform.rotation = _spawnPos.rotation;
        trail.SetActive(true);

        Bullet02 bullet = trail.GetComponent<Bullet02>();

        if (bullet != null)
        {
            bullet.Seek(WordManager.instance.target);
        }
        else
        {
            Debug.Log("Cant find Bullet02 scripts");
        }
    }

    IEnumerator SpawnMuzzleFlash(Light _muzzleFlashLight,float _flashTime)
    {
        _muzzleFlashLight.enabled = true;
        yield return new WaitForSeconds(_flashTime);
        _muzzleFlashLight.enabled = false;
    }

}
