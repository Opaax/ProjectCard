///-----------------------------------------------------------------
/// Author : Enguerran Cobert
/// Date : 07/04/2020 10:44
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.PackSoor.ProjectCard.ProjectConfidential.Arena {
	
	[CreateAssetMenu(
		menuName = "ProjectCard/ArenaPath",
		fileName = "ArenaSetting",
		order = 1
	)]
	
	public class ArenaPathSetting : ScriptableObject {
        private Vector3 _startPoint = default;
        private Vector3 _endPoint = default;

        public Vector3 StartPoint
        {
            get { return _startPoint; }
            set { _startPoint = value; }
        }
        public Vector3 EndPoint
        {
            get { return _endPoint; }
            set { _endPoint = value; }
        }
    }
}