using FargowiltasSouls.Content.Items.Accessories.Souls;
using Terraria.ModLoader;
using Terraria;
using ssm.Core;
using System.Collections.Generic;
using Terraria.Localization;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler.Content;
using Clamity.Content.Items.Accessories;

namespace ssm.CrossMod.SoulsRecipes
{
    public class WorldShaperSoulRecipe : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult(ModContent.ItemType<WorldShaperSoul>()))
                {
                    if (ModCompatibility.Homeward.Loaded) { recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("TimelessMiner"), 1); }
                    if (ModCompatibility.Clamity.Loaded) { recipe.AddIngredient(ModCompatibility.Clamity.Mod.Find<ModItem>("RedDie"), 1); recipe.AddIngredient(ModCompatibility.Clamity.Mod.Find<ModItem>("EidolonAmulet"), 1); }
                    if (ModCompatibility.Ragnarok.Loaded) { recipe.AddIngredient(ModCompatibility.Ragnarok.Mod.Find<ModItem>("GoldenBatDroppings"), 1); }
                }
            }
        }
    }
    public class WorldShaperSoulEffects : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void UpdateAccessory(Item Item, Player player, bool hideVisual)
        {
            if (Item.type == ModContent.ItemType<WorldShaperSoul>() || Item.type == ModContent.ItemType<DimensionSoul>() || Item.type == ModContent.ItemType<EternitySoul>())
            {
                if (ModCompatibility.Clamity.Loaded)
                {
                    ModCompatibility.Clamity.Mod.Find<ModItem>("RedDie").UpdateAccessory(player, true);
                    player.AddEffect<EidolonAmuletEffect>(Item);
                }
                if (ModCompatibility.Ragnarok.Loaded)
                {
                    ModCompatibility.Ragnarok.Mod.Find<ModItem>("GoldenBatDroppings").UpdateAccessory(player, true);
                }
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string key = "Mods.ssm.Items.AddedEffects.";

            if (item.type == ModContent.ItemType<WorldShaperSoul>() && !item.social)
            {
                if (ModCompatibility.Clamity.Loaded)
                {
                    tooltips.Insert(5, new TooltipLine(Mod, "mayo1", Language.GetTextValue(key + "ClamWorldshaper")));
                }
            }
        }
        [ExtendsFromMod(ModCompatibility.Clamity.Name)]
        public class EidolonAmuletEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<WorldShaperHeader>();
            public override int ToggleItemType => ModContent.ItemType<EidolonAmulet>();

            public override void PostUpdateEquips(Player player)
            {
                ModCompatibility.Clamity.Mod.Find<ModItem>("EidolonAmulet").UpdateAccessory(player, true);
            }
        }
    }
}
