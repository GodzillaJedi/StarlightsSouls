using FargowiltasSouls.Content.Items.Accessories.Forces;
using Terraria.ModLoader;
using Terraria;
using ssm.Core;
using ssm.Consolaria.Enchantments;


namespace ssm.Consolaria.Forces
{
    [JITWhenModsEnabled(ModCompatibility.Consolaria.Name)]
    [ExtendsFromMod(ModCompatibility.Consolaria.Name)]
    public class HeroForce : BaseForce
    {
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ModContent.Find<ModItem>(base.Mod.Name, "OstaraEnchant").UpdateAccessory(player, false);
            ModContent.Find<ModItem>(base.Mod.Name, "DragonEnchantC").UpdateAccessory(player, false);
            ModContent.Find<ModItem>(base.Mod.Name, "TitanEnchantC").UpdateAccessory(player, false);
            ModContent.Find<ModItem>(base.Mod.Name, "PhantasmalEnchant").UpdateAccessory(player, false);
            ModContent.Find<ModItem>(base.Mod.Name, "WarlockEnchantC").UpdateAccessory(player, false);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<OstaraEnchant>(1);
            recipe.AddIngredient<DragonEnchantC>(1);
            recipe.AddIngredient<TitanEnchantC>(1);
            recipe.AddIngredient<PhantasmalEnchant>(1);
            recipe.AddIngredient<WarlockEnchantC>(1);
            recipe.AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"));
            recipe.Register();
        }
    }
}
