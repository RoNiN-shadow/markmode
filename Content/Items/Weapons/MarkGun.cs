using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using MarkMode.Content.Projectiles;

namespace MarkMode.Content.Items.Weapons
{
    public class MarkGun : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 32;
            Item.scale = 1f; 

            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            Item.UseSound = new SoundStyle("MarkMode/Assets/Sounds/Items/Guns/MarkGun/MarkGun", 2);

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 20;
            Item.knockBack = 5f;
            Item.noMelee = true;


            Item.shoot = ModContent.ProjectileType<MarkProjectile>();
            Item.shootSpeed = 10f;

            Item.useAmmo = AmmoID.Bullet;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, -2f);
            
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<MarkProjectile>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberOfProjectiles = 5 + Main.rand.Next(9);

            float rotation = MathHelper.ToRadians(45);

            position += Vector2.Normalize(velocity) * 45f;
            for (int i = 0; i < numberOfProjectiles; i++)
            {
                float t = i / (numberOfProjectiles - 1);
                Vector2 portuedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, t));
                Projectile.NewProjectile(source, position, portuedSpeed, type, damage, knockback, player.whoAmI);
            }
            player.position -= Vector2.Normalize(velocity) * 4f;

            return false;
        }

    }
}