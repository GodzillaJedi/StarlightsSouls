using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler.Content;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using ssm.Core;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Souls;
using FargowiltasCrossmod.Content.Calamity.Items.Accessories.Essences;
using Clamity.Content.Items.Accessories;

namespace ssm.CrossMod.SoulsRecipes
{
    [ExtendsFromMod(ModCompatibility.Crossmod.Name)]
    [JITWhenModsEnabled(ModCompatibility.Crossmod.Name)]
    public class ThrowerSoulRecipe : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult(ModContent.ItemType<VagabondsSoul>()))
                {
                    if (ModCompatibility.Clamity.Loaded) { recipe.AddIngredient(ModCompatibility.Clamity.Mod.Find<ModItem>("DraculasCharm"), 1); }
                    if (ModCompatibility.Entropy.Loaded) { recipe.AddIngredient(ModCompatibility.Entropy.Mod.Find<ModItem>("ThiefsPocketwatchOfEclipse"), 1); }
                }
                if (ModCompatibility.Calamity.Loaded)
                {
                    if (recipe.HasResult(ModCompatibility.Calamity.Mod.Find<ModItem>("Nanotech")))
                    {
                    }
                }
            }
        }
    }

    [ExtendsFromMod(ModCompatibility.Crossmod.Name)]
    [JITWhenModsEnabled(ModCompatibility.Crossmod.Name)]
    public class ThrowerSoulEffects : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void UpdateAccessory(Item Item, Player player, bool hideVisual)
        {
            if (Item.type == ModContent.ItemType<VagabondsSoul>() || Item.type == ModContent.ItemType<UniverseSoul>() || Item.type == ModContent.ItemType<EternitySoul>())
            {
                if (ModCompatibility.Clamity.Loaded)
                {
                    player.AddEffect<DraculasCharmEffect>(Item);
                }
                //if (ModCompatibility.Entropy.Loaded)
                //{
                //    ModCompatibility.Entropy.Mod.Find<ModItem>("ThiefsPocketwatchOfEclipse").UpdateAccessory(player, true);
                //}
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string key = "Mods.ssm.Items.AddedEffects.";

            if (item.type == ModContent.ItemType<VagabondsSoul>() && !item.social)
            {
                if (ModCompatibility.Clamity.Loaded)
                {
                    tooltips.Insert(6, new TooltipLine(Mod, "mayo1", Language.GetTextValue(key + "ClamThrower")));
                }

            }
        }
        [ExtendsFromMod(ModCompatibility.Clamity.Name)]
        public class DraculasCharmEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<UniverseHeader>();
            public override int ToggleItemType => ModContent.ItemType<DraculasCharm>();

            public override void PostUpdateEquips(Player player)
            {
                ModCompatibility.Clamity.Mod.Find<ModItem>("DraculasCharm").UpdateAccessory(player, true);
            }
        }
    }
}
