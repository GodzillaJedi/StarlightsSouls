using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using Microsoft.Xna.Framework;
using SOTS.Items;
using SOTS.Items.Permafrost;
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
    public class FrigidEnchant : BaseEnchant
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
        public override Color nameColor => new Color (255, 128, 0);
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.AddEffect<PrismarineEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "PrismarineNecklace").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<AntennaeEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "HydrokineticAntennae").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<AqueductEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "ArcaneAqueduct").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<FrigidEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "FrigidHourglass").UpdateAccessory(player, hideVisual: true);
            }
            ModContent.Find<ModItem>(secrets.Name, "FrigidCrown").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "FrigidRobe").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "ShatterShardChestplate").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "FrigidGreaves").UpdateArmorSet(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<FrigidCrown>());
            recipe.AddIngredient(ModContent.ItemType<FrigidRobe>());
            recipe.AddIngredient(ModContent.ItemType<ShatterShardChestplate>());
            recipe.AddIngredient(ModContent.ItemType<FrigidGreaves>());
            recipe.AddIngredient(ModContent.ItemType<ArcaneAqueduct>());
            recipe.AddIngredient(ModContent.ItemType<HydrokineticAntennae>());
            recipe.AddIngredient(ModContent.ItemType<PrismarineNecklace>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
        public class PrismarineEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<FrigidEnchant>();
        }
        public class AntennaeEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<FrigidEnchant>();
        }
        public class AqueductEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<FrigidEnchant>();
        }
        public class FrigidEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<FrigidEnchant>();
        }
    }
}
