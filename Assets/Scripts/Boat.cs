using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boat : MonoBehaviour
{
    public float bobbingMultiplier = .1f;
    public float rollMultiplier = .4f;
    public float angleX = 2f;
    public float angleZ = 2f;

    private float originalY;
    private Quaternion startRotation;

    void Start()
    {
        originalY = transform.position.y;
        startRotation = transform.rotation;
    }

    void Update()
    {
        BobUpAndDown();
        Roll();
    }

    void BobUpAndDown()
    {
        transform.position = new Vector3(transform.position.x, originalY + ((float)Mathf.Sin(Time.time) * bobbingMultiplier), transform.position.z);
    }

    void Roll()
    {
        float angle1 = Mathf.Sin(Time.time * rollMultiplier) * angleX;
        float angle2 = Mathf.Sin(Time.time * rollMultiplier) * angleZ;
        transform.rotation = startRotation * Quaternion.AngleAxis(angle1, Vector3.left) * Quaternion.AngleAxis(angle2, Vector3.forward);
    }
}

