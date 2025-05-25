using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using Microsoft.Xna.Framework;
using SOTS.Items.Chaos;
using SOTS.Items.Planetarium;
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
    public class TwilightAssassinEnchant : BaseEnchant
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
            if (player.AddEffect<HyperdriveEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "Hyperdrive").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<BladeNecklaceEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "BladeNecklace").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<BlinkEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "BlinkPack").UpdateAccessory(player, hideVisual: true);
            }
            ModContent.Find<ModItem>(secrets.Name, "TwilightAssassinsCirclet").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "TwilightAssassinsChestplate").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "TwilightAssassinsLeggings").UpdateArmorSet(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TwilightAssassinsCirclet>());
            recipe.AddIngredient(ModContent.ItemType<TwilightAssassinsChestplate>());
            recipe.AddIngredient(ModContent.ItemType<TwilightAssassinsLeggings>());
            recipe.AddIngredient(ModContent.ItemType<Hyperdrive>());
            recipe.AddIngredient(ModContent.ItemType<BladeNecklace>());
            recipe.AddIngredient(ModContent.ItemType<BlinkPack>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
        public class HyperdriveEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<TwilightAssassinEnchant>();
        }
        public class BladeNecklaceEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<TwilightAssassinEnchant>();
        }
        public class BlinkEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<TwilightAssassinEnchant>();
        }
    }
}
