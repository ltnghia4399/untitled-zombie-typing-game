using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator chilAnim;

    [HideInInspector]
    public bool isHit = false;

    public int health = 5;

    public List<Collider> colList;

    Rigidbody rb;


    private void Awake()
    {
        chilAnim = GetComponentInChildren<Animator>();

        rb = GetComponent<Rigidbody>();

        RagdollSetUp();
    }

    void Update()
    {
        if (isHit)
        {
            int rand = Random.Range(0, 2);

            switch (rand)
            {
                case 0:
                    chilAnim.SetTrigger("Hit01");
                    isHit = false;
                    break;
                case 1:
                    chilAnim.SetTrigger("Hit02");
                    isHit = false;
                    break;
                default:
                    break;
            }


        }
        else
        {
            chilAnim.ResetTrigger("Hit01");
            chilAnim.ResetTrigger("Hit02");
        }

        if (health <= 0)
        {
            //gameObject.SetActive(false);
            DoRagdoll();
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            DoRagdoll();
        }

    }

    public int TakeDmg(int _dmgToTake)
    {
        health -= _dmgToTake;
        return health;
    }

    void RagdollSetUp()
    {
        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>(true);

        /*
        for (int i = 1; i < colliders.Length; i++)
        {
            colliders[i].isTrigger = true;
            colliders[i].useGravity = false;
            colliders[i].attachedRigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            colliders[i].attachedRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            colList.Add(colliders[i]);
        }
        */

        foreach (Collider col in colliders)
        {
            if (col.gameObject != this.gameObject)
            {
                col.isTrigger = true;
                col.attachedRigidbody.useGravity = false;
                col.attachedRigidbody.interpolation = RigidbodyInterpolation.Interpolate;
                col.attachedRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
                colList.Add(col);
            }
        }

    }

    void DoRagdoll()
    {
        BoxCollider mainCol = this.gameObject.GetComponent<BoxCollider>();
        mainCol.enabled = false;
        rb.useGravity = false;
        chilAnim.enabled = false;
        rb.velocity = Vector3.zero;

        rb.constraints = RigidbodyConstraints.None;

        foreach (Collider col in colList)
        {
            col.isTrigger = false;
            col.attachedRigidbody.useGravity = true;
            //col.attachedRigidbody.velocity = Vector3.zero;
            
        }
    }

}
