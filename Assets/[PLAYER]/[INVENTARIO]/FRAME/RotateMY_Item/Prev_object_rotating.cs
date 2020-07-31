using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Prev_object_rotating : MonoBehaviour
{
    public bool currently_rotating;
    public float time_prev;

    private void Update()
    {
        if (currently_rotating)
        {
            //rotação em si via mause()
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y")*5, Input.GetAxis("Mouse X")*8,0));

            if (Input.GetKeyDown(KeyCode.Mouse0) && time_prev > 0.5f)
                currently_rotating = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currently_rotating = false;
        }
    }
    public void Start_rotating()
    {
        if (currently_rotating)
        {
            currently_rotating = true;
            time_prev = 0;
        }
    }

}
