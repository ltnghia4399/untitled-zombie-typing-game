using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10f;
    public Vector3 offset;

    private Vector3 currentVelocity;

    private void Update()
    { 
        
        Vector3 newPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(this.transform.position, newPos, smoothSpeed * Time.deltaTime);
        //Vector3 smoothPos = Vector3.SmoothDamp(this.transform.position, newPos, ref currentVelocity, smoothSpeed * Time.deltaTime);

        transform.position = smoothPos;
        

        /*
        if(target.position.z > this.transform.position.z)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, target.position.z - 43f);

            Vector3 smoothPos = Vector3.SmoothDamp(this.transform.position, newPos, ref currentVelocity, smoothSpeed * Time.deltaTime);

            this.transform.position = smoothPos;
        }
        */

        
    }
}
