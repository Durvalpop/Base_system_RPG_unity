using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    //Criando minha lista

    public List<Weapon> inv_weapon;
    public List<Skill> inv_skill;
    public List<Evolutiva> inv_evolutiva;
    public List<Armor> inv_armor;
    public List<Potion> inv_potion;
    public List<Item> inv_other;

    private void Start()
    {
        //add Item test
        //Add_to_inventory(new Weapon("DragonBlue", "Arma padrão do jogador", 16, false, "Items/model1"));
        //Add_to_inventory(new Potion("Heatch_potion", "Arma padrão do jogador", 16, false, "Items/model1"));
       // Add_to_inventory(new Magia("fire ball", "Arma padrão do jogador", 16, false,15, "Items/model1"));
       // Add_to_inventory(new Armor("Destiny", "Arma padrão do jogador", 16, false, "Items/model1"));
        Save_Inventory(); // salvando inventario
        //inv_weapon.Sort();
        //Load_Iventory();// carregando inventario salvo

        //separando_os items em determinado type_icon(weapon,potion, armor, magia)
       
    }
    private void Update()
    {
        //Salvando meu inventario __test
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Save_Inventory();
        }
    }
    #region save_items_inventario

    public void Save_Inventory()
    {
        Inventory_Data inventory_data = new Inventory_Data
        {
            evolutiva_data = inv_evolutiva,
            weapon_data = inv_weapon,
            skill_data = inv_skill,
            potion_data = inv_potion,
            armor_data = inv_armor
        };
        IO.Save<Inventory_Data>(inventory_data, "player_inventory");
        Debug.Log("Inventario Salvo");
    }

    public void Load_Iventory()
    {
        if (IO.File_exist("player_inventory"))
        {
            Inventory_Data id = IO.Load<Inventory_Data>("player_inventory");
            inv_weapon = id.weapon_data;
            inv_evolutiva = id.evolutiva_data;
            inv_armor = id.armor_data;
            inv_potion = id.potion_data;
            inv_other = id.other_data;
            Debug.Log("Inventory esta carregado!");
        }
        else
            Debug.Log("Inventario não carregado, pois não existe o arquivo de salvamento");
    }

    public void Add_to_inventory(Item it)
    {
        if (it is Weapon weapon)
        {
            inv_weapon.Add(weapon);
            inv_weapon.Sort();
        }
        else if (it is Evolutiva evolutiva)
        {
           inv_evolutiva.Add(evolutiva);
           inv_evolutiva.Sort();
        }
        else if (it is Armor armor)
        {
            inv_armor.Add(armor);
            inv_armor.Sort();
        }
        else if (it is Potion potion)
        {
            inv_potion.Add(potion);
            inv_potion.Sort();
        }
        else if (it is Skill skill)
        {
            inv_skill.Add(skill);
            inv_skill.Sort();
        }
        else
        {
            inv_other.Add(it);
            inv_other.Sort();
        }
    }
    #endregion
}
