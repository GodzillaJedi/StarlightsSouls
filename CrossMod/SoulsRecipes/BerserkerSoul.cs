using ContinentOfJourney;
using ContinentOfJourney.Items.Accessories;
using ContinentOfJourney.Items.Accessories.MeleeExpansion;
using FargowiltasSouls.Content.Bosses.MutantBoss;
using FargowiltasSouls.Content.Items.Accessories.Essences;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Materials;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using FargowiltasSouls.Core.Toggler.Content;
using ssm.Content.NPCs.RealMutantEX;
using ssm.Core;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ssm.CrossMod.SoulsRecipes
{
    public class BerserkerSoulRecipe : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult(ModContent.ItemType<BerserkerSoul>()))
                {
                    if (ModCompatibility.Homeward.Loaded) { recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("PhilosophersStone"), 1); recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("TrueDawnsBorder"), 1); recipe.RemoveIngredient(ItemID.CelestialShell); }
                    if (ModCompatibility.Calamity.Loaded) { recipe.AddIngredient(ModCompatibility.Calamity.Mod.Find<ModItem>("ArkoftheCosmos"), 1); }
                }
                if (ModCompatibility.Calamity.Loaded)
                {
                    if (recipe.HasResult(ModCompatibility.Calamity.Mod.Find<ModItem>("ArkoftheCosmos")))
                    {
                        recipe.AddIngredient<Eridanium>(5);
                    }
                    if (recipe.HasResult(ModCompatibility.Calamity.Mod.Find<ModItem>("ElementalGauntlet")))
                    {
                        if (ModCompatibility.Homeward.Loaded) { recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("DivineTouch"), 1); recipe.RemoveIngredient(ItemID.FireGauntlet); }
                    }
                }
            }
        }
    }
    public class BerserkerSoulEffects : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void UpdateAccessory(Item Item, Player player, bool hideVisual)
        {
            if (Item.type == ModContent.ItemType<BerserkerSoul>() || Item.type == ModContent.ItemType<UniverseSoul>() || Item.type == ModContent.ItemType<EternitySoul>())
            {
                if (ModCompatibility.Homeward.Loaded)
                {
                    player.AddEffect<PhilosophersStoneEffect>(Item);
                    player.AddEffect<GodlyTouchEffect>(Item);
                    player.AddEffect<BerserkerGloveEffect>(Item);
                }
            }
            if (ModCompatibility.Homeward.Loaded)
            {
                if (Item.type == ModCompatibility.Homeward.Mod.Find<ModItem>("CommandersGaunlet").Type)
                {
                    player.AddEffect<BerserkerGloveEffect>(Item);
                }
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string key = "Mods.ssm.Items.AddedEffects.";

            if (item.type == ModContent.ItemType<BerserkerSoul>() && !item.social)
            {
                if (ModCompatibility.Homeward.Loaded)
                {
                    tooltips.Insert(6, new TooltipLine(Mod, "mayo1", Language.GetTextValue(key + "HWJBerserker")));
                }
            }
        }
        [ExtendsFromMod(ModCompatibility.Homeward.Name)]
        public class PhilosophersStoneEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<UniverseHeader>();
            public override int ToggleItemType => ModContent.ItemType<PhilosophersStone>();
            public override bool MutantsPresenceAffects => true;
            public override void PostUpdateEquips(Player player)
            {
                if (!NPC.AnyNPCs(ModContent.NPCType<RealMutantEX>()) && !NPC.AnyNPCs(ModContent.NPCType<MutantBoss>())) {
                    TemplatePlayer modPlayer = player.GetModPlayer<TemplatePlayer>();
                    modPlayer.GrindStone_Type = 4;
                    modPlayer.GrindStone_Time = 480; }
            }
        }
        [ExtendsFromMod(ModCompatibility.Homeward.Name)]
        public class GodlyTouchEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<UniverseHeader>();
            public override int ToggleItemType => ModContent.ItemType<DivineTouch>();

            public override void PostUpdateEquips(Player player)
            {
                //no free 15% stat boosts
                ModCompatibility.Homeward.Mod.Find<ModItem>("DivineEmblem").UpdateAccessory(player, true);
            }
        }
        public class BerserkerGloveEffect : AccessoryEffect
        {
            public override Header ToggleHeader => null;
            public override int ToggleItemType => ItemID.BerserkerGlove;
            public override void PostUpdateEquips(Player player)
            {
                player.statDefense += 8;
                player.kbGlove = true;
                player.meleeScaleGlove = true;
                player.autoReuseGlove = true;
            }
        }
    }
}