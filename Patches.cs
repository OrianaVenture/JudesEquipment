using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace JudesEquipment
{
    [HarmonyPatch]
    static class Patches
    {

        [HarmonyPatch(typeof(ObjectDB), nameof(ObjectDB.CopyOtherDB))]
        [HarmonyPostfix]
        static void CopyOtherDb_patch(ObjectDB __instance, ObjectDB other)
        {
            ItemManager.AddItemsToODB(__instance);
            __instance.StartCoroutine(RecipeManager.DelayedRecipeInsertion());
        }

        [HarmonyPatch(typeof(ObjectDB), nameof(ObjectDB.Awake))]
        [HarmonyPostfix]
        static void DbAwake_patch(ObjectDB __instance)
        {
            ItemManager.AddItemsToODB(__instance);
            __instance.StartCoroutine(RecipeManager.DelayedRecipeInsertion());

        }

        //loading localization at fejd startup now, should solve all conflicts with people calling localization instance too early
        /*[HarmonyPatch(typeof(Localization), nameof(Localization.SetupLanguage))]
        [HarmonyPostfix]
        static void SetupLanguage_patch(string language, ref Dictionary<string, string> ___m_translations, List<string> ___m_languages)
        {
            LocalizationManager.LoadConfigs(___m_languages);
            LocalizationManager.InsertLocalization(language, ref ___m_translations);

            Main.log.LogWarning("trying to load locaization");
        }*/

        [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.SetupGui))]
        [HarmonyPostfix]
        static void FejdSetupGui_patch()
        {
            LocalizationManager.localizationInstance = Localization.instance;
            LocalizationManager.InsertLocalization();
        }

        /*[HarmonyPatch(typeof(VisEquipment), nameof(VisEquipment.AttachItem))]
        [HarmonyPostfix]
        static void SetEarsSkinColor(VisEquipment __instance, ref GameObject __result, int itemHash)
        {
            if(itemHash == "HeadElf".GetStableHashCode())
            {
                UnityEngine.Debug.LogWarning("equipped ears");
                GameObject ears = __result.transform.Find("ElfSkin").gameObject;
                ears.GetComponent<MeshRenderer>().material = __instance.m_bodyModel.material;
            }
        }*/

        /*[HarmonyPatch(typeof(GameCamera), nameof(GameCamera.GetCameraPosition))]
        [HarmonyPostfix]
        static void ScrenShotMode_patch(ref Vector3 pos)
        {
            pos.y -= 1;
        }*/
    }
}
