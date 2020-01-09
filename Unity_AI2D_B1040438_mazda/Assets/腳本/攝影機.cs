using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 攝影機 : MonoBehaviour
{
    public float camspeed = 12;

    public Transform target;

    private void LateUpdate()
    {
        Vector3 cam = transform.position;
        Vector3 tar = target.position;
        tar.z = -10;
        tar.y = Mathf.Clamp(tar.y, -0.1f, 1);
        transform.position = Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * camspeed);
    }

}
