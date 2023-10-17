using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    public float Life = 100f;
    public float sensitivity = 3;
    private Rigidbody rb;
    public float rotSpeed = 4.0f;
    public Camera cam;
    private Vector3 moveDirection;
    private Vector3 tempTarget;
    public float jumpVelocity = 7;
    private float distToGround = 0.6f;
    public float maxSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 5f;
        rb.useGravity = true;
        rb.drag = 0.1f;
    }
    

    void FixedUpdate()
    {
        updateRotation();
        moveCharacter();
    }



    private void updateRotation()
    {

        Quaternion rotation = cam.transform.rotation;
        rotation.x = 0;
        rotation.z = 0;
        rotation *= Quaternion.Euler(0, 90, 0);

        transform.rotation = rotation;
    }


    private void moveCharacter()
    {

        tempTarget = Input.GetAxis("Vertical") * cam.transform.forward + Input.GetAxis("Horizontal") * cam.transform.right;
        tempTarget.y = 0f;

        if (tempTarget.magnitude == 0)
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                tempTarget *= 1.5f;
            }
            else
            {
            }
            rb.velocity = new Vector3(tempTarget.x * 10, rb.velocity.y, tempTarget.z * 10);
        }

    }
    public float gethealth()
    {
        return Life;
    }
    public void takeDammage(float Dammage)
    {
        if(Life >= 0)
        {
            Life -= Dammage;

        }
        else
        {
            dieP();
        }
    }
    public void dieP()
    {
        Life = 100f;
    }


}
