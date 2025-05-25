using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using SOTS.Items.Chaos;
using ssm.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SOTS.Items.Invidia;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using SOTS.Items.Pyramid;
using SOTS.Items.CritBonus;
using ssm.Content.SoulToggles;
using Microsoft.Xna.Framework;

namespace ssm.SOTS.Enchantments
{
    [ExtendsFromMod(ModCompatibility.SecretsOfTheShadows.Name)]
    [JITWhenModsEnabled(ModCompatibility.SecretsOfTheShadows.Name)]
    public class VesperaEnchant : BaseEnchant
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
            if (player.AddEffect<DarkEyeEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "TheDarkEye").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<VoidCharmEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "VoidCharm").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<ParticleEffect>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.SecretsOfTheShadows.Name, "ParticleRelocator").UpdateAccessory(player, hideVisual: true);
            }
            ModContent.Find<ModItem>(secrets.Name, "VesperaMask").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "VesperaBreastplate").UpdateArmorSet(player);
            ModContent.Find<ModItem>(secrets.Name, "VesperaLeggings").UpdateArmorSet(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<VesperaMask>());
            recipe.AddIngredient(ModContent.ItemType<VesperaBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<VesperaLeggings>());
            recipe.AddIngredient(ModContent.ItemType<TheDarkEye>());
            recipe.AddIngredient(ModContent.ItemType<VoidCharm>());
            recipe.AddIngredient(ModContent.ItemType<ParticleRelocator>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
        public class DarkEyeEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<VesperaEnchant>();
        }
        public class VoidCharmEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<VesperaEnchant>();
        }
        public class ParticleEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<ShadowsForceHeader>();
            public override int ToggleItemType => ModContent.ItemType<VesperaEnchant>();
        }
    }
}
