using FargowiltasSouls.Content.Items.Accessories.Souls;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using ssm.Core;
using ContinentOfJourney.Items.Accessories;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler.Content;
using FargowiltasSouls.Content.Items.Accessories.Essences;
using System.Collections.Generic;
using Terraria.Localization;

namespace ssm.CrossMod.SoulsRecipes
{
    public class SniperSoulRecipe : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult(ModContent.ItemType<SnipersSoul>()))
                {
                    if (ModCompatibility.Homeward.Loaded) { recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("WalnutOnFire"), 1); recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("Duality"), 1); recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("TheBatter"), 1); recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("CrossbowScope"), 1); recipe.RemoveIngredient(ItemID.ReconScope); }
                    if (ModCompatibility.Clamity.Loaded) { recipe.AddIngredient(ModCompatibility.Clamity.Mod.Find<ModItem>("RoseBow"), 1); }
                }
                if (ModCompatibility.Calamity.Loaded)
                {
                }
                if (ModCompatibility.Homeward.Loaded)
                {
                    if (recipe.HasResult(ModCompatibility.Homeward.Mod.Find<ModItem>("CrossbowScope")))
                    {
                    }
                }
            }
        }
    }
    public class SniperSoulEffects : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void UpdateAccessory(Item Item, Player player, bool hideVisual)
        {
            if (Item.type == ModContent.ItemType<SnipersSoul>() || Item.type == ModContent.ItemType<UniverseSoul>() || Item.type == ModContent.ItemType<EternitySoul>())
            {
                if (ModCompatibility.Homeward.Loaded)
                {
                    player.AddEffect<WalnutOnFireEffect>(Item);
                    player.AddEffect<StarQuiverEffect>(Item);
                    player.AddEffect<TheBatterEffect>(Item);
                }
            }
            if (ModCompatibility.Calamity.Loaded)
            {
                if (Item.type == ModCompatibility.Calamity.Mod.Find<ModItem>("ElementalQuiver").Type)
                {
                    if (ModCompatibility.Homeward.Loaded)
                    {
                        player.AddEffect<StarQuiverEffect>(Item);
                    }
                }
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string key = "Mods.ssm.Items.AddedEffects.";

            if (item.type == ModContent.ItemType<SnipersSoul>() && !item.social)
            {
                if (ModCompatibility.Homeward.Loaded)
                {
                    tooltips.Insert(6, new TooltipLine(Mod, "mayo1", Language.GetTextValue(key + "HWJSniper")));
                    tooltips.Insert(6, new TooltipLine(Mod, "mayo2", Language.GetTextValue(key + "HWJStarSniper")));
                }
            }
            if (ModCompatibility.Calamity.Loaded)
            {
                if (item.type == ModCompatibility.Calamity.Mod.Find<ModItem>("ElementalQuiver").Type && !item.social)
                {
                    if (ModCompatibility.Homeward.Loaded)
                    {
                        tooltips.Insert(5, new TooltipLine(Mod, "mayo2", Language.GetTextValue(key + "HWJStarSniper")));
                    }
                }
            }
        }
        [ExtendsFromMod(ModCompatibility.Homeward.Name)]
        public class WalnutOnFireEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<UniverseHeader>();
            public override int ToggleItemType => ModContent.ItemType<WalnutOnFire>();

            public override void PostUpdateEquips(Player player)
            {
                ModCompatibility.Homeward.Mod.Find<ModItem>("WalnutOnFire").UpdateAccessory(player, true);
            }
        }
        [ExtendsFromMod(ModCompatibility.Homeward.Name)]
        public class StarQuiverEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<UniverseHeader>();
            public override int ToggleItemType => ModContent.ItemType<StarQuiver>();

            public override void PostUpdateEquips(Player player)
            {
                ModCompatibility.Homeward.Mod.Find<ModItem>("StarQuiver").UpdateAccessory(player, true);
            }
        }
        [ExtendsFromMod(ModCompatibility.Homeward.Name)]
        public class TheBatterEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<UniverseHeader>();
            public override int ToggleItemType => ModContent.ItemType<TheBatter>();

            public override void PostUpdateEquips(Player player)
            {
                ModCompatibility.Homeward.Mod.Find<ModItem>("TheBatter").UpdateAccessory(player, true);
            }
        }
    }
}
