///-----------------------------------------------------------------
/// Author : Enguerran Cobert
/// Date : 26/03/2020 19:30
///-----------------------------------------------------------------

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Com.PackSoor.ProjectCard.ProjectConfidential.UI.ScreenScripts {
	public class TeamScreen : AbstractScreen {
        #region Singleton
        private static TeamScreen instance;
		public static TeamScreen Instance { get { return instance; } }
        #endregion
        #region EventsDelegate
        public static event ScreenBackButtonEventHandler Back;
        #endregion

        [SerializeField] private Button buttonBack = null;
        [SerializeField] private Button buttonDeck = null;
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

        #region MethodesListener
        private void AddListenerButton()
        {
            buttonBack.onClick.AddListener(OnClickedButtonBack);
            buttonDeck.onClick.AddListener(OnClickedButtonDeck);
        }

        private void RemoveListenerButton()
        {
            buttonBack.onClick.RemoveListener(OnClickedButtonBack);
            buttonDeck.onClick.RemoveListener(OnClickedButtonDeck);
        }

        #endregion
        #region ClickedMethodes
        private void OnClickedButtonBack()
        {
            Debug.Log("Back");
            Back?.Invoke(TitleScreen.Instance);
        }

        private void OnClickedButtonDeck()
        {
            Debug.Log("Deck");
        }
        #endregion

        private void OnDestroy(){
			if (this == instance) instance = null;
		}
	}
}