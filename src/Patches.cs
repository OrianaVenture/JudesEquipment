using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

namespace JudesEquipment
{
    [HarmonyPatch]
    static class Patches
    {
        /*public static IEnumerator DelayedRecipeInsertion()
        {
            yield return null;

            Main.ModConfig.ApplyRecipeConfigs();
        }*/

        /// <summary>
        /// Allow set size of 1.
        /// </summary>
        [HarmonyPatch]
        static class HumanoidPatch
        {
            [HarmonyTranspiler]
            [HarmonyPatch(typeof(Humanoid), nameof(Humanoid.HaveSetEffect))]
            static IEnumerable<CodeInstruction> HaveSetEffectTranspiler(IEnumerable<CodeInstruction> instructions)
            {
                return new CodeMatcher(instructions)
                    .Start()
                    .MatchStartForward(
                        new CodeInstruction(OpCodes.Ldfld,
                            AccessTools.Field(typeof(ItemDrop.ItemData), nameof(ItemDrop.ItemData.m_shared.m_setName))),
                        new CodeInstruction(OpCodes.Ldc_I4_1))
                    .ThrowIfInvalid($"Could not patch Humanoid.HaveSetEffect()!")
                    .Advance(offset: 1)
                    .SetInstruction(
                        new CodeInstruction(OpCodes.Ldc_I4_0))
                    .InstructionEnumeration();
            }
        }
    }
}
