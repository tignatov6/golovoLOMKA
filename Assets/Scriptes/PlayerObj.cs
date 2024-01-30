using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : MonoBehaviour
{
    public Transform Camera;
    public Transform PlayerObject;
    void Update()
    {
        PlayerObject.transform.rotation = new Quaternion(0, Camera.transform.rotation.y, 0, Camera.rotation.w);

    }
}
