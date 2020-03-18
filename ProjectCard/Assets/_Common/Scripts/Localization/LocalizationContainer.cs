///-----------------------------------------------------------------
/// Author : 
/// Date : 24/01/2020 13:37
///-----------------------------------------------------------------

using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace Com.IsartDigital.PlatFormer.Platformer.Localization {
    [XmlRoot("Localization")]
    public class LocalizationContainer {
        [XmlArray("AllLabels")]
        [XmlArrayItem("Label")]
        public List<Label> allLabels = new List<Label>();

        public static LocalizationContainer Load(string path)
        {
            TextAsset lXml = Resources.Load<TextAsset>(path);
            XmlSerializer serializer = new XmlSerializer(typeof(LocalizationContainer));
            StringReader reader = new StringReader(lXml.text);
            LocalizationContainer lAllLoc = serializer.Deserialize(reader) as LocalizationContainer;

            reader.Close();

            return lAllLoc;
        }
    }
}