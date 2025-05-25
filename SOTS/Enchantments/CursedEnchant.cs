using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using Microsoft.Xna.Framework;
using SOTS.Items.Evil;
using SOTS.Items.Pyramid;
using ssm.Content.SoulToggles;
using ssm.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ssm.SOTS.Enchantments
{
    [ExtendsFromMod(ModCompatibility.SecretsOfTheShadows.Name)]
    [JITWhenModsEnabled(ModCompatibility.SecretsOfTheShadows.Name)]
    public class CursedEnchant : BaseEnchant
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
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.AddEffect<MidnightEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "MidnightPrism").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<HeartJarEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "HeartInAJar").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<WitchHeartEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "WitchHeart").UpdateAccessory(player, hideVisual: true);
            }
            ModContent.Find<ModItem>(secrets.Name, "CursedHood").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "CursedRobe").UpdateArmorSet(player);
        }
        public override Color nameColor => new Color (244, 25, 255);
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<CursedRobe>());
            recipe.AddIngredient(ModContent.ItemType<CursedHood>());
            recipe.AddIngredient(ModContent.ItemType<HeartInAJar>());
            recipe.AddIngredient(ModContent.ItemType<HeartInAJar>());
            recipe.AddIngredient(ModContent.ItemType<MidnightPrism>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
        public class MidnightEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<CursedEnchant>();
        }
        public class HeartJarEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<CursedEnchant>();
        }
        public class WitchHeartEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<CursedEnchant>();
        }
    }
}
