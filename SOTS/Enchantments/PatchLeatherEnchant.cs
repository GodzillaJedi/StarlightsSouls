using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using Microsoft.Xna.Framework;
using SOTS.Items.Celestial;
using SOTS.Items.Chaos;
using SOTS.Items.CritBonus;
using SOTS.Items.Pyramid;
using ssm.Content.SoulToggles;
using ssm.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static ssm.SOTS.Enchantments.FrostArtifactEnchant;

namespace ssm.SOTS.Enchantments
{
    [ExtendsFromMod(ModCompatibility.SecretsOfTheShadows.Name)]
    [JITWhenModsEnabled(ModCompatibility.SecretsOfTheShadows.Name)]
    public class PatchLeatherEnchant : BaseEnchant
    {
        private readonly Mod secrets = ModLoader.GetMod("SOTS");
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = ItemRarityID.Red;
            Item.value = 40000;
        }
        public override Color nameColor => new(102, 89, 54);
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.AddEffect<SnakesEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "BundleOfSnakes").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<FocusEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "FocusReticle").UpdateAccessory(player, hideVisual: true);
            }
            ModContent.Find<ModItem>(secrets.Name, "PatchLeatherHat").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "PatchLeatherTunic").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "PatchLeatherPants").UpdateArmorSet(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PatchLeatherHat>());
            recipe.AddIngredient(ModContent.ItemType<PatchLeatherTunic>());
            recipe.AddIngredient(ModContent.ItemType<PatchLeatherPants>());
            recipe.AddIngredient(ModContent.ItemType<BundleOfSnakes>());
            recipe.AddIngredient(ModContent.ItemType<FocusReticle>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
        public class SnakesEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<PatchLeatherEnchant>();
        }
        public class FocusEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<PatchLeatherEnchant>();
        }
    }
}
