using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_icon : MonoBehaviour
{
    Image image;

    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }

    public void Change_color(Color col)
    {
        image.color = col;
    }
    
}
