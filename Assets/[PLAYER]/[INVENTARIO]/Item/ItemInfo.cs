using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class ItemInfo : MonoBehaviour
{
    public Sprite sprite_icon;
    public static ItemInfo instance;
    public enum Item_type {weapon, armor, evolutiva, potion, skill, other}
    [Header("Item_Config")]
    public Item_type item_type;
    public Item item_info;

    [Header("Player_Inventario")]
    private Player_Inventory Player_inventory;

    //[Header("Atributos_Adicionais_nao_existente_no_item_base")]
    //weapon_atributo_add
    public bool isIsquipped;
    public int danoValueWeapon;
    public int item_qtd;
    public int danoValueMagia;
    //armor_atributo_add
    public int defesa_value;
    //potion_atributo_add
    public int liquid_value;
    public bool isIstackable;
    //magia_atributo_add
    public int usoMana;

    private void Awake()
    {
        instance = this;
        //Linkando este codigo ao Player_Inventory dentro do Game_Manager para atualizar o inventario
        Player_inventory = GameObject.Find("Game_Manager").GetComponent<Player_Inventory>();
    }

    private void Start()
    {
        #region Set_info_item_type

        switch (item_type)
        {
            case Item_type.weapon:
                item_info = new Weapon(item_info.img_icon_item, item_info.img_icon_item_active, sprite_icon, item_info.sprite_icon_active, item_info.nome, item_info.descricao, danoValueWeapon, isIsquipped, item_info.model_locale_dir);
                break;
            case Item_type.evolutiva:
                item_info = new Evolutiva(item_info.img_icon_item, item_info.img_icon_item_active, sprite_icon, item_info.sprite_icon_active, item_info.nome, item_info.descricao, item_qtd, usoMana, item_info.model_locale_dir);
                break;
            case Item_type.skill:
                item_info = new Skill(item_info.img_icon_item, item_info.img_icon_item_active, sprite_icon, item_info.sprite_icon_active, item_info.nome, item_info.descricao, danoValueMagia, isIsquipped, usoMana,item_info.model_locale_dir);
                break;
            case Item_type.potion:
                item_info = new Potion(item_info.img_icon_item, item_info.img_icon_item_active, sprite_icon, item_info.sprite_icon_active,  item_info.nome, item_info.descricao, liquid_value, isIstackable, item_info.model_locale_dir);
                break;
            case Item_type.armor:
                item_info = new Armor(item_info.img_icon_item, item_info.img_icon_item_active, sprite_icon, item_info.sprite_icon_active, item_info.nome, item_info.descricao, defesa_value, isIsquipped, item_info.model_locale_dir);
                break;
            default:
                break;

        }

        #endregion
        item_info.model_locale_dir = "PrefabList/" + item_type +"/"+ gameObject.name;
    }

    private void OnMouseDown() //esse codigo adiciona o item no inventario em si
    {
        Player_inventory.Add_to_inventory(item_info);// <-- Add no triger da mão do player
        Destroy(gameObject);
    }
}
