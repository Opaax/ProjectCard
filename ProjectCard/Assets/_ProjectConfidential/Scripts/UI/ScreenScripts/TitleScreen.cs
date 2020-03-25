///-----------------------------------------------------------------
/// Author : Enguerran Cobert
/// Date : 20/03/2020 18:17
///-----------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace Com.PackSoor.ProjectCard.ProjectConfidential.UI.ScreenScripts {
	public class TitleScreen : AbstractScreen {
        #region Singleton
        private static TitleScreen instance;
		public static TitleScreen Instance { get { return instance; } }
        #endregion

        [Header("Buttons")]
        [SerializeField] private Button buttonMainMenu = null;
        [SerializeField] private Button buttonTeam = null;
        [SerializeField] private Button buttonSummons = null;
        [SerializeField] private Button buttonMenu = null;

        private void Awake(){
			if (instance){
				Destroy(gameObject);
				return;
			}
			
			instance = this;
		}
        
		
		private void OnDestroy(){
			if (this == instance) instance = null;
		}
	}
}