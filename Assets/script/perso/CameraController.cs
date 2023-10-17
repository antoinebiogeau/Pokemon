using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public float turnSpeed = 4.0f;
    public Transform player;
    private Vector3 offset = new Vector3(7f, 7f, -10f);

    void Start()
    {
        //		offset = new Vector3 (0f, 5f, -10f);
    }

    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }


}