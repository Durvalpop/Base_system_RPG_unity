using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot_Item : MonoBehaviour
{
    public float vel = 50f;

    private void Update()
    {
        transform.Rotate(Vector3.up * vel * Time.deltaTime);
    }

}
