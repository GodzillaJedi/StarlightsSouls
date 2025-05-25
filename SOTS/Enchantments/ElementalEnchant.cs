using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using Microsoft.Xna.Framework;
using SOTS.Items.Chaos;
using SOTS.Items.CritBonus;
using ssm.Content.SoulToggles;
using ssm.Core;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ssm.SOTS.Enchantments
{
    [ExtendsFromMod(ModCompatibility.SecretsOfTheShadows.Name)]
    [JITWhenModsEnabled(ModCompatibility.SecretsOfTheShadows.Name)]
    public class ElementalEnchant : BaseEnchant
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
        public override Color nameColor => new(244, 25, 255);

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.AddEffect<EyeChaosEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "EyeOfChaos").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<ChaosBadgeEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "ChaosBadge").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<VoidmageEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "VoidmageIncubator").UpdateAccessory(player, hideVisual: true);
            }
            ModContent.Find<ModItem>(secrets.Name, "ElementalHelmet").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "ElementalBreastplate").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "ElementalLeggings").UpdateArmorSet(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ElementalHelmet>());
            recipe.AddIngredient(ModContent.ItemType<ElementalBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<ElementalLeggings>());
            recipe.AddIngredient(ModContent.ItemType<EyeOfChaos>());
            recipe.AddIngredient(ModContent.ItemType<ChaosBadge>());
            recipe.AddIngredient(ModContent.ItemType<VoidmageIncubator>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
        public class VoidmageEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<ElementalEnchant>();
        }
        public class ChaosBadgeEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<ElementalEnchant>();
        }
        public class EyeChaosEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<ElementalEnchant>();
        }
    }
}
