///-----------------------------------------------------------------
/// Author : Enguerran Cobert
/// Date : 20/03/2020 18:17
///-----------------------------------------------------------------

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Com.PackSoor.ProjectCard.ProjectConfidential.UI.ScreenScripts {
    public delegate void TitlePlayClickedEventHandler();
	public class TitleScreen : AbstractScreen {
        #region Singleton
        private static TitleScreen instance;
		public static TitleScreen Instance { get { return instance; } }
        #endregion
        #region EventDelagate
        public static event ScreenAddScreenButtonEventHandler TitleToTeam;
        public static event TitlePlayClickedEventHandler TitlePlayClicked;
        #endregion

        [Header("Buttons")]
        [SerializeField] private Button buttonMainMenu = null;
        [SerializeField] private Button buttonTeam = null;
        [SerializeField] private Button buttonSummons = null;
        [SerializeField] private Button buttonMenu = null;
        [SerializeField] private Button buttonPlay = null;

        private void Awake(){
			if (instance){
				Destroy(gameObject);
				return;
			}
			
			instance = this;
		}

        public override void Open()
        {
            base.Open();
            AddListenerButton();
        }

        public override void Close()
        {
            base.Close();
            RemoveListenerButton();
        }

        #region MethodesListner
        private void AddListenerButton()
        {
            buttonMainMenu.onClick.AddListener(OnClickedMainMenu);
            buttonTeam.onClick.AddListener(OnClickedTeam);
            buttonSummons.onClick.AddListener(OnClickedSummons);
            buttonMenu.onClick.AddListener(OnClickedMenu);
            buttonPlay.onClick.AddListener(OnClickedPlay);
        }

        private void RemoveListenerButton()
        {
            buttonMainMenu.onClick.RemoveListener(OnClickedMainMenu);
            buttonTeam.onClick.RemoveListener(OnClickedTeam);
            buttonSummons.onClick.RemoveListener(OnClickedSummons);
            buttonMenu.onClick.RemoveListener(OnClickedMenu);
            buttonPlay.onClick.RemoveListener(OnClickedPlay);
        }
        #endregion
        #region MethodesClicked
        private void OnClickedPlay()
        {
            Debug.Log("Play");
            TitlePlayClicked?.Invoke();
        }

        private void OnClickedMainMenu()
        {
            Debug.Log("MainsMenu");
        }

        private void OnClickedSummons()
        {
            Debug.Log("Summons");
        }

        private void OnClickedTeam()
        {
            Debug.Log("Teams");
            TitleToTeam?.Invoke(TeamScreen.Instance);
        }

        private void OnClickedMenu()
        {
            Debug.Log("Menu");
        }
        #endregion

        private void OnDestroy(){
			if (this == instance) instance = null;
		}
	}
}