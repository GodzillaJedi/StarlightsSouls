using FargowiltasSouls.Content.Items.Accessories.Souls;
using ssm.Calamity.Addons;
using ssm.Calamity.Souls;
using ssm.Core;
using Terraria;
using Terraria.ModLoader;

namespace ssm.Reworks
{
    public class EternityComponents : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void UpdateAccessory(Item Item, Player player, bool hideVisual)
        {
            if (Item.type == ModContent.ItemType<UniverseSoul>() || Item.type == ModContent.ItemType<EternitySoul>())
            {
                if (ModLoader.TryGetMod("ThoriumMod", out Mod tor) && ShtunConfig.Instance.Thorium)
                {
                    ModContent.Find<ModItem>(((ModType)this).Mod.Name, "GuardianAngelsSoul").UpdateAccessory(player, false);
                    ModContent.Find<ModItem>(((ModType)this).Mod.Name, "BardSoul").UpdateAccessory(player, false);

                    if (!ModLoader.HasMod(ModCompatibility.Calamity.Name))
                    {
                        ModContent.Find<ModItem>(((ModType)this).Mod.Name, "OlympiansSoul").UpdateAccessory(player, false);
                    }
                }
                if (ModLoader.TryGetMod("SacredTools", out Mod soa) && ShtunConfig.Instance.SacredTools)
                {
                    if (!ModLoader.HasMod(ModCompatibility.Calamity.Name) && !ModLoader.HasMod(ModCompatibility.Thorium.Name))
                    {
                        ModContent.Find<ModItem>(((ModType)this).Mod.Name, "StalkerSoul").UpdateAccessory(player, false);
                    }
                }
                //if (ModCompatibility.ClikerClass.Loaded)
                //{
                //    ModContent.Find<ModItem>(((ModType)this).Mod.Name, "ClickerSoul").UpdateAccessory(player, false);
                //}
                if (ModCompatibility.BeekeeperClass.Loaded && ShtunConfig.Instance.Beekeeper)
                {
                    ModContent.Find<ModItem>(((ModType)this).Mod.Name, "BeekeeperSoul").UpdateAccessory(player, false);
                }
            }
            if (Item.type == ModContent.ItemType<TerrariaSoul>() || Item.type == ModContent.ItemType<EternitySoul>())
            {
                if (ModLoader.TryGetMod("Spooky", out Mod tor) && ShtunConfig.Instance.Spooky)
                {
                    ModContent.Find<ModItem>(((ModType)this).Mod.Name, "HorrorForce").UpdateAccessory(player, false);
                    ModContent.Find<ModItem>(((ModType)this).Mod.Name, "TerrorForce").UpdateAccessory(player, false);
                }
                if (ModLoader.TryGetMod("Polarities", out Mod soa) && ShtunConfig.Instance.Polarities)
                {
                    ModContent.Find<ModItem>(((ModType)this).Mod.Name, "WildernessForce").UpdateAccessory(player, false);
                    ModContent.Find<ModItem>(((ModType)this).Mod.Name, "SpacetimeForce").UpdateAccessory(player, false);
                }
            }
            if (Item.type == ModContent.ItemType<EternitySoul>() || Item.type == ModContent.ItemType<CalamitySoul>())
            {
                if (ModCompatibility.Entropy.Loaded && ModCompatibility.Clamity.Loaded && ModCompatibility.Goozma.Loaded && ModCompatibility.Catalyst.Loaded)
                {
                    ModContent.Find<ModItem>(this.Mod.Name, "AddonsForce").UpdateAccessory(player, false);
                }
                if (ModCompatibility.WrathoftheGods.Loaded)
                {
                    ModContent.GetInstance<SolynsSigil>().UpdateAccessory(player, hideVisual);
                }
                if (ModCompatibility.Crossmod.Loaded)
                {
                    ModContent.Find<ModItem>(ModCompatibility.Crossmod.Name, "BrandoftheBrimstoneWitch").UpdateAccessory(player, hideVisual);
                    ModContent.Find<ModItem>(ModCompatibility.Crossmod.Name, "GaleForce").UpdateAccessory(player, hideVisual);
                    ModContent.Find<ModItem>(ModCompatibility.Crossmod.Name, "ElementsForce").UpdateAccessory(player, hideVisual);
                    ModContent.Find<ModItem>(ModCompatibility.Crossmod.Name, "TitanHeartEnchant").UpdateAccessory(player, hideVisual);
                    ModContent.Find<ModItem>(ModCompatibility.Crossmod.Name, "WulfrumEnchant").UpdateAccessory(player, hideVisual);
                }
            }
            if (Item.type == ModContent.ItemType<EternitySoul>())
            {
                if (ModLoader.TryGetMod("Redemption", out Mod Redemption) && ShtunConfig.Instance.Redemption)
                {
                    //ModContent.Find<ModItem>(((ModType)this).Mod.Name, "RedemptionSoul").UpdateAccessory(player, false);
                }

                if (ModLoader.TryGetMod("SacredTools", out Mod SoA) && ShtunConfig.Instance.SacredTools)
                {
                    ModContent.Find<ModItem>(((ModType)this).Mod.Name, "SoASoul").UpdateAccessory(player, false);
                }

                if (ModLoader.TryGetMod("CalamityMod", out Mod kal) && ModLoader.TryGetMod("FargowiltasCrossmod", out Mod FargoIhateYou))
                {
                    ModContent.Find<ModItem>(((ModType)this).Mod.Name, "CalamitySoul").UpdateAccessory(player, false);
                }

                if (ModLoader.TryGetMod("ThoriumMod", out Mod tor) && ShtunConfig.Instance.Thorium)
                {
                    ModContent.Find<ModItem>(((ModType)this).Mod.Name, "ThoriumSoul").UpdateAccessory(player, false);
                }
            }
        }
    }
}