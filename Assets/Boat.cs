using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boat : MonoBehaviour
{
    public float bobbingMultiplier = .5f;
    public float rollMultiplier = .4f;
    private float originalY;
    private Quaternion startRotation;

    void Start()
    {
        originalY = this.transform.position.y;
        startRotation = transform.rotation;
    }

    void Update()
    {
        BobUpAndDown();
        RollSideToSide();
        RollFrontToBack();
    }

    void BobUpAndDown()
    {
        transform.position = new Vector3(transform.position.x, originalY + ((float)Mathf.Sin(Time.time) * bobbingMultiplier), transform.position.z);
    }

    void RollSideToSide()
    {
        float angle = Mathf.Sin(Time.time * rollMultiplier) * 10f;
        transform.rotation = startRotation * Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void RollFrontToBack()
    {
        float angle = Mathf.Sin(Time.time * rollMultiplier) * 4f;
        transform.rotation = startRotation * Quaternion.AngleAxis(angle, Vector3.back);
    }
}

