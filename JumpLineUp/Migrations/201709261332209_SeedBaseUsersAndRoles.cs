namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBaseUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'54aab082-fee6-49e6-9caa-23745efd252b', N'guest@blcsne.com', 0, N'AOMBZT7UAN79RJ0oYdc3au9VIv4aKOO1CScY1r1iaKEvBn8iUvQR/66Iyhc6ufor0w==', N'c31cde86-bfff-4796-9f13-fc426201231d', NULL, 0, 0, NULL, 1, 0, N'guest@blcsne.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'admin@blcsne.com', 0, N'APCi/xeuBdFDfJ+I4MYW/+8D18g0nw09Rh0ru8zmWxXRcki+gtW+mjrY/nG+eneomw==', N'6d6ab273-835a-4d01-8fcc-0df1c550251e', NULL, 0, 0, NULL, 1, 0, N'admin@blcsne.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'314149b2-458b-4aa2-a38c-da1753a5e203', N'CanManageBlcsOffice')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1be3a063-e772-4695-9a6e-4d884887666a', N'CanManageCfsWorkers')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a5717e69-dc21-482b-97ba-d05133e5c68e', N'CanManageFosterParents')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2f6f6f1a-cc65-46f5-bb9b-aa555bdf11ac', N'CanManageGuardians')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'28d49ba2-6b9b-4c98-85c5-3226c55c7c81', N'CanManageRestraintTypes')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'dc7757d3-d947-4e12-ba8b-4de5e4da1cf8', N'CanManageUsers')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b83e61c8-61a5-4c35-a055-bc84bcdfd92b', N'CanManageYouth')
 
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'1be3a063-e772-4695-9a6e-4d884887666a')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'28d49ba2-6b9b-4c98-85c5-3226c55c7c81')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'2f6f6f1a-cc65-46f5-bb9b-aa555bdf11ac')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'314149b2-458b-4aa2-a38c-da1753a5e203')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'a5717e69-dc21-482b-97ba-d05133e5c68e')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'b83e61c8-61a5-4c35-a055-bc84bcdfd92b')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'dc7757d3-d947-4e12-ba8b-4de5e4da1cf8')

             
            ");
        }

        public override void Down()
        {
        }
    }
}
