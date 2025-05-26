using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ssm.Core;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using FargowiltasSouls.Core.AccessoryEffectSystem;
using ssm.Content.SoulToggles;
using Redemption.Items.Accessories.PreHM;
using Redemption.Globals.Player;
using Redemption.Items.Accessories.HM;
using Redemption.Items.Armor.PostML.Xenium;
using Redemption.Items.Weapons.PostML.Summon;
using CalamityMod.Buffs.Summon;
using CalamityMod.Projectiles.Summon;
using CalamityMod;
using static ssm.Calamity.Enchantments.PlaguebringerEnchant;
using Terraria.DataStructures;
using Redemption.Buffs.Minions;
using Redemption.Projectiles.Minions;

namespace ssm.Redemption.Enchantments
{
    [ExtendsFromMod(ModCompatibility.Redemption.Name)]
    [JITWhenModsEnabled(ModCompatibility.Redemption.Name)]
    public class XeniumEnchant : BaseEnchant
    {
        public class XeniumConcoction : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<AdvancementForceHeader>();

            public override int ToggleItemType => ModContent.ItemType<XeniumEnchant>();
        }

        public class XeniumShield : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<AdvancementForceHeader>();

            public override int ToggleItemType => ModContent.ItemType<XeniumEnchant>();
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ShtunConfig.Instance.Redemption;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            Item.rare = 10;
            Item.value = 40000;
        }

        public override Color nameColor => new Color(143, 227, 84);

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.AddEffect<XeniumConcoction>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.Redemption.Name, "BeelzebubConcoction").UpdateAccessory(player, hideVisual: true);
            }
            if (player.AddEffect<XeniumDroneEffect>(Item))
            {
                if (player.whoAmI == Main.myPlayer)
                {
                    IEntitySource source_ItemUse = player.GetSource_ItemUse(base.Item);
                    if (player.FindBuffIndex(ModContent.BuffType<XeniumTurretBuff>()) == -1)
                    {
                        player.AddBuff(ModContent.BuffType<XeniumTurretBuff>(), 3600);
                    }

                    if (player.ownedProjectileCounts[ModContent.ProjectileType<XeniumTurret>()] < 1)
                    {
                        int num = player.ApplyArmorAccDamageBonusesTo(140f);
                        Projectile.NewProjectileDirect(source_ItemUse, player.Center, -Vector2.UnitY, ModContent.ProjectileType<XeniumTurret>(), num, 0f, player.whoAmI).originalDamage = num;
                    }
                }
            }
            if (player.AddEffect<XeniumShield>(base.Item))
            {
                ModContent.Find<ModItem>(ModCompatibility.Redemption.Name, "InfectionShield").UpdateAccessory(player, hideVisual: false);
            }
            player.GetModPlayer<EnergyPlayer>().energyRegen += 20;
        }
        public class XeniumDroneEffect : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<AdvancementForceHeader>();

            public override int ToggleItemType => ModContent.ItemType<XeniumEnchant>();
        }
        public class PureIronCross : AccessoryEffect
        {
            public override Header ToggleHeader => Header.GetHeader<AdvancementForceHeader>();

            public override int ToggleItemType => ModContent.ItemType<XeniumEnchant>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = this.CreateRecipe();

            recipe.AddIngredient<XeniumVisor>();
            recipe.AddIngredient<XeniumBreastplate>();
            recipe.AddIngredient<XeniumLeggings>();
            recipe.AddIngredient<XeniumDrone>();
            recipe.AddIngredient<InfectionShield>();
            recipe.AddIngredient<BeelzebubConcoction>();
            recipe.AddTile(412);

            recipe.Register();
        }
    }
}
