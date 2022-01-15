using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JudesEquipment
{
    public static class Util
    {
        public static readonly int[] Torso = { 0, 1, 2, 3, 7, 26 };
        public static readonly int[] ArmUpperLeft = { 8 };
        public static readonly int[] ArmLowerLeft = { 9 };
        public static readonly int[] HandLeft = { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
        public static readonly int[] ArmUpperRight = { 27 };
        public static readonly int[] ArmLowerRight = { 28 };
        public static readonly int[] HandRight = { 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44 };
        public static readonly int[] LegUpperLeft = { 45 };
        public static readonly int[] LegLowerLeft = { 46 };
        public static readonly int[] FootLeft = { 47, 48 };
        public static readonly int[] LegUpperRight = { 49 };
        public static readonly int[] LegLowerRight = { 50 };
        public static readonly int[] FootRight = { 51, 52 };

        public static readonly int[] TorsoUpperArms = Torso.Concat(ArmUpperLeft).Concat(ArmUpperRight).ToArray();
        public static readonly int[] TorsoUpperLowerArms = Torso.Concat(ArmUpperLeft).Concat(ArmLowerLeft).Concat(ArmUpperRight).Concat(ArmLowerRight).ToArray();

        public static readonly int[] CompleteLegs = LegUpperLeft.Concat(LegLowerLeft).Concat(FootLeft).Concat(LegUpperRight).Concat(LegLowerRight).Concat(FootRight).ToArray();

        public static GameObject PullGoFromAB(string goName, AssetBundle bundle)
        {
            return bundle.LoadAsset<GameObject>(goName);
        }

        public static AssetBundle LoadBundle(string bundleName)
        {
            return  AssetBundle.LoadFromStream(Main.assembly.GetManifestResourceStream(Main.assembly.GetName().Name + ".Resources." + bundleName));
        }

        public static bool IsBsmithAvailable()
        {
            Type type = Type.GetType("BlacksmithTools.BodypartSystem,BlacksmithTools");
            if (type != null)
            {
                Main.log.LogMessage("Blacksmith's tools found.");
                return true;
            }
            else
            {
                Main.log.LogWarning("Blacksmith's tools not found.");
                return false;
            }
        }

        public static GameObject FindInOdb(string prefabName, ObjectDB odb)
        {
            foreach (GameObject prefab in odb.m_items)
            {
                if (prefab.name == prefabName) return prefab;
            }
            return null;
        }

        public static List<HitData.DamageModPair> ParseDmgModPairs(string def)
        {
            try
            {
                if (string.IsNullOrEmpty(def)) return new List<HitData.DamageModPair>();
                def = def.Trim();

                List<HitData.DamageModPair> dmgModPairs = new List<HitData.DamageModPair>();

                string[] splitPairs = def.Split(';');
                foreach (string pair in splitPairs)
                {
                    string[] splitPair = pair.Split(':');
                    HitData.DamageType dmgType = (HitData.DamageType)Enum.Parse(typeof(HitData.DamageType), splitPair[0].ToString().Trim());
                    HitData.DamageModifier dmgMod = (HitData.DamageModifier)Enum.Parse(typeof(HitData.DamageModifier), splitPair[1].ToString().Trim());

                    dmgModPairs.Add(new HitData.DamageModPair() { m_type = dmgType, m_modifier = dmgMod });
                }

                return dmgModPairs;
            }
            catch(Exception e)
            {
                Main.log.LogError(e.Message);
                return new List<HitData.DamageModPair>();
            }
        }
    }
}
