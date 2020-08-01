using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Inventory_menu : MonoBehaviour
{
    [System.Serializable]
    public class Stats_field
    {
        public Text nome, weapon_t, weapon_p,
                          armor_t, armor_p,
                          potion_t, potion_p,
                          skill_t, skill_p, skill_mana_usada,
                          evolutiva_t, evolutiva_p;
        public void Disable_specyfic_props()
        {
            skill_mana_usada.gameObject.SetActive(false);
            evolutiva_t.gameObject.SetActive(false);
            evolutiva_p.gameObject.SetActive(false);
            skill_t.gameObject.SetActive(false);
            skill_p.gameObject.SetActive(false);
            weapon_t.gameObject.SetActive(false);
            weapon_p.gameObject.SetActive(false);
            armor_t.gameObject.SetActive(false);
            armor_p.gameObject.SetActive(false);
            potion_t.gameObject.SetActive(false);
            potion_p.gameObject.SetActive(false);
        }
        public void Disable_basic_props()
        {
            nome.gameObject.SetActive(false);
        }
        public void Show_basic_props(Item it)
        {
            nome.gameObject.SetActive(true);
            nome.text = it.nome;
        }
        public void Show_specyfic_props(Item it)
        {
            if (it is Weapon weapon)
            {
                weapon_t.gameObject.SetActive(true);
                weapon_t.text = "One handed sword";
                weapon_p.gameObject.SetActive(true);
                Weapon w = weapon;
                weapon_p.text = "Dano" + w.dano_Weapon.ToString();
            }
            if (it is Evolutiva evolutiva)
            {
                Evolutiva e = evolutiva;
                evolutiva_t.gameObject.SetActive(true);
                evolutiva_t.text = "One handed sword";
                evolutiva_p.gameObject.SetActive(true);            
                evolutiva_p.text = "Qtd Item: " + e.qtd_item.ToString();
            }
            else if (it is Skill skill)
            {
                Skill s = skill;
                skill_mana_usada.gameObject.SetActive(true);
                skill_mana_usada.text = "Mana Usada: " + s.usoMana.ToString();
                skill_t.gameObject.SetActive(true);
                skill_t.text = "Skill";
                skill_p.gameObject.SetActive(true);
                skill_p.text = "Dano" + s.danoSkill.ToString();
            }
            else if (it is Armor a)
            {
                armor_t.gameObject.SetActive(true);
                armor_t.text = "heavy armor";
                armor_p.gameObject.SetActive(true);
                armor_p.text = "Acrescentando" + a.defesaValue.ToString();
            }
            else if (it is Potion p)
            {
                potion_t.gameObject.SetActive(true);
                potion_t.text = "POTION VIDA";
                potion_p.gameObject.SetActive(true);
                potion_p.text = "Restaurando " + p.Qtd_Liquid_Value + " de vida";
            }
        }
    }

    
    public int active_frame;
    public Transform prev_item_transform;
    public Stats_field stats_field;
    [HideInInspector]
    public List<Item_Frame> item_frames;
    public GameObject item_frame, prev_item;
    int rect_size;
    public Color icon_active, icon_not_active;
    public enum Icon_filter { all, weapon, evolutiva, skill, armor, potion, other};
    public Icon_filter icon_filter;
    public Inventory_icon[] icons;

    GameObject tmp;
    RectTransform item_frame_rt, tmp_rt, rect_trans;
    Item_Frame tmp_if;
    Player_Inventory pi;


    protected void Awake()
    {
        pi = GameObject.Find("Game_Manager").GetComponent<Player_Inventory>();
        item_frame_rt = item_frame.GetComponent<RectTransform>();
        rect_trans = gameObject.GetComponent<RectTransform>();
    }

    protected void Start()
    {
        Action_icon(0);
        Disable_icons();
        
    }

    private void Update_inventory() {

        rect_trans.sizeDelta = Vector2.zero;
        rect_trans.anchoredPosition = Vector2.zero;
        active_frame = -1;

        while(item_frames.Count != 0)
        {
            GameObject go = item_frames[0].gameObject;
            item_frames.RemoveAt(0);
            GameObject.Destroy(go);
        }

        rect_size = 0;
        item_frame.SetActive(true);
        /*cod_anterior_para o inventario(novo codigo esta pelo draw_item(pelo addToItem0
        for (int i = 0; i < pi.inventory.Count; ++i)
        {
            tmp = GameObject.Instantiate(item_frame);
            tmp.transform.SetParent(gameObject.transform);
            tmp_rt = tmp.GetComponent<RectTransform>();
            tmp_rt.localScale = item_frame_rt.localScale;
            tmp_rt.anchoredPosition = item_frame_rt.anchoredPosition;
            //tmp_rt.anchoredPosition += new Vector2(0, (item_frame_rt.rect.height + 1.5f) * -i);
            tmp_if = tmp.GetComponent<Item_Frame>();
            tmp_if.nome = pi.inventory[i].nome;
            tmp_if.Set_Values();
            
        }
        NOVO MODO ABAIXO_LIST_for
         */
        if (icon_filter == Icon_filter.all || icon_filter == Icon_filter.weapon)
            for (int i = 0; i < pi.inv_weapon.Count; ++i)
                Draw_item(pi.inv_weapon[i]);
        if (icon_filter == Icon_filter.all || icon_filter == Icon_filter.armor)
            for (int i = 0; i < pi.inv_armor.Count; ++i)
                Draw_item(pi.inv_armor[i]);
        if (icon_filter == Icon_filter.all || icon_filter == Icon_filter.skill)
            for (int i = 0; i < pi.inv_skill.Count; ++i)
                Draw_item(pi.inv_skill[i]);
        if (icon_filter == Icon_filter.all || icon_filter == Icon_filter.potion)
            for (int i = 0; i < pi.inv_potion.Count; ++i)
                Draw_item(pi.inv_potion[i]);
        if (icon_filter == Icon_filter.all || icon_filter == Icon_filter.evolutiva)
            for (int i = 0; i < pi.inv_evolutiva.Count; ++i)
                Draw_item(pi.inv_evolutiva[i]);
        if (icon_filter == Icon_filter.all || icon_filter == Icon_filter.other)
            for (int i = 0; i < pi.inv_other.Count; ++i)
                Draw_item(pi.inv_other[i]);

        item_frame.SetActive(false);
       
        rect_trans.sizeDelta = new Vector2(0, Mathf.Max((item_frame_rt.rect.height + 1.5f) * rect_size, 0));
        rect_trans.anchoredPosition += new Vector2(0, -Mathf.Max((item_frame_rt.rect.height + 1.5f) * rect_size / 2, 670/2));

        if (active_frame == -1)
        {
            stats_field.Disable_basic_props();
            stats_field.Disable_specyfic_props();
        }        
    }

    void Draw_item(Item it) {
        tmp = GameObject.Instantiate(item_frame);
        tmp.transform.SetParent(gameObject.transform);
        tmp_rt = tmp.GetComponent<RectTransform>();
        tmp_rt.localScale = item_frame_rt.localScale;
        tmp_rt.anchoredPosition = item_frame_rt.anchoredPosition;
        tmp_rt.anchoredPosition += new Vector2(0, (item_frame_rt.rect.height + 1.5f) * -rect_size);
        tmp_if = tmp.GetComponent<Item_Frame>();
        item_frames.Add(tmp_if);


        //abaixo_pegando_obj_do_item_e_pondo_na_camRawImage
        tmp_if.index = item_frames.Count;
        tmp_if.Set_Values(it);

        if (item_frames.Count == 1)
        {
            tmp_if.Activate_frame();
            rect_size++;
        } 

    }

    public void Disable_icons()
    {
        foreach(Inventory_icon ic in icons)
        {
            ic.Change_color(icon_not_active);
        }
    }
    public void Action_icon(int icon_id)
    {
        icons[icon_id].Change_color(icon_active);

        //lista tipo icon
        switch (icon_id)
        {
            case 0:
                icon_filter = Icon_filter.all;
                break;
            case 1:
                icon_filter = Icon_filter.weapon;
                break;
            case 2:
                icon_filter = Icon_filter.armor;
                break;
            case 3:
                icon_filter = Icon_filter.potion;
                break;
            case 4:
                icon_filter = Icon_filter.skill;
                break;
            case 5:
                icon_filter = Icon_filter.evolutiva;
                break;
            case 6:
                icon_filter = Icon_filter.other;
                break;
            default:
                break;
        }
        Update_inventory();
    }
    //preview_new_item_posição visor cam 2
    public void Preview_new_item (string model_locale_dir)
    {
        Destroy(prev_item);
        prev_item = GameObject.Instantiate(Resources.Load(model_locale_dir)) as GameObject;
        prev_item.transform.SetParent(prev_item_transform);
        prev_item.transform.position = prev_item_transform.position;//set posição do item para a posição dp transform visor 3d
        prev_item.GetComponent<Rigidbody>().useGravity = false;
    }
}
