using System;
using System.Collections;
using HarmonyLib;
using UnityEngine;

namespace JudesEquipment
{
    [HarmonyPatch]
    static class Patches
    {
        public static IEnumerator DelayedRecipeInsertion()
        {
            yield return null;

            Main.modConfig.ApplyRecipeConfigs();
        }

        [HarmonyPatch(typeof(ObjectDB), nameof(ObjectDB.CopyOtherDB))]
        [HarmonyPostfix]
        static void CopyOtherDb_patch(ObjectDB __instance, ObjectDB other)
        {
            Main.creatureShader = __instance.m_items?.Find(_item => _item.name == "ArmorIronChest")?.GetComponentInChildren<SkinnedMeshRenderer>(true)?.material?.shader;

            ItemManager.AddItemsToODB(__instance);
            Main.modConfig.ApplyArmorConfigs();
            __instance.StartCoroutine(DelayedRecipeInsertion());
        }

        [HarmonyPatch(typeof(ObjectDB), nameof(ObjectDB.Awake))]
        [HarmonyPostfix]
        static void DbAwake_patch(ObjectDB __instance)
        {
            ItemManager.AddItemsToODB(__instance);
            Main.modConfig.ApplyArmorConfigs();
            __instance.StartCoroutine(DelayedRecipeInsertion());
            Main.modConfig.ApplySetEffects();
        }

        [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.SetupGui))]
        [HarmonyPostfix]
        static void FejdSetupGui_patch()
        {
            Main.LoadModConfig();
            LocalizationManager.localizationInstance = Localization.instance;
            LocalizationManager.LoadLocalization();
            LocalizationManager.InsertLocalization();
        }

        //screenshot patches
        /*[HarmonyPatch(typeof(CharacterAnimEvent), nameof(CharacterAnimEvent.UpdateHeadRotation))]
        [HarmonyPrefix]
        static bool brush()
        {
            return false;
        }

        [HarmonyPatch(typeof(GameCamera), nameof(GameCamera.GetCameraPosition))]
        [HarmonyPostfix]
        static void ScrenShotMode_patch(ref Vector3 pos)
        {
            pos.y -= 1;
        }*/
    }
}
