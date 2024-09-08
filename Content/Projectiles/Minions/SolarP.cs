using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ssm;

namespace ssm.Content.Projectiles.Minions
{
    public class SolarP : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.width = 100;
            Projectile.height = 100;
            Projectile.timeLeft *= 5;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (player.active && !player.dead && player.GetModPlayer<ShtunPlayer>().CelestialPower)
                Projectile.timeLeft = 2;
            Vector2 playerVel = player.position - player.oldPosition;
            Projectile.position += playerVel;
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 0f)
            {
                Vector2 home = player.Center;
                home.X -= 600f;
                home.Y -= 50f;
                Vector2 distance = home - Projectile.Center;
                float range = distance.Length();
                distance.Normalize();
                if (Projectile.ai[0] == 0f)
                {
                    if (range > 15f)
                    {
                        Projectile.ai[0] = -1f; //if in fast mode, stay fast until back in range
                        if (range > 1300f)
                        {
                            Projectile.Kill();
                            return;
                        }
                    }
                    else
                    {
                        Projectile.velocity.Normalize();
                        Projectile.velocity *= 3f + Main.rand.NextFloat(3f);
                        Projectile.netUpdate = true;
                    }
                }
                else
                {
                    distance /= 8f;
                }
                if (range > 120f) //switch to fast return mode
                {
                    Projectile.ai[0] = -1f;
                    Projectile.netUpdate = true;
                }
                Projectile.velocity += distance;
                if (range > 30f)
                    Projectile.velocity *= 0.96f;

                if (Projectile.ai[0] > 90f) //attack nearby enemy
                {
                    Projectile.ai[0] = 20f;
                    NPC npc = ShtunUtils.NPCExists(ShtunUtils.FindClosestHostileNPCPrioritizingMinionFocus(Projectile, 400));
                    if (npc != null)
                    {
                        Projectile.velocity = npc.Center - Projectile.Center;
                        Projectile.velocity.Normalize();
                        Projectile.velocity *= 16f;
                        Projectile.velocity += npc.velocity / 2f;
                        Projectile.velocity -= playerVel / 2f;
                        Projectile.ai[0] *= -1f;
                    }
                    Projectile.netUpdate = true;
                }
            }

            Vector2 angle = player.Center - Projectile.Center;
            angle.X += 200f;
            angle.Y = 480f;
            Projectile.rotation = (float)Math.Atan2(angle.Y, angle.X) + (float)Math.PI / 2f;
        }

       

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D13 = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value;
            int num156 = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value.Height / Main.projFrames[Projectile.type]; //ypos of lower right corner of sprite to draw
            int y3 = num156 * Projectile.frame; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;
            Main.EntitySpriteDraw(texture2D13, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Projectile.GetAlpha(lightColor), Projectile.rotation, origin2, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}