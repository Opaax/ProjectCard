///-----------------------------------------------------------------
/// Author : Enguerran Cobert
/// Date : 27/03/2020 18:30
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.PackSoor.ProjectCard.ProjectConfidential.Character {
	
	[CreateAssetMenu(
		menuName = "ProjectCard/Character",
		fileName = "Character",
		order = 0
	)]
	
	public class ScriptableCharacter : ScriptableObject {
        #region Specs
        [Header("Specs")]
        [SerializeField,HideInInspector] private CharacterType _type;
        [SerializeField,HideInInspector] private CharacterRarety _rarety;
        [SerializeField,HideInInspector] private CharacterLead _lead;
        #endregion
        #region Lead
        [SerializeReference, HideInInspector] private int _leadAtt = 0;
        [SerializeReference, HideInInspector] private int _leadDef = 0;
        [SerializeReference, HideInInspector] private int _leadPv = 0;

        public int LeadAtt
        {
            get { return _leadAtt; }
            set { _leadAtt = value; }
        }

        public int LeadDef
        {
            get { return _leadDef; }
            set { _leadDef = value; }
        }

        public int LeadPv
        {
            get { return _leadPv; }
            set { _leadPv = value; }
        }
        #endregion
        #region Stats
        [Header("Stats")]
        [SerializeField, HideInInspector] private int _attack = 0;
        [SerializeField, HideInInspector] private int _defense = 0;
        [SerializeField, HideInInspector] private int _pv = 0;

        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }

        public int Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }

        public int Pv
        {
            get { return _pv; }
            set { _pv = value; }
        }
        #endregion

        #region GetterSetters
        public CharacterType CardType
        {
            get { return _type; }
            set { _type = value; }
        }

        public CharacterRarety CardRarety
        {
            get { return _rarety; }
            set { _rarety = value; }
        }

        public CharacterLead CardLead
        {
            get { return _lead; }
            set { _lead = value; }
        }
        #endregion
    }
}