///-----------------------------------------------------------------
/// Author : 
/// Date : 24/01/2020 14:56
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.IsartDigital.PlatFormer.Platformer.Localization {
    public static class LocalizationLabelSetting {
        private static string _labelTitle = "Title";
        private static string _labelPlay = "Play";
        private static string _labelBack = "Back";
        private static string _labelOption = "Option";
        private static string _labelLeaderBoard = "LeaderBoard";
        private static string _labelLevel = "Level";
        private static string _labelTime = "Time";
        private static string _labelPause = "Pause";
        private static string _labelBackToTitle = "BackToTitle";
        private static string _labelCollect = "Collect";
        private static string _labelLanguages ="Languages";
        private static string _labelLanguage = "Language";
        private static string _labelVolume = "Volume";
        private static string _labelSetting = "Settings";

        static public string LabelTitle => _labelTitle;
        static public string LabelBack => _labelBack;
        static public string LabelPlay => _labelPlay;
        static public string LabelOption => _labelOption;
        static public string LabelLeaderBoard => _labelLeaderBoard;
        static public string LabelLevel => _labelLevel;
        static public string LabelTime => _labelTime;
        static public string LabelPause => _labelPause;
        static public string LabelBackToTitle => _labelBackToTitle;
        static public string LabelCollect => _labelCollect;
        /// <summary>
        /// Language return "Language"
        /// </summary>
        static public string LabelLanguage => _labelLanguage;
        /// <summary>
        /// Languages return une langue
        /// </summary>
        static public string LabelLanguages => _labelLanguages;
        static public string LabelVolume => _labelVolume;
        static public string LabelSetting => _labelSetting;
	}
}