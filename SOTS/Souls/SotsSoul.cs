using Fargowiltas.Items.Tiles;
using FargowiltasSouls.Content.Items.Accessories.Souls;
using FargowiltasSouls.Content.Items.Materials;
using SOTS.Void;
using ssm.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ssm.SOTS.Souls
{
    [ExtendsFromMod(ModCompatibility.SecretsOfTheShadows.Name)]
    [JITWhenModsEnabled(ModCompatibility.SecretsOfTheShadows.Name)]
    public class SotsSoul : BaseSoul
    {
        private readonly Mod secrets = ModLoader.GetMod("SOTS");
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.value = 5000000;
            Item.defense = 15;
            Item.rare = -12;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[ModContent.Find<ModBuff>(this.secrets.Name, "AbyssalInferno").Type] = true;
            player.buffImmune[ModContent.Find<ModBuff>(this.secrets.Name, "CreativeShock2").Type] = true;
            player.buffImmune[ModContent.Find<ModBuff>(this.secrets.Name, "VoidShock").Type] = true;
            player.buffImmune[ModContent.Find<ModBuff>(this.secrets.Name, "VoidSickness").Type] = true;
            player.buffImmune[ModContent.Find<ModBuff>(this.secrets.Name, "PharaohsCurse").Type] = true;
            player.buffImmune[ModContent.Find<ModBuff>(this.secrets.Name, "ChaosState2").Type] = true;
            player.buffImmune[ModContent.Find<ModBuff>(this.secrets.Name, "LungRot").Type] = true;
            
            VoidPlayer voidPlayer = player.GetModPlayer<VoidPlayer>();
            voidPlayer.voidMeter = 100000;
            voidPlayer.voidMeterMax = 120000;

            ModContent.Find<ModItem>(((ModType)this).Mod.Name, "SecretsForce").UpdateAccessory(player, hideVisual);
            ModContent.Find<ModItem>(((ModType)this).Mod.Name, "ShadowsForce").UpdateAccessory(player, hideVisual);
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();

            recipe.AddIngredient<AbomEnergy>(10);
            recipe.AddIngredient(null, "SecretsForce");
            recipe.AddIngredient(null, "ShadowsForce");

            recipe.AddTile<CrucibleCosmosSheet>();

            recipe.Register();
        }
    }
}
