﻿using Microsoft.Xna.Framework;
using ssm.Core;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ssm.SoA
{
    [ExtendsFromMod(ModCompatibility.SacredTools.Name)]
    [JITWhenModsEnabled(ModCompatibility.SacredTools.Name)]
    public class SoAPlayer : ModPlayer
    {
        //Bismuth Enchant
        public int bismuthEnchant; 
        public int bismuthCrystalStage = 0;
        public int bismuthFormationTimer = 0;
        public const int FormationTime = 300;
        public const int MaxStages = 3;
        public const int MaxDamageAbsorption = 90;
        public int currentDamageAbsorbed = 0;

        //Blazing Brute Enchant
        public int blazingBruteEnchant;
        public bool hasPhoenixBlessing = false;
        public bool phoenixBlessingActive = false;
        public bool hasPhoenixWrath = false;
        public int phoenixWrathCooldown = 0;
        public const int PhoenixWrathCooldownMax = 300;

        //Frosthunter Enchantment
        public int frosthunterEnchant;
        public int frosthunterCooldown = 0;

        //Lapis Enchant
        public int lapisSpeedTimer;
        public int lapisEnchant;

        //Blightbone Enchant
        public int blightboneEnchant;

        //Eerie Enchant
        public int eerieEnchant;

        //Vulkan Reaper Enchant
        public int vulkanReaperEnchant = 0;
        public int vulkanKillCount = 0;
        public int vulkanBuffTimer = 0;
        public float vulkanDamageBonus = 0f;
        public override void ResetEffects()
        {
            vulkanReaperEnchant = 0;
            eerieEnchant = 0;
            blightboneEnchant = 0;
            lapisEnchant = 0;
            frosthunterEnchant = 0;
            bismuthEnchant = 0;
            hasPhoenixBlessing = false;
        }
        public override void UpdateDead()
        {
            phoenixWrathCooldown = 0;
            frosthunterCooldown = 0;
            vulkanDamageBonus = 0f;
            vulkanBuffTimer = 0;
            vulkanKillCount = 0;
            currentDamageAbsorbed = 0;
            bismuthCrystalStage = 0;
            phoenixBlessingActive = false;
            hasPhoenixWrath = false;
            phoenixWrathCooldown = 0;
        }
        public override void PostUpdateEquips()
        {
            if (vulkanBuffTimer > 0)
            {
                vulkanBuffTimer--;
                if (vulkanBuffTimer <= 0)
                {
                    vulkanDamageBonus = 0f;
                    vulkanKillCount = 0;
                }
            }

            if (phoenixWrathCooldown > 0)
            {
                phoenixWrathCooldown--;
            }

            if (frosthunterCooldown > 0)
            {
                frosthunterCooldown--;
            }

            if (lapisSpeedTimer > 0)
            {
                lapisSpeedTimer--;
                if (lapisEnchant > 0)
                {
                    Player.moveSpeed += 0.25f;
                }
            }

            if (bismuthEnchant > 0)
            {
                bismuthFormationTimer++;

                if (bismuthFormationTimer >= FormationTime / MaxStages * (bismuthCrystalStage + 1) && bismuthCrystalStage < MaxStages)
                {
                    bismuthCrystalStage++;
                    currentDamageAbsorbed = 0;
                }
            }
        }

        public void ModifyDamageWithVulkan(ref float damage)
        {
            if (vulkanBuffTimer > 0)
            {
                damage = damage * (1f + vulkanDamageBonus);
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (frosthunterEnchant > 0) 
            {
                bool isCluster = frosthunterCooldown <= 0;

                CreateFrostExplosion(target.Center, isCluster);

                if (isCluster)
                {
                    frosthunterCooldown = 120;
                }
            }
            if (blightboneEnchant == 1 && IsBoneWeapon(proj))
            {
                target.AddBuff(BuffID.OnFire, 180);
            }

            if (blightboneEnchant == 2 && IsBoneWeapon(proj))
            {
                target.AddBuff(BuffID.OnFire, 360);
            }
        }

        private bool IsBoneWeapon(Projectile proj)
        {
            //...
            return proj.type == ProjectileID.Bone ||
                   proj.type == ProjectileID.BoneJavelin ||
                   proj.type == ProjectileID.BoneGloveProj;
        }

        public void CreateFrostExplosion(Vector2 pos, bool isCluster)
        {
            float radius = isCluster ? 100f : 150f;
            int damage = (int)(Player.GetDamage(DamageClass.Generic).ApplyTo(30));
            float knockback = 3f;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly && npc.Distance(pos) <= radius)
                {
                    Player.ApplyDamageToNPC(npc, damage, knockback, Player.direction);
                    npc.AddBuff(frosthunterEnchant > 1 ? BuffID.Frostburn2 : BuffID.Frostburn, 180);
                }
            }

            for (int i = 0; i < 15; i++)
            {
                Dust sust = Dust.NewDustPerfect(pos, DustID.Ice, Main.rand.NextVector2Circular(5, 5) * 3f);
                sust.noGravity = true;
                sust.scale = 1.5f;
            }

            if (isCluster)
            {
                for (int i = 0; i < 4; i++)
                {
                    Vector2 clusterPos = pos + Main.rand.NextVector2Circular(radius * 0.5f, radius * 0.5f);
                    CreateSmallFrostExplosion(pos);
                }
            }
        }

        public void CreateSmallFrostExplosion(Vector2 pos)
        {
            float radius = 60f;
            int damage = (int)(Player.GetDamage(DamageClass.Generic).ApplyTo(15));
            float knockback = 1.5f;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly && npc.Distance(pos) <= radius)
                {
                    Player.ApplyDamageToNPC(npc, damage, knockback, Player.direction);
                    npc.AddBuff(frosthunterEnchant > 1 ? BuffID.Frostburn2 : BuffID.Frostburn, 180);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                Dust sust = Dust.NewDustPerfect(pos, DustID.Ice, Main.rand.NextVector2Circular(5, 5) * 3f);
                sust.noGravity = true;
                sust.scale = 1.5f;
            }

            if (frosthunterEnchant > 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    CreateMiniFrostExplosion(pos);
                }
            }
        }

        public void CreateMiniFrostExplosion(Vector2 pos)
        {
            float radius = 30f;
            int damage = (int)(Player.GetDamage(DamageClass.Generic).ApplyTo(10));
            float knockback = 1f;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly && npc.Distance(pos) <= radius)
                {
                    Player.ApplyDamageToNPC(npc, damage, knockback, Player.direction);
                    npc.AddBuff(BuffID.Frostburn2, 180);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                Dust sust = Dust.NewDustPerfect(pos, DustID.Ice, Main.rand.NextVector2Circular(5, 5) * 3f);
                sust.noGravity = true;
                sust.scale = 1f;
            }
        }

        public override void OnHurt(Player.HurtInfo info)
        {
            if (lapisEnchant > 1 && !Player.dead)
            {
                lapisSpeedTimer = 120;
            }
        }
        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            if (blazingBruteEnchant > 1)
            {
                if (phoenixBlessingActive && !hasPhoenixWrath && modifiers.FinalDamage.Flat >= 200)
                {
                    hasPhoenixWrath = true;
                }
            }

            if (bismuthEnchant > 0)
            {
                if (bismuthCrystalStage > 0 && currentDamageAbsorbed < MaxDamageAbsorption)
                {
                    float damageReduction = 0f;

                    if (ShtunUtils.AnyBossAlive())
                    {
                        damageReduction = bismuthEnchant > 1 ? 0.05f : 0.02f;
                    }
                    else
                    {
                        damageReduction = bismuthEnchant > 1 ? 0.1f : 0.05f;
                    }

                    float damageToAbsorb = modifiers.FinalDamage.Flat * damageReduction;

                    if (currentDamageAbsorbed + damageToAbsorb > MaxDamageAbsorption)
                    {
                        damageToAbsorb = MaxDamageAbsorption - currentDamageAbsorbed;
                    }

                    if (damageToAbsorb > 0)
                    {
                        modifiers.FinalDamage -= damageToAbsorb;
                        currentDamageAbsorbed += (int)damageToAbsorb;
                    }
                }
            }
        }
    }
}
