using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using Microsoft.Xna.Framework;
using SOTS.Items.CritBonus;
using SOTS.Items.Nature;
using SOTS.Items.Temple;
using SOTS.Items.Tide;
using ssm.Content.SoulToggles;
using ssm.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ssm.SOTS.Enchantments
{
    [ExtendsFromMod(ModCompatibility.SecretsOfTheShadows.Name)]
    [JITWhenModsEnabled(ModCompatibility.SecretsOfTheShadows.Name)]
    public class WormwoodEnchant : BaseEnchant
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
            if (player.AddEffect<PearShieldEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "PricklyPearShield").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<CloverEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "CloverCharm").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<TailEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "LihzahrdTail").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<SeaHeartEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "HeartOfTheSea").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<BotSymEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "BotanicalSymbiote").UpdateAccessory(player, hideVisual: true);
            }
            ModContent.Find<ModItem>(secrets.Name, "NatureWreath").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "NatureShirt").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "NatureLeggings").UpdateArmorSet(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NatureWreath>());
            recipe.AddIngredient(ModContent.ItemType<NatureShirt>());
            recipe.AddIngredient(ModContent.ItemType<NatureLeggings>());
            recipe.AddIngredient(ModContent.ItemType<BotanicalSymbiote>());
            recipe.AddIngredient(ModContent.ItemType<HeartOfTheSea>());
            recipe.AddIngredient(ModContent.ItemType<LihzahrdTail>());
            recipe.AddIngredient(ModContent.ItemType<CloverCharm>());
            recipe.AddIngredient(ModContent.ItemType<PricklyPearShield>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
        public class PearShieldEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<WormwoodEnchant>();
        }
        public class CloverEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<WormwoodEnchant>();
        }
        public class TailEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<WormwoodEnchant>();
        }
        public class SeaHeartEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<WormwoodEnchant>();
        }
        public class BotSymEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<WormwoodEnchant>();
        }
    }
}
