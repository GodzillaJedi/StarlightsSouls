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
using ContinentOfJourney.Items.Accessories.SummonerRings;
using System.Text.RegularExpressions;
using CalamityMod.Items.Accessories;

namespace ssm.CrossMod.SoulsRecipes
{
    public class ConjuristSoulRecipe : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.HasResult(ModContent.ItemType<ConjuristsSoul>()))
                {
                    if (ModCompatibility.Homeward.Loaded) { recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("CommandersGaunlet"), 1); recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("IncitingIncident"), 1); recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("ConstructionPDA"), 1); }
                    if (ModCompatibility.Catalyst.Loaded) { recipe.AddIngredient(ModCompatibility.Catalyst.Mod.Find<ModItem>("UnrelentingTorment"), 1);}
                    if (ModCompatibility.Calamity.Loaded) { recipe.AddIngredient(ModCompatibility.Calamity.Mod.Find<ModItem>("PhantomicArtifact"), 1); }
                }
                if (ModCompatibility.Calamity.Loaded)
                {
                    if (recipe.HasResult(ModCompatibility.Calamity.Mod.Find<ModItem>("Nucleogenesis")))
                    {
                        if (ModCompatibility.Homeward.Loaded)
                        {
                            recipe.AddIngredient(ModCompatibility.Homeward.Mod.Find<ModItem>("DivineNecklace"), 1);
                        }
                    }
                }
                if (ModCompatibility.Homeward.Loaded)
                {
                    if (recipe.HasResult(ModCompatibility.Homeward.Mod.Find<ModItem>("CommandersGaunlet")))
                    {
                        recipe.AddIngredient(ItemID.BerserkerGlove, 1);
                        recipe.RemoveIngredient(ItemID.PowerGlove);
                        if (ModCompatibility.Calamity.Loaded) { recipe.AddIngredient(ModCompatibility.Calamity.Mod.Find<ModItem>("LifeAlloy"), 3); }
                    }
                }
            }
        }
    }
    public class ConjuristSoulEffects : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void UpdateAccessory(Item Item, Player player, bool hideVisual)
        {
            if (Item.type == ModContent.ItemType<ConjuristsSoul>() || Item.type == ModContent.ItemType<UniverseSoul>() || Item.type == ModContent.ItemType<EternitySoul>())
            {
                if (ModCompatibility.Homeward.Loaded)
                {
                    player.AddEffect<CommandersGauntletEffect>(Item);
                    player.AddEffect<DivineNecklaceEffect>(Item);
                }
                if (ModCompatibility.Calamity.Loaded)
                {
                    player.AddEffect<PhantomicArtifactEffect>(Item);
                }
            }
            if (ModCompatibility.Calamity.Loaded)
            {
                if (Item.type == ModCompatibility.Calamity.Mod.Find<ModItem>("Nucleogenesis").Type)
                {
                    if (ModCompatibility.Homeward.Loaded)
                    {
                        player.AddEffect<DivineNecklaceEffect>(Item);
                    }
                }
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string key = "Mods.ssm.Items.AddedEffects.";

            if (item.type == ModContent.ItemType<ConjuristsSoul>() && !item.social)
            {
                for (int i = 0; i < tooltips.Count; i++)
                {
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "3", "4");
                }
                for (int i = 0; i < tooltips.Count; i++)
                {
                    tooltips[i].Text = Regex.Replace(tooltips[i].Text, "1", "3");
                }
                if (ModCompatibility.Homeward.Loaded)
                {
                    tooltips.Insert(5, new TooltipLine(Mod, "mayo1", Language.GetTextValue(key + "HWJConjurist")));
                }
            }
            if (ModCompatibility.Homeward.Loaded)
            {
                for (int i = 0; i < tooltips.Count; i++)
                {
                    if (item.type == ModCompatibility.Homeward.Mod.Find<ModItem>("CommandersGaunlet").Type && !item.social)
                    {
                        tooltips[i].Text = Regex.Replace(tooltips[i].Text, "melee", "whip");
                    }
                }
            }
        }
        [ExtendsFromMod(ModCompatibility.Calamity.Name)]
        public class PhantomicArtifactEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<UniverseHeader>();
            public override int ToggleItemType => ModContent.ItemType<PhantomicArtifact>();

            public override void PostUpdateEquips(Player player)
            {
                ModCompatibility.Calamity.Mod.Find<ModItem>("PhantomicArtifact").UpdateAccessory(player, true);
            }
        }
        [ExtendsFromMod(ModCompatibility.Homeward.Name)]
        public class DivineNecklaceEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<UniverseHeader>();
            public override int ToggleItemType => ModContent.ItemType<DivineNecklace>();

            public override void PostUpdateEquips(Player player)
            {
                ModCompatibility.Homeward.Mod.Find<ModItem>("DivineNecklace").UpdateAccessory(player, true);
            }
        }
        [ExtendsFromMod(ModCompatibility.Homeward.Name)]
        public class CommandersGauntletEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<UniverseHeader>();
            public override int ToggleItemType => ModContent.ItemType<CommandersGaunlet>();

            public override void PostUpdateEquips(Player player)
            {
                ModCompatibility.Homeward.Mod.Find<ModItem>("CommandersGaunlet").UpdateAccessory(player, true);
            }
        }
    }
}
