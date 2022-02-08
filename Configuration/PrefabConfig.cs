using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JudesEquipment.Configuration
{
    public class PrefabConfig
    {
        public GameObject prefab;
        public bool replaceMat = true;
        
        public GameObject GetPrefab()
        {
            if(prefab == null)
            {
                Main.log.LogWarning("prefab null");
                return null;
            }

            prefab.layer = 12;

            ItemDrop drop = prefab.GetComponent<ItemDrop>();
            ItemDrop.ItemData.SharedData stats = drop.m_itemData.m_shared;

            prefab.layer = 12;

            //localization
            string nameToken = "$" + prefab.name;
            string descriptionToken = "$" + prefab.name + "_description";

            stats.m_name = nameToken;
            stats.m_description = descriptionToken;

            if(replaceMat)
            {
                ReplaceMaterials();
            }

            if(!Main.hugosCollidersAvaiable && drop.m_itemData.m_shared.m_itemType != ItemDrop.ItemData.ItemType.Shoulder)
            {
                prefab.GetComponentsInChildren<Cloth>(true).ToList().ForEach(cloth => UnityEngine.Object.Destroy(cloth));
            }

            return prefab;
        }

        public void ReplaceMaterials()
        {
            if (prefab == null || Main.creatureShader == null) return;

            List<Renderer> rs = new List<Renderer>();
            rs.AddRange(prefab.GetComponentsInChildren<MeshRenderer>(true));
            rs.AddRange(prefab.GetComponentsInChildren<SkinnedMeshRenderer>(true));

            foreach (Renderer r in rs)
            {
                List<Material> mats = new List<Material>();
                int matIndex = 0;
                foreach (Material mat in r.materials)
                {
                    string[] textures = new string[] { "_MainTex", "_BumpMap", "_MetallicGlossMap", "_EmissionMap" };
                    string[] normals = new string[] { "_BumpMap" };

                    Material replacerMat = new Material(Main.creatureShader);
                    replacerMat.SetFloat("_Cull", 0);
                    replacerMat.SetFloat("_AddRain", 1);
                    replacerMat.SetFloat("_Glossiness", 0.0f);
                    int metallic = mat.GetTexture("_MetallicGlossMap") != null ? 1 : 0;
                    replacerMat.SetFloat("_Metallic", metallic);
                    replacerMat.SetFloat("_MetalGloss", mat.GetFloat("_GlossMapScale"));
                    replacerMat.SetFloat("_TwoSidedNormals", 1f);

                    Color metalColor = mat.GetColor("_Color");
                    Color emissionColor = mat.GetColor("_EmissionColor");

                    if (Main.neutralMetals.Value)
                    {
                        metalColor = Color.grey;
                        emissionColor = Color.black;
                    }
                    else
                    {
                        if(ItemManager.colorConfig.ContainsKey(prefab.name))
                        {
                            string colorKey = "Color " + (matIndex + 1).ToString();
                            if (ItemManager.colorConfig[prefab.name].ContainsKey(colorKey))
                            {
                                ColorUtility.TryParseHtmlString(ItemManager.colorConfig[prefab.name][colorKey], out metalColor);
                            }
                            if(ItemManager.colorConfig[prefab.name].ContainsKey("Emission color"))
                            {
                                ColorUtility.TryParseHtmlString(ItemManager.colorConfig[prefab.name]["Emission color"], out emissionColor);
                            }
                        }
                    }

                    replacerMat.SetColor("_Color", Color.white);
                    replacerMat.SetColor("_MetalColor", metalColor);
                    replacerMat.SetColor("_EmissionColor", emissionColor);

                    replacerMat.EnableKeyword("_ADDRAIN_ON");
                    replacerMat.EnableKeyword("_TWOSIDEDNORMALS_ON");

                    textures.ToList().ForEach(tex => {
                        Texture defaultTex = mat.GetTexture(tex);
                        if(defaultTex != null && Main.smoothTextures.Value) defaultTex.filterMode = FilterMode.Bilinear;
                        replacerMat.SetTexture(tex, defaultTex);
                    });
                    mats.Add(replacerMat);

                    matIndex += 1;
                }
                r.materials = mats.ToArray();
            }

            replaceMat = false;
        }
    }
}
