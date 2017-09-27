namespace JumpLineUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[CellularCarriers] ([CarrierName], [CarrierExtension]) VALUES ('Verizon', 'vtext.net')");

            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [CellularCarriersId], [CellNumber]) VALUES (N'54aab082-fee6-49e6-9caa-23745efd252b', N'guest@blcsne.com', 0, N'AOMBZT7UAN79RJ0oYdc3au9VIv4aKOO1CScY1r1iaKEvBn8iUvQR/66Iyhc6ufor0w==', N'c31cde86-bfff-4796-9f13-fc426201231d', NULL, 0, 0, NULL, 1, 0, N'guest@blcsne.com', 1,'4021231234')");
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [CellularCarriersId], [CellNumber]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'admin@blcsne.com', 0, N'APCi/xeuBdFDfJ+I4MYW/+8D18g0nw09Rh0ru8zmWxXRcki+gtW+mjrY/nG+eneomw==', N'6d6ab273-835a-4d01-8fcc-0df1c550251e', NULL, 0, 0, NULL, 1, 0, N'admin@blcsne.com', 1,'4021231234')");

            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'314149b2-458b-4aa2-a38c-da1753a5e203', N'CanManageBlcsOffice')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1be3a063-e772-4695-9a6e-4d884887666a', N'CanManageCfsWorkers')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a5717e69-dc21-482b-97ba-d05133e5c68e', N'CanManageFosterParents')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2f6f6f1a-cc65-46f5-bb9b-aa555bdf11ac', N'CanManageGuardians')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'28d49ba2-6b9b-4c98-85c5-3226c55c7c81', N'CanManageRestraintTypes')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'dc7757d3-d947-4e12-ba8b-4de5e4da1cf8', N'CanManageUsers')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b83e61c8-61a5-4c35-a055-bc84bcdfd92b', N'CanManageYouth')");
            

            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'1be3a063-e772-4695-9a6e-4d884887666a')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'28d49ba2-6b9b-4c98-85c5-3226c55c7c81')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'2f6f6f1a-cc65-46f5-bb9b-aa555bdf11ac')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'314149b2-458b-4aa2-a38c-da1753a5e203')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'a5717e69-dc21-482b-97ba-d05133e5c68e')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'b83e61c8-61a5-4c35-a055-bc84bcdfd92b')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fb6939a1-28a1-4799-a930-40a91bff5a36', N'dc7757d3-d947-4e12-ba8b-4de5e4da1cf8')");

        }
        
        public override void Down()
        {
        }
    }
}
