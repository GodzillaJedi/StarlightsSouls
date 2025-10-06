using FargowiltasSouls.Content.Items.Accessories.Souls;
using Terraria.ModLoader;
using Terraria;
using ssm.Core;
using System.Collections.Generic;
using Terraria.Localization;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler.Content;
using ContinentOfJourney.Items.Accessories;
using FargowiltasSouls.Content.Items.Accessories.Essences;
using Terraria.ID;
using static ssm.CrossMod.SoulsRecipes.BerserkerSoulEffects;
using CalamityMod.Items.Accessories;

namespace ssm.CrossMod.SoulsRecipes
{
    public class ColossusSoulRecipe : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult(ModContent.ItemType<ColossusSoul>()))
                {
                    if (ModCompatibility.Homeward.Loaded) { recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("OneGiantLeap"), 1); recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("MasterShield"), 1); }
                    if (ModCompatibility.Clamity.Loaded) { recipe.AddIngredient(ModCompatibility.Clamity.Mod.Find<ModItem>("SkullOfTheBloodGod"), 1); }
                }

                if (ModCompatibility.Homeward.Loaded)
                {
                    if (recipe.HasResult(ModCompatibility.Homeward.Mod.Find<ModItem>("VanguardBreastpiece")))
                    {
                    }
                }

                if (ModCompatibility.Calamity.Loaded)
                {
                    if (recipe.HasResult(ModCompatibility.Calamity.Mod.Find<ModItem>("RampartofDeities")))
                    {
                        if (ModCompatibility.Homeward.Loaded) { recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("VanguardBreastpiece"), 1); recipe.RemoveIngredient(ItemID.FrozenShield); }
                    }
                }
            }
        }
    }
    public class ColossusSoulEffects : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void UpdateAccessory(Item Item, Player player, bool hideVisual)
        {
            if (Item.type == ModContent.ItemType<ColossusSoul>() || Item.type == ModContent.ItemType<DimensionSoul>() || Item.type == ModContent.ItemType<EternitySoul>())
            {
                if (ModCompatibility.Homeward.Loaded)
                {
                    player.AddEffect<OneGiantLeapEffect>(Item);
                    player.AddEffect<MasterShieldEffect>(Item);
                    ModCompatibility.Homeward.Mod.Find<ModItem>("VanguardBreastpiece").UpdateAccessory(player, true);
                    ModCompatibility.Homeward.Mod.Find<ModItem>("AncientBlessing").UpdateAccessory(player, true);
                }
                if (ModCompatibility.Clamity.Loaded)
                {
                    ModCompatibility.Clamity.Mod.Find<ModItem>("SkullOfTheBloodGod").UpdateAccessory(player, true);
                }
            }
            if (ModCompatibility.Calamity.Loaded)
            {
                if (Item.type == ModCompatibility.Calamity.Mod.Find<ModItem>("RampartofDeities").Type)
                {
                    if (ModCompatibility.Homeward.Loaded)
                    {
                        ModCompatibility.Homeward.Mod.Find<ModItem>("VanguardBreastpiece").UpdateAccessory(player, true);
                    }
                }
            }
            if (ModCompatibility.Homeward.Loaded)
            {
                if (Item.type == ModCompatibility.Homeward.Mod.Find<ModItem>("VanguardBreastpiece").Type)
                {
                }
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string key = "Mods.ssm.Items.AddedEffects.";

            if (item.type == ModContent.ItemType<ColossusSoul>() && !item.social)
            {
                if (ModCompatibility.Homeward.Loaded)
                {
                    tooltips.Insert(5, new TooltipLine(Mod, "mayo4", Language.GetTextValue(key + "HWJColossus")));
                    tooltips.Insert(5, new TooltipLine(Mod, "mayo4", Language.GetTextValue(key + "HWJBlessing")));
                }
                if (ModCompatibility.Clamity.Loaded)
                {
                    tooltips.Insert(5, new TooltipLine(Mod, "mayo3", Language.GetTextValue(key + "ClamColossus")));
                }
            }
            if (ModCompatibility.Homeward.Loaded)
            {
                if (item.type == ModCompatibility.Homeward.Mod.Find<ModItem>("VanguardBreastpiece").Type && !item.social)
                {
                }
            }
            if (ModCompatibility.Calamity.Loaded)
            {
                if (item.type == ModCompatibility.Calamity.Mod.Find<ModItem>("RampartofDeities").Type && !item.social)
                {
                    if (ModCompatibility.Homeward.Loaded)
                    {
                        tooltips.Insert(5, new TooltipLine(Mod, "mayo2", Language.GetTextValue(key + "HWJRampart")));
                    }
                }
            }
        }

        [ExtendsFromMod(ModCompatibility.Homeward.Name)]
        public class OneGiantLeapEffect : AccessoryEffect
        {
            public override int ToggleItemType => ModContent.ItemType<OneGiantLeap>();
            public override Header ToggleHeader => Header.GetHeader<ColossusHeader>();
            public override void PostUpdateEquips(Player player)
            {
                ModCompatibility.Homeward.Mod.Find<ModItem>("OneGiantLeap").UpdateAccessory(player, true);
            }
        }
        [ExtendsFromMod(ModCompatibility.Homeward.Name)]
        public class MasterShieldEffect : AccessoryEffect
        {
            public override int ToggleItemType => ModContent.ItemType<MasterShield>();
            public override Header ToggleHeader => Header.GetHeader<ColossusHeader>();
            public override void PostUpdateEquips(Player player)
            {
                ModCompatibility.Homeward.Mod.Find<ModItem>("MasterShield").UpdateAccessory(player, true);
            }
        }
    }
}
