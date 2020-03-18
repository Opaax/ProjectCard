///-----------------------------------------------------------------
/// Author : 
/// Date : 24/01/2020 12:49
///-----------------------------------------------------------------

using System.Xml.Serialization;
using System.Xml;
using UnityEngine;

namespace Com.IsartDigital.PlatFormer.Platformer.Localization {
    public class Label {
        [XmlAttribute ("Label")] public string label;
        [XmlElement ("en")] public string en;
        [XmlElement("fr")] public string fr;
	}
}