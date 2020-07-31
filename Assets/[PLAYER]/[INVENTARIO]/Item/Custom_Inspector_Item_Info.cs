using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ItemInfo))]
[CanEditMultipleObjects]
public class Custom_Inspector_Item_Info : Editor
{
    ItemInfo item_info;
    SerializedProperty item_nome, item_descricao, item_type, 
        dano_Weapon,
        dano_Skill, uso_Mana,
        qtd_item,
        is_Equipped, defesa_value,
        is_istackable, Qtd_Liquid_Value;
    //controle do tipo do item_info( separando se for, arma, ou magia, ou armor, ou potion

    private void OnEnable()
    {
        item_info = (ItemInfo)target;
        qtd_item = serializedObject.FindProperty("item_qtd");
        item_nome = serializedObject.FindProperty("item_info.nome");
        item_descricao = serializedObject.FindProperty("item_info.descricao");
        item_type = serializedObject.FindProperty("item_type");
        dano_Weapon = serializedObject.FindProperty("danoValueWeapon");
        is_istackable = serializedObject.FindProperty("isIstackable");
        dano_Skill = serializedObject.FindProperty("danoValueMagia");
        uso_Mana = serializedObject.FindProperty("usoMana");
        is_Equipped = serializedObject.FindProperty("isIsquipped");
        defesa_value = serializedObject.FindProperty("defesa_value");
        Qtd_Liquid_Value = serializedObject.FindProperty("liquid_value");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //Base_de todo e quaisquer tipo de item
        EditorGUILayout.PropertyField(item_nome);
        EditorGUILayout.PropertyField(item_descricao);
        EditorGUILayout.PropertyField(item_type);

        //add novosAtributos_á_diferentes_tipos_de_enum(weapon, potion,armor,magia)
        switch (item_info.item_type)
        {
            case ItemInfo.Item_type.weapon:
                EditorGUILayout.PropertyField(is_Equipped);
                EditorGUILayout.PropertyField(dano_Weapon);
                break;
            case ItemInfo.Item_type.evolutiva:
                EditorGUILayout.PropertyField(qtd_item);
                break;
            case ItemInfo.Item_type.skill:
                EditorGUILayout.PropertyField(dano_Skill);
                EditorGUILayout.PropertyField(uso_Mana);
                break;
            case ItemInfo.Item_type.armor:
                EditorGUILayout.PropertyField(is_Equipped);
                EditorGUILayout.PropertyField(defesa_value); 
                break;
            case ItemInfo.Item_type.potion:
                EditorGUILayout.PropertyField(Qtd_Liquid_Value);
                EditorGUILayout.PropertyField(is_istackable);
                break;
            case ItemInfo.Item_type.other:
                EditorGUILayout.PropertyField(dano_Weapon);
                EditorGUILayout.PropertyField(dano_Skill);
                EditorGUILayout.PropertyField(uso_Mana);
                break;
            default:
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
