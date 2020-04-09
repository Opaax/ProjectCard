using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(Characters))]
public class CharacterEditor : Editor
{
    private Characters character = null;

    private void OnSceneGUI()
    {
        character = target as Characters;
    }

    private CharacterLead lead;

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        base.OnInspectorGUI();

        if (!character.Settings)
        {
            EditorGUILayout.HelpBox("You must add settings", MessageType.Warning);
            return;
        }

        EditorGUILayout.Space();
        character.Settings.CardType = (CharacterType)EditorGUILayout.EnumPopup("Type of Card", character.Settings.CardType);
        EditorGUILayout.Space();
        character.Settings.CardRarety = (CharacterRarety)EditorGUILayout.EnumPopup("Rarety of Card", character.Settings.CardRarety);
        EditorGUILayout.Space();
        character.Settings.CardLead = (CharacterLead)EditorGUILayout.EnumPopup("Lead of Card", character.Settings.CardLead);
        EditorGUILayout.Space();

        if (character.Settings.CardLead == CharacterLead.ATT)
        {
            character.Settings.LeadAtt = EditorGUILayout.IntField("Attack Lead as %", character.Settings.LeadAtt);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Attack by " + character.Settings.LeadAtt.ToString() + " %";
            EditorGUILayout.HelpBox(lContent);
        }
        else if(character.Settings.CardLead == CharacterLead.PV)
        {
            character.Settings.LeadPv = EditorGUILayout.IntField("Pv Lead as %", character.Settings.LeadPv);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Pv by " + character.Settings.LeadPv.ToString() + " %";
            EditorGUILayout.HelpBox(lContent);
        }
        else if (character.Settings.CardLead == CharacterLead.DEF)
        {
            character.Settings.LeadDef = EditorGUILayout.IntField("Def Lead as %", character.Settings.LeadDef);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Def by " + character.Settings.LeadDef.ToString() + " %";
            EditorGUILayout.HelpBox(lContent);
        }
        else if (character.Settings.CardLead == CharacterLead.ATTDEF)
        {
            character.Settings.LeadAtt = EditorGUILayout.IntField("Attack Lead as %", character.Settings.LeadAtt);
            character.Settings.LeadDef = EditorGUILayout.IntField("Def Lead as %", character.Settings.LeadDef);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Attack by " + character.Settings.LeadAtt.ToString() + " % & his Def by" + character.Settings.LeadDef.ToString() + " %";
            EditorGUILayout.HelpBox(lContent);
        }
        else if (character.Settings.CardLead == CharacterLead.PVDEF)
        {
            character.Settings.LeadPv = EditorGUILayout.IntField("Pv Lead as %", character.Settings.LeadPv);
            character.Settings.LeadDef = EditorGUILayout.IntField("Def Lead as %", character.Settings.LeadDef);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Pv by " + character.Settings.LeadPv.ToString() + " % & his Def by" + character.Settings.LeadDef.ToString() + " %";
            EditorGUILayout.HelpBox(lContent);
        }
        else if (character.Settings.CardLead == CharacterLead.PVATT)
        {
            character.Settings.LeadAtt = EditorGUILayout.IntField("Attack Lead as %", character.Settings.LeadAtt);
            character.Settings.LeadPv = EditorGUILayout.IntField("Pv Lead as %", character.Settings.LeadPv);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Pv by " + character.Settings.LeadPv.ToString() + " % & his Attack by" + character.Settings.LeadAtt.ToString() + " %";
            EditorGUILayout.HelpBox(lContent);
        }
        else if (character.Settings.CardLead == CharacterLead.ATTDEFPV)
        {
            character.Settings.LeadAtt = EditorGUILayout.IntField("Attack Lead as %", character.Settings.LeadAtt);
            character.Settings.LeadDef = EditorGUILayout.IntField("Def Lead as %", character.Settings.LeadDef);
            character.Settings.LeadPv = EditorGUILayout.IntField("Pv Lead as %", character.Settings.LeadPv);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Attack by " + character.Settings.LeadAtt.ToString() + " % , his Def by" + character.Settings.LeadDef.ToString() + " % & his Pv by " + character.Settings.LeadPv.ToString() +" %";
            EditorGUILayout.HelpBox(lContent);
        }

        EditorGUILayout.Space();

        character.Settings.Attack = EditorGUILayout.IntField("Attack", character.Settings.Attack);
        character.Settings.Defense = EditorGUILayout.IntField("Defense", character.Settings.Defense);
        character.Settings.Pv = EditorGUILayout.IntField("Pv", character.Settings.Pv);

        EditorGUILayout.Space();

        character.Settings.Model = (GameObject)EditorGUILayout.ObjectField("Model", character.Settings.Model, typeof(GameObject), false);
        if (EditorGUI.EndChangeCheck())
        {
            ///character.basedStats.Clear();
            //character.basedStats = new Dictionary<string, uint>
            //{
            //    {"att", (uint)character.Attack},
            //    {"def", (uint)character.Defense},
            //    {"pv", (uint)character.Pv}
            //};
        }
    }
}
#endif