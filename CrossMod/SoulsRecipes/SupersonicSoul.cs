using FargowiltasSouls.Content.Items.Accessories.Souls;
using Terraria.ModLoader;
using Terraria;
using ssm.Core;
using System.Collections.Generic;
using Terraria.Localization;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler.Content;
using ContinentOfJourney.Items.Accessories;
using Terraria.ID;

namespace ssm.CrossMod.SoulsRecipes
{
    public class SupersonicSoulRecipe : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult(ModContent.ItemType<SupersonicSoul>()))
                {
                    if (ModCompatibility.Homeward.Loaded) { recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("HourHand"), 1); recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("Edgewalker"), 1); }
                }
            }
        }
    }
    public class SupersonicSoulEffects : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void UpdateAccessory(Item Item, Player player, bool hideVisual)
        {
            if (Item.type == ModContent.ItemType<SupersonicSoul>() || Item.type == ModContent.ItemType<DimensionSoul>() || Item.type == ModContent.ItemType<EternitySoul>())
            {
                if (ModCompatibility.Homeward.Loaded)
                {
                    player.AddEffect<HourHandEffect>(Item);
                    player.AddEffect<EdgewalkerEffect>(Item);
                }
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string key = "Mods.ssm.Items.AddedEffects.";

            if (item.type == ModContent.ItemType<SupersonicSoul>() && !item.social)
            {
                if (ModCompatibility.Homeward.Loaded)
                {
                    tooltips.Insert(5, new TooltipLine(Mod, "mayo2", Language.GetTextValue(key + "HWJSupersonic")));
                }
            }
            if (ModCompatibility.Homeward.Loaded)
            {
                if (item.type == ModCompatibility.Homeward.Mod.Find<ModItem>("Horizon").Type && !item.social)
                {
                    tooltips.Insert(5, new TooltipLine(Mod, "mayo3", Language.GetTextValue("Mods.ssm.Aeolus")));
                }
            }
        }
        [ExtendsFromMod(ModCompatibility.Homeward.Name)]
        public class HourHandEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SupersonicHeader>();
            public override int ToggleItemType => ModContent.ItemType<HourHand>();

            public override void PostUpdateEquips(Player player)
            {
                ModCompatibility.Homeward.Mod.Find<ModItem>("HourHand").UpdateAccessory(player, true);
            }
        }
        [ExtendsFromMod(ModCompatibility.Homeward.Name)]
        public class EdgewalkerEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SupersonicHeader>();
            public override int ToggleItemType => ModContent.ItemType<Edgewalker>();

            public override void PostUpdateEquips(Player player)
            {
                ModCompatibility.Homeward.Mod.Find<ModItem>("Edgewalker").UpdateAccessory(player, true);
            }
        }
    }
}
