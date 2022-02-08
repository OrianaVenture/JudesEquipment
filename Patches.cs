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

            ItemManager.AddItemsToDBs(__instance);
        }

        [HarmonyPatch(typeof(ObjectDB), nameof(ObjectDB.Awake))]
        [HarmonyPostfix]
        static void DbAwake_patch(ObjectDB __instance)
        {
            Main.creatureShader = __instance.m_items?.Find(_item => _item.name == "ArmorIronChest")?.GetComponentInChildren<SkinnedMeshRenderer>(true)?.material?.shader;

            if (Main.bsmithAvailable)
            {
                Main.CreateBlacksmithsTooslConfigs();
                ItemManager.InsertBsmithToolsCfgs();
            }

            ItemManager.AddItemsToDBs(__instance);
            Main.LoadModConfig();
            LocalizationManager.LoadLocalization();
            LocalizationManager.InsertLocalization();
        }

        [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.Start))]
        [HarmonyPostfix]
        static void FejdSetupGui_patch()
        {
            LocalizationManager.localizationInstance = Localization.instance;
        }

        [HarmonyPatch(typeof(Humanoid), nameof(Humanoid.HaveSetEffect))]
        [HarmonyPostfix]
        static void shitpatch(ItemDrop.ItemData item, Humanoid __instance, ref bool __result)
        {
            if (__result) return;
            if(item == null) return;
            if(item.m_dropPrefab == null) return;
            if(ItemManager.allPrefabs.Contains(item.m_dropPrefab.name))
            {
                __result = item != null && !(item.m_shared.m_setStatusEffect == null) && 
                    item.m_shared.m_setName.Length != 0 && item.m_shared.m_setSize > 0 &&
                    __instance.GetSetCount(item.m_shared.m_setName) >= item.m_shared.m_setSize;
            }
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
