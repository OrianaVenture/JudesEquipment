using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BlacksmithWares
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
