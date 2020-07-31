using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Frame : MonoBehaviour
{
    public int index;
    public Item item;
    public Text nome_txt;
    Inventory_menu im;

    private void Awake()
    {
        im = GameObject.Find("Frame_Item_Content").GetComponent<Inventory_menu>();
    }

    public void Set_Values(Item it)
    {
        item = it;
        nome_txt.text = item.nome;
    }
 
    public void Activate_frame()
    {
        if(im.active_frame != index)
        {
            im.active_frame = index;
            im.Preview_new_item(item.model_locale_dir);
            im.stats_field.Disable_specyfic_props();
            im.stats_field.Show_specyfic_props(item);
            im.stats_field.Show_basic_props(item);
        }
    }
}
