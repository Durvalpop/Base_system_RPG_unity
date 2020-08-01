using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Item_Frame : MonoBehaviour
{

    public Image imgItem, imgActive;
    public Sprite sprite_active_icon, null_icon;
    public int index;
    public Item item;
    Inventory_menu im;

    private void Awake()
    {
        im = GameObject.Find("Frame_Item_Content").GetComponent<Inventory_menu>();
    }


    public void Set_Values(Item it)
    {
        item = it;
        //Set__RawImage____________________________________________________________________
        item.img_icon_item = imgItem;//passando o meu rawimage atual ao item()
        item.img_icon_item_active = imgActive;//passando o meu rawimage atual ao itemActive()
        //Set_sprite
        item.sprite_icon_active= sprite_active_icon;
        //setando nos locais
        imgItem.sprite = item.sprite_icon;
        imgActive.sprite = item.sprite_icon_active;
      
    }
    public void Activate_frame()
    {
        if (im.active_frame != index)
        {
            im.active_frame = index;
            im.Preview_new_item(item.model_locale_dir);
            im.stats_field.Disable_specyfic_props();
            im.stats_field.Show_specyfic_props(item);
            im.stats_field.Show_basic_props(item);


            
            //Set__Sprite_TO_Image_____________________________________________________________________
            item.img_icon_item_active.GetComponent<Image>().sprite = item.sprite_icon_active;

        }

    }

    public void EnterPointer()
    {
        item.img_icon_item_active.GetComponent<Image>().sprite = item.sprite_icon_active;
    }
    public void ExitPointer()
    {

        item.img_icon_item_active.GetComponent<Image>().sprite = null_icon;
    }
}

