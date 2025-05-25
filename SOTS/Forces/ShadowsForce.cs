using Fargowiltas.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using ssm.Core;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace ssm.SOTS.Forces
{
    [ExtendsFromMod(ModCompatibility.SecretsOfTheShadows.Name)]
    [JITWhenModsEnabled(ModCompatibility.SecretsOfTheShadows.Name)]
    public class ShadowsForce : BaseForce
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = ItemRarityID.Purple;
            Item.value = 600000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ModContent.Find<ModItem>(((ModType)this).Mod.Name, "PatchLeatherEnchant").UpdateAccessory(player, hideVisual);
            ModContent.Find<ModItem>(((ModType)this).Mod.Name, "EarthenEnchant").UpdateAccessory(player, hideVisual);
            ModContent.Find<ModItem>(((ModType)this).Mod.Name, "VesperaEnchant").UpdateAccessory(player, hideVisual);
            ModContent.Find<ModItem>(((ModType)this).Mod.Name, "CursedEnchant").UpdateAccessory(player, hideVisual);
            ModContent.Find<ModItem>(((ModType)this).Mod.Name, "VibrantEnchant").UpdateAccessory(player, hideVisual);
            ModContent.Find<ModItem>(((ModType)this).Mod.Name, "VoidRangerEnchant").UpdateAccessory(player, hideVisual);
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();

            recipe.AddIngredient(null, "PatchLeatherEnchant");
            recipe.AddIngredient(null, "EarthenEnchant");
            recipe.AddIngredient(null, "VesperaEnchant");
            recipe.AddIngredient(null, "CursedEnchant");
            recipe.AddIngredient(null, "VibrantEnchant");
            recipe.AddIngredient(null, "VoidRangerEnchant");

            recipe.AddTile<CrucibleCosmosSheet>();

            recipe.Register();
        }
    }
}
