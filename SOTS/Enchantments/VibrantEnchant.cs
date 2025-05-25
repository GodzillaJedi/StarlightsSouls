using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using Microsoft.Xna.Framework;
using SOTS.Items.CritBonus;
using SOTS.Items.Earth;
using SOTS.Items.Fragments;
using SOTS.Items.Planetarium.FromChests;
using ssm.Content.SoulToggles;
using ssm.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ssm.SOTS.Enchantments
{
    [ExtendsFromMod(ModCompatibility.SecretsOfTheShadows.Name)]
    [JITWhenModsEnabled(ModCompatibility.SecretsOfTheShadows.Name)]
    public class VibrantEnchant : BaseEnchant
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
        public override Color nameColor => new(255, 128, 0);
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.AddEffect<WorldlyEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "WorldlyPolarizer").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<SoulCharmEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "SoulCharm").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<SkywareEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "SkywareBattery").UpdateAccessory(player, hideVisual: true);
            }
            ModContent.Find<ModItem>(secrets.Name, "VibrantHelmet").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "VibrantChestplate").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "VibrantLeggings").UpdateArmorSet(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<VibrantHelmet>());
            recipe.AddIngredient(ModContent.ItemType<VibrantChestplate>());
            recipe.AddIngredient(ModContent.ItemType<VibrantLeggings>());
            recipe.AddIngredient(ModContent.ItemType<WorldlyPolarizer>());
            recipe.AddIngredient(ModContent.ItemType<SoulCharm>());
            recipe.AddIngredient(ModContent.ItemType<SkywareBattery>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
        public class WorldlyEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<VibrantEnchant>();
        }
        public class SoulCharmEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<VibrantEnchant>();
        }
        public class SkywareEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<VibrantEnchant>();
        }
    }
}
