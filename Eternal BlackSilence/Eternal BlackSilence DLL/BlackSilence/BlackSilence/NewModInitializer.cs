using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using LOR_DiceSystem;
using LOR_XML;
using Mod;
using UI;
using Unity.Mathematics;
using UnityEngine;
using TMPro;


namespace Initializer
{
    public class NewModInitializer : ModInitializer
    {
        
      
        public override void OnInitializeMod()
        {
            


            LoRLocalizationManager.LocalizationUtil.AddOnLocalizeAction(OnLocalize);
        }
        
        public void OnLocalize(string language)
        {
            // this will be called every time language is changed
            // (this includes when localization is first loaded, when the scene is loaded)
            // here you can load additional stuff through your code
            // such as AbnormalityCards
            // or changing base Ruina texts
        }

        public static string packageId;
    }
}
