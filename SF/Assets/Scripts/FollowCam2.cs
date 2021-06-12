using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam2 : MonoBehaviour
{
    public Transform Player; // 따라다닐 타겟 오브젝트의 Transform
    private Transform Camera; // 카메라 자신의 Transform

    void Start()
    {
        Camera = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        // Camera.position = new Vector3(Player.position.x, Camera.position.y, Player.position.z - 6.56f);
        Camera.position = new Vector3(Player.position.x, Camera.position.y, Player.position.z - 9f);

        Camera.LookAt(Player);
    }
}