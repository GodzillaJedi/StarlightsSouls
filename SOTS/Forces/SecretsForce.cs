using Fargowiltas.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Forces;
using ssm.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ssm.SOTS.Forces
{
    [ExtendsFromMod(ModCompatibility.SecretsOfTheShadows.Name)]
    [JITWhenModsEnabled(ModCompatibility.SecretsOfTheShadows.Name)]
    public class SecretsForce : BaseForce
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
            ModContent.Find<ModItem>(((ModType)this).Mod.Name, "WormwoodEnchant").UpdateAccessory(player, hideVisual);
            ModContent.Find<ModItem>(((ModType)this).Mod.Name, "ElementalEnchant").UpdateAccessory(player, hideVisual);
            ModContent.Find<ModItem>(((ModType)this).Mod.Name, "FrostArtifactEnchant").UpdateAccessory(player, hideVisual);
            ModContent.Find<ModItem>(((ModType)this).Mod.Name, "FrigidEnchant").UpdateAccessory(player, hideVisual);
            ModContent.Find<ModItem>(((ModType)this).Mod.Name, "TwilightAssassinEnchant").UpdateAccessory(player, hideVisual);
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();

            recipe.AddIngredient(null, "WormwoodEnchant");
            recipe.AddIngredient(null, "ElementalEnchant");
            recipe.AddIngredient(null, "FrostArtifactEnchant");
            recipe.AddIngredient(null, "FrigidEnchant");
            recipe.AddIngredient(null, "TwilightAssassinEnchant");

            recipe.AddTile<CrucibleCosmosSheet>();

            recipe.Register();
        }
    }
}
