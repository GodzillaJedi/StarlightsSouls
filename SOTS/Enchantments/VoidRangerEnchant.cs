using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using Microsoft.Xna.Framework;
using ssm.Content.SoulToggles;
using ssm.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SOTS.Items.Celestial;
using SOTS.Items;


namespace ssm.SOTS.Enchantments
{
    [ExtendsFromMod(ModCompatibility.SecretsOfTheShadows.Name)]
    [JITWhenModsEnabled(ModCompatibility.SecretsOfTheShadows.Name)]
    public class VoidRangerEnchant : BaseEnchant
    {
        private readonly Mod secrets = ModLoader.GetMod("SOTS");
        public override Color nameColor => new Color(88, 126, 121);
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
            if (player.AddEffect<VoidspaceEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "VoidspaceEmblem").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<SubspaceEmblemEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "SubspaceLocket").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<SerpentSpineEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "SerpentSpine").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<AlchemistsEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "AlchemistsCharm").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<FoggyEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "FoggyClairvoyance").UpdateAccessory(player, hideVisual: true);
            }
            ModContent.Find<ModItem>(secrets.Name, "VoidspaceMask").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "VoidspaceBreastplate").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "VoidspaceLeggings").UpdateArmorSet(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<VoidspaceMask>());
            recipe.AddIngredient(ModContent.ItemType<VoidspaceBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<VoidspaceLeggings>());
            recipe.AddIngredient(ModContent.ItemType<SubspaceLocket>());
            recipe.AddIngredient(ModContent.ItemType<VoidspaceEmblem>());
            recipe.AddIngredient(ModContent.ItemType<SerpentSpine>());
            recipe.AddIngredient(ModContent.ItemType<AlchemistsCharm>());
            recipe.AddIngredient(ModContent.ItemType<FoggyClairvoyance>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
        public class VoidspaceEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<VoidRangerEnchant>();
        }
        public class SubspaceEmblemEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<VoidRangerEnchant>();
        }
        public class SerpentSpineEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<VoidRangerEnchant>();
        }
        public class FoggyEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<VoidRangerEnchant>();
        }
        public class AlchemistsEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<VoidRangerEnchant>();
        }
    }
}
