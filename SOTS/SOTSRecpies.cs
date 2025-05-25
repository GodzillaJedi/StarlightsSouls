using FargowiltasSouls.Content.Items.Accessories.Souls;
using ssm.Thorium.Souls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using ThoriumMod.Items.Donate;
using ssm.SOTS.Souls;
using SOTS.Items;
using SOTS.Common.PlayerDrawing;
using SOTS.Items.Wings;

namespace ssm.SOTS
{
    public class SOTSRecpies : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (recipe.HasResult<EternitySoul>() && !recipe.HasIngredient<SotsSoul>())
                {
                    recipe.AddIngredient<SotsSoul>();
                }
                if (recipe.HasResult<FlightMasterySoul>() && !recipe.HasIngredient<GildedBladeWings>())
                {
                    recipe.AddIngredient<GildedBladeWings>();
                }
                if (recipe.HasResult<ColossusSoul>() && !recipe.HasIngredient<VoidShield>())
                {
                    recipe.AddIngredient<VoidShield>();
                }
            }
        }
    }
}
