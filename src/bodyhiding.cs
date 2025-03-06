using HarmonyLib;
using System.IO;
using UnityEngine;

namespace JudesEquipment.BlacksmithWares
{
    [HarmonyPatch]
    class bodyhiding
    {
        public Texture2D GetTextureMask()
        {
            Main.log.LogWarning("started creation");
            Texture2D skinMask = new Texture2D(256, 256);
            byte[] imgdata = System.IO.File.ReadAllBytes(Path.GetDirectoryName(Main.assembly.Location) + "\\playermask.png");
            skinMask.LoadImage(imgdata);
            Main.log.LogWarning("ended creation");
            return skinMask;
        }
    }
}
