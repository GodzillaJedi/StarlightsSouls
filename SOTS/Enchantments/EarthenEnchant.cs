using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using Microsoft.Xna.Framework;
using SOTS.Items.AbandonedVillage;
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
    public class EarthenEnchant : BaseEnchant
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
        public override Color nameColor => new Color (102, 89, 54);
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.AddEffect<EmeraldEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "EmeraldBracelet").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<SpiritGloveEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "SpiritGlove").UpdateAccessory(player, hideVisual: true);
            }
            ModContent.Find<ModItem>(secrets.Name, "EarthenHelmet").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "EarthenChestplate").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "EarthenLeggings").UpdateArmorSet(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<EarthenHelmet>());
            recipe.AddIngredient(ModContent.ItemType<EarthenChestplate>());
            recipe.AddIngredient(ModContent.ItemType<EarthenLeggings>());
            recipe.AddIngredient(ModContent.ItemType<SpiritShield>());
            recipe.AddIngredient(ModContent.ItemType<SpiritGlove>());
            recipe.AddIngredient(ModContent.ItemType<EmeraldBracelet>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
        public class EmeraldEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<EarthenEnchant>();
        }
        public class SpiritGloveEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<EarthenEnchant>();
        }
    }
}
