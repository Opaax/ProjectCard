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

        EditorGUILayout.Space();
        if(character.CardLead == CharacterLead.ATT)
        {
            character.LeadAtt = EditorGUILayout.IntField("Attack Lead as %", character.LeadAtt);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Attack by " + character.LeadAtt.ToString() + " %";
            EditorGUILayout.HelpBox(lContent);
        }
        else if(character.CardLead == CharacterLead.PV)
        {
            character.LeadPv = EditorGUILayout.IntField("Pv Lead as %", character.LeadPv);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Pv by " + character.LeadPv.ToString() + " %";
            EditorGUILayout.HelpBox(lContent);
        }
        else if (character.CardLead == CharacterLead.DEF)
        {
            character.LeadDef = EditorGUILayout.IntField("Def Lead as %", character.LeadDef);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Def by " + character.LeadDef.ToString() + " %";
            EditorGUILayout.HelpBox(lContent);
        }
        else if (character.CardLead == CharacterLead.ATTDEF)
        {
            character.LeadAtt = EditorGUILayout.IntField("Attack Lead as %", character.LeadAtt);
            character.LeadDef = EditorGUILayout.IntField("Def Lead as %", character.LeadDef);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Attack by " + character.LeadAtt.ToString() + " % & his Def by" + character.LeadDef.ToString() + " %";
            EditorGUILayout.HelpBox(lContent);
        }
        else if (character.CardLead == CharacterLead.PVDEF)
        {
            character.LeadPv = EditorGUILayout.IntField("Pv Lead as %", character.LeadPv);
            character.LeadDef = EditorGUILayout.IntField("Def Lead as %", character.LeadDef);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Pv by " + character.LeadPv.ToString() + " % & his Def by" + character.LeadDef.ToString() + " %";
            EditorGUILayout.HelpBox(lContent);
        }
        else if (character.CardLead == CharacterLead.PVATT)
        {
            character.LeadAtt = EditorGUILayout.IntField("Attack Lead as %", character.LeadAtt);
            character.LeadPv = EditorGUILayout.IntField("Pv Lead as %", character.LeadPv);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Pv by " + character.LeadPv.ToString() + " % & his Attack by" + character.LeadAtt.ToString() + " %";
            EditorGUILayout.HelpBox(lContent);
        }
        else if (character.CardLead == CharacterLead.ATTDEFPV)
        {
            character.LeadAtt = EditorGUILayout.IntField("Attack Lead as %", character.LeadAtt);
            character.LeadDef = EditorGUILayout.IntField("Def Lead as %", character.LeadDef);
            character.LeadPv = EditorGUILayout.IntField("Pv Lead as %", character.LeadPv);
            GUIContent lContent = new GUIContent();
            lContent.text = "Every character on deck up his Attack by " + character.LeadAtt.ToString() + " % , his Def by" + character.LeadDef.ToString() + " % & his Pv by " + character.LeadPv.ToString() +" %";
            EditorGUILayout.HelpBox(lContent);
        }

        EditorGUILayout.Space();

        character.Attack = EditorGUILayout.IntField("Attack", character.Attack);
        character.Defense = EditorGUILayout.IntField("Defense", character.Defense);
        character.Pv = EditorGUILayout.IntField("Pv", character.Pv);

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