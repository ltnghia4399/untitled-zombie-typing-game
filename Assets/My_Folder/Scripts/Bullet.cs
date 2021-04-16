using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(5, 100)]
    public int destroyAfter;
    public bool destroyOnImpact = false;
    public float minDestroyTime = 0.01f;
    public float maxDestroyTime = 0.05f;

    [Header("Impact Effect Prefabs")]
    public ObjectPooler bloodSplatFx;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        //Start Destroy After x Amount of Time()
        StartCoroutine(DestroyAfter(destroyAfter));
    }

    void SpawnBloodFx(ObjectPooler _bloodFx, Transform _spawnPos, Quaternion _rotation)
    {
        GameObject bloodFx = _bloodFx.GetPooledObject();
        bloodFx.transform.position = _spawnPos.position;
        bloodFx.transform.rotation = _rotation;
        bloodFx.SetActive(true);
    }

    void DeactiveBullet(Rigidbody _rb, GameObject _obj)
    {
        _rb.velocity = Vector3.zero;
        _obj.SetActive(false);
    }

  
    private void OnCollisionEnter(Collision collision)
    {
        
        if (!destroyOnImpact)
        {
            //setTime to Destroy Timer()
            StartCoroutine(DestroyTimer(minDestroyTime, maxDestroyTime));
        }
        else
        {
            DeactiveBullet(rb, gameObject);
        }

        if (collision.transform.tag == "Enemy")
        {
            SpawnBloodFx(bloodSplatFx, collision.collider.transform, Quaternion.LookRotation(collision.GetContact(0).normal));

            EnemyController enemy = collision.collider.gameObject.GetComponent<EnemyController>();

            enemy.isHit = true;
            enemy.TakeDmg(1);
            DeactiveBullet(rb, gameObject);
        }

    }

    IEnumerator DestroyAfter(float _destroyAfter)
    {
        yield return new WaitForSeconds(_destroyAfter);
        DeactiveBullet(rb, gameObject);
    }

    IEnumerator DestroyTimer(float _minTime, float _maxTime)
    {
        yield return new WaitForSeconds(Random.Range(_minTime,_maxTime));
        DeactiveBullet(rb, gameObject);
    }
   
}
