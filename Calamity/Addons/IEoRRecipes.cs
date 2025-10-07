using ssm.Core;
using Terraria;
using Terraria.ModLoader;

namespace ssm.Calamity.Addons
{
    //bruh
    [ExtendsFromMod(ModCompatibility.IEoR.Name)]
    [JITWhenModsEnabled(ModCompatibility.IEoR.Name)]
    public class IEoRRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
            }
        }
    }
}
