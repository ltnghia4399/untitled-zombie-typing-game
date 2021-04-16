using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using My_UtilityScript;
public class Bullet02 : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    //public ParticleSystem bloodFx;

    public Light impactLight;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    public float explosionLightIntensity;

    void Explode()
    {
        DOVirtual.Float(0, explosionLightIntensity, .05f, ChangeLight).OnComplete(() => DOVirtual.Float(explosionLightIntensity, 0, .1f, ChangeLight));
    }

    void ChangeLight(float x)
    {
        impactLight.intensity = x;
    }


    private void Update()
    {
        if(target == null)
        {
            gameObject.SetActive(false);
            return;
        }

        Vector3 dir = target.position - transform.position;

        float distancePerFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distancePerFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);
    }

    void HitTarget()
    {
        
        ObjectPooling.instance.GetObjectFromPool("Blood", this.transform.position, Quaternion.identity);
        AudioManager.instance.PlayRandomSounds("Hit");
        
        Explode();
        gameObject.SetActive(false);
    }
}
