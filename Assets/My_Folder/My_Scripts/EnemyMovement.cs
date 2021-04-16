using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My_UtilityScript;
public class EnemyMovement : MonoBehaviour
{
    public float minMoveSpeed = 1f, maxMoveSpeed = 3f;

    private float speed;

    //public Transform target;

    //Rigidbody rb;

    bool isDead = false;

    public Animator anim;

    bool reachEndPoint = false;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    private void Update()
    {
        if (reachEndPoint)
            return;
        

        if (this.gameObject.activeInHierarchy)
        {
            if (WordSpawner.instance.GetCurrentState() == WordSpawner.SpawnState.COUNTING)
            {
                this.gameObject.SetActive(false);
            }
        }


        if(this.transform.position.z < 0.9f)
        {
            End();
        }
    }

    void End()
    {
        reachEndPoint = true;
        GameManager.instance.EndGame();
    }

    public void Die()
    {
        isDead = true;
        anim.enabled = false;
        AudioManager.instance.PlayWithRandomPitch("ZombieDeath");
    }

    public void Live()
    {
        isDead = false;
        anim.enabled = true;
        speed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    private void FixedUpdate()
    {
        //if(target != null)
        //{
        //    this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, speed * Time.fixedDeltaTime);
        //}
        if (!isDead)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,this.transform.position.z - speed * Time.deltaTime);
        }

        //rb.AddForce(Vector3.back * moveSpeed * Time.fixedDeltaTime, ForceMode.Force);
    }

}
