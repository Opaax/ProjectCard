///-----------------------------------------------------------------
/// Author : 
/// Date : 24/01/2020 12:43
///-----------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace Com.IsartDigital.PlatFormer.Platformer.Localization {
	public class LocalizationManager  {
        private string pathLoc;

        private Dictionary<string, string[]> _localizationDico = new Dictionary<string, string[]>();

        public LocalizationManager(string path)
        {
            pathLoc = path;
        }

        public void Init()
        {
            SetDico();
        }

        private void SetDico ()
        {
            LocalizationContainer lAllLoc = LocalizationContainer.Load(pathLoc);

            foreach (Label localization in lAllLoc.allLabels)
            {
                string[] Llanguages = new string[] { localization.en, localization.fr };
                _localizationDico.Add(localization.label, Llanguages);
            }
        }

        public string GetText (string label, int indexLanguage)
        {
            return _localizationDico[label][indexLanguage];
        }
    }
}