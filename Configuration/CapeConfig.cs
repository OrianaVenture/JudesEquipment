using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JudesEquipment.Configuration
{
    class CapeConfig : ArmorConfig
    {
        public Material materialOverride;

        public override bool Load()
        {
            if (!base.Load()) return false;

            return true;
        }

        public override bool ApplyConfig()
        {
            if (!base.ApplyConfig()) return false;

            //make these based on material names in the future if planning to clone more than just lox cape, unlikely though

            List<Material> replacerArray = new List<Material>();
            SkinnedMeshRenderer[] skinnedMeshes = prefab.GetComponentsInChildren<SkinnedMeshRenderer>(true);
            for (int i = 0; i < skinnedMeshes.Length; i++)
            {
                replacerArray.Clear();
                foreach (Material mat in skinnedMeshes[i].materials)
                {
                    if (materialOverride.GetTexture("_MainTex") != null) mat.SetTexture("_MainTex", materialOverride.GetTexture("_MainTex")); else mat.SetTexture("_MainTex", null);
                    if (materialOverride.GetTexture("_BumpMap") != null) mat.SetTexture("_BumpMap", materialOverride.GetTexture("_BumpMap")); else mat.SetTexture("_BumpMap", null);
                    mat.SetTexture("_MetallicGlossMap", materialOverride.GetTexture("_MetallicGlossMap"));
                    mat.SetFloat("_MetallicGlossMap", materialOverride.GetFloat("_Glossiness"));
                    /*zif (sourceMat.GetTexture("_MetallicGlossMap") != null)
                    {
                        mat.SetTexture("_MetallicGlossMap", sourceMat.GetTexture("_MetallicGlossMap"));
                        mat.SetFloat("_MetallicGlossMap", sourceMat.GetTexture("_MetallicGlossMap"));
                    }
                    else
                    { 
                        mat.SetTexture("_MetallicGlossMap", null); 
                    }*/
                    replacerArray.Add(mat);
                }
                skinnedMeshes[i].materials = replacerArray.ToArray();
            }
            MeshRenderer[] meshRenderers = prefab.GetComponentsInChildren<MeshRenderer>(true);
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                replacerArray.Clear();
                foreach (Material mat in meshRenderers[i].materials)
                {
                    if (materialOverride.GetTexture("_MainTex") != null) mat.SetTexture("_MainTex", materialOverride.GetTexture("_MainTex")); else mat.SetTexture("_MainTex", null);
                    if (materialOverride.GetTexture("_BumpMap") != null) mat.SetTexture("_BumpMap", materialOverride.GetTexture("_BumpMap")); else mat.SetTexture("_BumpMap", null);

                    replacerArray.Add(mat);
                }
                meshRenderers[i].materials = replacerArray.ToArray();
            }

            return true;
        }
    }
}
