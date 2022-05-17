using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public float currentTime;
    public float timeOut;
    public Vector3 position;
    public float angle;
    
    private void Start()
    {
        //Application.targetFrameRate = 1;
    }

    void Update()
    {
        UpdateSmoothRandomRotationAndMoveForward();
        //  UpdateRotateWithLerp();
        //UpdateMoveAndRotateRandomly();
    }

    private void UpdateSmoothRandomRotationAndMoveForward()
    {
        if(currentTime > timeOut)
        {
            currentTime = 0f;
            target.Rotate(0, Random.Range(0,360f), 0);
        }
        else
        {
            currentTime += Time.deltaTime;
        }
        angle = Quaternion.Angle(target.rotation, player.transform.rotation);
        player.transform.Rotate(0, angle * Time.deltaTime, 0);
        player.transform.Translate(Vector3.forward * Time.deltaTime * 5 );
    }

    private void UpdateMoveAndRotateRandomly()
    {
        if(currentTime > timeOut)
        {
            currentTime = 0f;
            target.position = new Vector3(Random.Range(0,5f), Random.Range(0,5f), Random.Range(0,5f));
            target.Rotate(0, Random.Range(0,360f), 0);
        }
        else
        {
            currentTime += Time.deltaTime;
        }
        position = target.position - player.transform.position;
        angle = Quaternion.Angle(target.rotation, player.transform.rotation);
        player.transform.Translate(position * Time.deltaTime);
        player.transform.Rotate(0, angle * Time.deltaTime, 0);
    }
    
    void UpdateRotateWithLerp()
    {
        if(currentTime > timeOut)
        {
            currentTime = 0f;
            target.Rotate(0, Random.Range(0,360f), 0);
        }
        else
        {
            currentTime += Time.deltaTime;
        }
        angle = Quaternion.Angle(target.rotation, player.transform.rotation);
        player.transform.Rotate(0, Mathf.Lerp(player.transform.rotation.y, angle, Time.deltaTime), 0);
    }
}
