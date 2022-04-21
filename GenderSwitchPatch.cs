using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace JudesEquipment
{
    [HarmonyPatch]
    static class GenderSwitchPatch
    {
        [HarmonyPatch(typeof(VisEquipment), nameof(VisEquipment.AttachArmor))]
        [HarmonyPostfix]
        public static void PostFix(VisEquipment __instance, ref List<GameObject> __result)
        {
            SetEquipmentGender(ref __result, __instance);
        }

        public static void SetEquipmentGender(ref List<GameObject> equip, VisEquipment viseq)
        {
            foreach (GameObject go in equip)
            {
                if (go == null) continue;
                for (int i = 0; i < go.transform.childCount; i++)
                {
                    Transform child = go.transform.GetChild(i);
                    if (child == null) continue;
                    if (child.gameObject.name == "female" && viseq.GetModelIndex() == 0)
                    {
                        child.gameObject.SetActive(false);
                    }
                    if (child.gameObject.name == "male" && viseq.GetModelIndex() == 1)
                    {
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
