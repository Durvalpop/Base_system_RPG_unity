using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class INV_Classes
{ 
}

#region Item_Classes
//--------------------------------- ITEM PRINCIPAL ------------------------------//
[System.Serializable]
public class Item : IComparable<Item> //Informações_padrão do meu item
{
    public Image img_icon_item, img_icon_item_active;
    public Sprite sprite_icon, sprite_icon_active;
    public string nome, descricao;  //nome(nome), descricao(descrição_do_item) 
    public string model_locale_dir; //localização meu modeloOBJ_3D
     
    public Item(Image c_image_icon, Image c_icon_active, Sprite c_sprite_icon, Sprite c_sprite_active_icon, string c_nome, string c_descricao,string c_model_path)
    {
        sprite_icon = c_sprite_icon;
        sprite_icon_active = c_sprite_active_icon;
        img_icon_item = c_image_icon;
        img_icon_item_active = c_icon_active;
        nome = c_nome;
        descricao = c_descricao;
        model_locale_dir = c_model_path;
    }

    public int CompareTo(Item other)
    {
        return string.Compare(nome, other.nome); // a < ab < b
    }
}

//--------------------------------- WEAPON -------------------------------------//
[System.Serializable]
public class Weapon : Item , IComparable<Weapon>
{
    public int dano_Weapon;          //Dano da arma
    public bool isEquipped = false;

    public Weapon(Image c_image_icon, Image c_image_icon_active, Sprite c_sprite_icon, Sprite c_sprite_active_icon, string c_nome, string c_descricao, int c_danoWeapon, bool c_isEquipped, string c_model_locale_dir) : base (c_image_icon, c_image_icon_active, c_sprite_icon, c_sprite_active_icon, c_nome, c_descricao, c_model_locale_dir)
    {
        /*nome        = c_nome;
        descricao   = c_descricao;*/
        dano_Weapon   = c_danoWeapon;
        isEquipped  = c_isEquipped;
        //model_locale_dir = c_model_locale_dir;
    }
    public int CompareTo(Weapon other)
    {
        if (dano_Weapon == other.dano_Weapon)
            return string.Compare(nome, other.nome); // a < ab < b
        return -(dano_Weapon - other.dano_Weapon);
    }
}

//--------------------------------- Evolutiva --------------------------------------//
[System.Serializable]
public class Evolutiva : Item, IComparable<Evolutiva>
{        
    public float usoMana;     //Quanto de mana irá ser usada na minha magia
    public int qtd_item;

    public Evolutiva(Image c_image_icon, Image c_image_icon_active, Sprite c_sprite_icon, Sprite c_sprite_active_icon, string c_nome, string c_descricao, int c_qtd_item, float c_usoMana, string c_model_locale_dir) : base(c_image_icon, c_image_icon_active, c_sprite_icon, c_sprite_active_icon, c_nome, c_descricao, c_model_locale_dir)
    {
        /*nome       = c_nome;
        descricao  = c_descricao;*/
        qtd_item = c_qtd_item;
        usoMana    = c_usoMana;
        /*model_locale_dir = c_model_locale_dir;*/
    }

    public int CompareTo(Evolutiva other)
    {
        if (qtd_item == other.qtd_item)
            return string.Compare(nome, other.nome); // a < ab < b
        return -(qtd_item - other.qtd_item);
    }
}

//--------------------------------- Skill --------------------------------------//
[System.Serializable]
public class Skill : Item, IComparable<Skill>
{
    public int danoSkill;          //Dano da magia
    public float usoMana;     //Quanto de mana irá ser usada na minha magia
    public bool isEquipped = false;

    public Skill(Image c_image_icon, Image c_icon_active, Sprite c_sprite_icon, Sprite c_sprite_active_icon, string c_nome, string c_descricao, int c_dano_skill, bool c_isEquipped, float c_usoMana, string c_model_locale_dir) : base(c_image_icon, c_icon_active, c_sprite_icon, c_sprite_active_icon, c_nome, c_descricao, c_model_locale_dir)
    {
        /*nome       = c_nome;
        descricao  = c_descricao;*/
        danoSkill = c_dano_skill;
        isEquipped = c_isEquipped;
        usoMana = c_usoMana;
        /*model_locale_dir = c_model_locale_dir;*/
    }

    public int CompareTo(Skill other)
    {
        if (danoSkill == other.danoSkill)
            return string.Compare(nome, other.nome); // a < ab < b
        return -(danoSkill - other.danoSkill);
    }
}
//--------------------------------- ARMOR -------------------------------------//
[System.Serializable]
public class Armor : Item , IComparable<Armor>
{
    public bool isEquipped = false;
    public int defesaValue;
     
    public Armor(Image c_image_icon, Image c_active_icon, Sprite c_sprite_icon, Sprite c_sprite_active_icon, string c_nome, string c_descricao, int c_defesaValue, bool c_isEquipped, string c_model_locale_dir) : base(c_image_icon, c_active_icon, c_sprite_icon, c_sprite_active_icon, c_nome, c_descricao, c_model_locale_dir)
    {
       /* nome        = c_nome;
        descricao   = c_descricao;*/
        defesaValue = c_defesaValue;
        isEquipped  = c_isEquipped;
        //model_locale_dir = c_model_locale_dir;
    }

    public int CompareTo(Armor other)
    {
        if (defesaValue == other.defesaValue)
            return string.Compare(nome, other.nome); // a < ab < b
        return -(defesaValue - other.defesaValue);
    }
}

//--------------------------------- WEAPON -------------------------------------//
[System.Serializable]
public class Potion : Item, IComparable<Potion>
{
    public bool isStackable = false;              //esta sendo usado
    public int Qtd_Liquid_Value;          //valor quantidade de liquido

    public Potion(Image c_image_icon, Image c_active_icon, Sprite c_sprite_icon, Sprite c_sprite_active_icon, string c_nome, string c_descricao, int c_qtdLiquidValue, bool c_isStackable, string c_model_locale_dir) : base(c_image_icon, c_active_icon, c_sprite_icon, c_sprite_active_icon, c_nome, c_descricao, c_model_locale_dir)
    {
       /* nome             = c_nome;
        descricao        = c_descricao;*/
        Qtd_Liquid_Value = c_qtdLiquidValue;
        isStackable      = c_isStackable;
        //model_locale_dir = c_model_locale_dir;
    }

    public int CompareTo(Potion other)
    {
        if (Qtd_Liquid_Value == other.Qtd_Liquid_Value)
            return string.Compare(nome, other.nome); // a < ab < b
        return -(Qtd_Liquid_Value - other.Qtd_Liquid_Value);
    }
}
#endregion

#region Save_Items_do_Inventario
[System.Serializable]
public class Inventory_Data
{
    public List<Evolutiva> evolutiva_data;
    public List<Weapon> weapon_data;
    public List<Skill> skill_data;
    public List<Armor> armor_data;
    public List<Potion> potion_data;
    public List<Item> other_data;
}
#endregion
