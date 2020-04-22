using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
[CustomEditor(typeof(Characters))]
public class CharacterEditor : Editor
{
    private Characters character = null;
    private CharacterLead lead;

    private void OnSceneGUI()
    {
        character = target as Characters;
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        base.OnInspectorGUI();

        if (!character.Settings)
        {
            EditorGUILayout.HelpBox("You must add settings", MessageType.Warning);
            return;
        }

        #region Stats
        GUILayout.Space(10);
        GUILayout.Label("Stats", TitleStyle(20,Color.white));

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
        #endregion
        #region GraphgicPart
        GUILayout.Space(10);
        GUILayout.Label("GraphicsPart", TitleStyle(20,Color.white));
        EditorGUILayout.Space();

        character.Settings.Model = (GameObject)EditorGUILayout.ObjectField("Model", character.Settings.Model, typeof(GameObject), false);

        if(!character.Settings.Model)
        {
            GUIContent lContent = new GUIContent();
            lContent.text = "The 3D model that the player will drop on field, don't forget to make prefab of it";
            EditorGUILayout.HelpBox(lContent);
        }

        EditorGUILayout.Space();

        character.Settings.MainCardImage = (Image)EditorGUILayout.ObjectField("MainCard", character.Settings.MainCardImage, typeof(Image), false);

        if (!character.Settings.MainCardImage)
        {
            GUIContent lContent = new GUIContent();
            lContent.text = "The main Illustration, this will appear when the player wanted to visualize it";
            EditorGUILayout.HelpBox(lContent);
        }

        EditorGUILayout.Space();

        character.Settings.HudCardImage = (Image)EditorGUILayout.ObjectField("HudCard", character.Settings.HudCardImage, typeof(Image), false);

        if (!character.Settings.HudCardImage)
        {
            GUIContent lContent = new GUIContent();
            lContent.text = "The visualization on HUD in game";
            EditorGUILayout.HelpBox(lContent);
        }

        EditorGUILayout.Space();

        character.Settings.TeamCardImage = (Image)EditorGUILayout.ObjectField("TeamCard", character.Settings.TeamCardImage, typeof(Image), false);

        if (!character.Settings.TeamCardImage)
        {
            GUIContent lContent = new GUIContent();
            lContent.text = "The visualization on Team Screen";
            EditorGUILayout.HelpBox(lContent);
        }
        #endregion
    }

    private GUIStyle TitleStyle(int fontSize, Color fontColor)
    {
        GUIStyle lStyle = new GUIStyle();
        lStyle.fontSize = fontSize;
        lStyle.normal.textColor = fontColor;
        lStyle.fontStyle = FontStyle.Bold;

        return lStyle;
    }
}
#endif