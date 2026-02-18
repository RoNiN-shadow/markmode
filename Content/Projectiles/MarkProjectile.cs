using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace MarkMode.Content.Projectiles
{
    public class MarkProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults() {
			Projectile.width = 8; // The width of projectile hitbox
			Projectile.height = 8; // The height of projectile hitbox
			Projectile.aiStyle = -1; // The ai style of the projectile, please reference the source code of Terraria
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.DamageType = DamageClass.Ranged; // Is the projectile shoot by a ranged weapon?
			Projectile.penetrate = 5; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.tileCollide = true; // Can the projectile collide with tiles?
			Projectile.extraUpdates = 1; // Set to above 0 if you want the projectile to update multiple time in a frame

      Projectile.velocity *= 1.1f;


			AIType = ProjectileID.Bullet; // Act exactly like default Bullet
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);

                SoundEngine.PlaySound(SoundID.Tink, Projectile.position);

                if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            return false;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);

            for (int k = Projectile.oldPos.Length - 1; k > 0; k--)
            {
                Vector2 drawPos = drawOrigin + Projectile.oldPos[k] + new Vector2(0f, Projectile.gfxOffY) + Main.screenPosition;
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);

                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);

            }
            return true;
        }
        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Tink, Projectile.position);
            
            int dustCount = 10;
            for(int i =0; i< dustCount; i++)
            {
              Dust.NewDust(Projectile.position, Projectile.width + 3, Projectile.height + 3, DustID.Frost);
            }

        }
        public override void AI()
        {
          int tileX = (int)(Projectile.Center.X / 16f);
          int tileY = (int)(Projectile.Center.Y / 16f);

          if(WorldGen.InWorld(tileX, tileY))
          {
            Tile tile = Main.tile[tileX, tileY];

            if(tile != null && tile.HasTile && Main.tileSolid[tile.TileType])
            {
              Player player = Main.player[Projectile.owner];
              Projectile.position = player.position;
            }
          }
          Lighting.AddLight(Projectile.Center, 0.0f, 0.5f, 1.0f);

          if(Main.rand.NextBool(4))
          {
            Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.ManaRegeneration, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
          }

        }
    }
}
