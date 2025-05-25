using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using Microsoft.Xna.Framework;
using SOTS.Items;
using SOTS.Items.Permafrost;
using ssm.Content.SoulToggles;
using ssm.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ssm.SOTS.Enchantments
{
    [ExtendsFromMod(ModCompatibility.SecretsOfTheShadows.Name)]
    [JITWhenModsEnabled(ModCompatibility.SecretsOfTheShadows.Name)]
    public class FrostArtifactEnchant : BaseEnchant
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
            if (player.AddEffect<ShardEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "ShardGuard").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<PermafrostEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "PermafrostMedallion").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<SupernovaEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "SupernovaEmblem").UpdateAccessory(player, hideVisual: true);
            }
            ModContent.Find<ModItem>(secrets.Name, "FrostArtifactHelmet").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "FrostArtifactChestplate").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "FrostArtifactTrousers").UpdateArmorSet(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<FrostArtifactHelmet>());
            recipe.AddIngredient(ModContent.ItemType<FrostArtifactChestplate>());
            recipe.AddIngredient(ModContent.ItemType<FrostArtifactTrousers>());
            recipe.AddIngredient(ModContent.ItemType<SupernovaEmblem>());
            recipe.AddIngredient(ModContent.ItemType<PermafrostMedallion>());
            recipe.AddIngredient(ModContent.ItemType<ShardGuard>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
        public class ShardEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<FrostArtifactEnchant>();
        }
        public class PermafrostEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<FrostArtifactEnchant>();
        }
        public class SupernovaEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<SecretsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<FrostArtifactEnchant>();
        }
    }
}
