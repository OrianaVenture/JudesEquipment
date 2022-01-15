using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JudesEquipment.Configuration;
using UnityEngine;

namespace JudesEquipment
{
    public static class RecipeManager
    {
        public static List<RecipeConfig> recipeCfgs = new List<RecipeConfig>();

        public static void AddRecipe(RecipeConfig recipeCfg)
        {
            recipeCfgs.Add(recipeCfg);
            recipeCfg.Load();
        }

        public static void ResolveRecipes()
        {
            for (int i = 0; i < recipeCfgs.Count; i++)
            {
                recipeCfgs[i].ApplyConfig();
            }
        }

        public static void AddRecipesToODB(ObjectDB odb)
        {
            ResolveRecipes();
            for (int i = 0; i < recipeCfgs.Count; i++)
            {
                if(odb.m_recipes.Find(rec => rec.name == recipeCfgs[i].recipe.name) == null)
                {
                    odb.m_recipes.Add(recipeCfgs[i].recipe);
                }
            }
        }

        //ensures i catch 99,99% mods custom items for recipes
        public static IEnumerator DelayedRecipeInsertion()
        {
            yield return new WaitForSeconds(0.1f);

            AddRecipesToODB(ObjectDB.instance);
        }
    }
}
