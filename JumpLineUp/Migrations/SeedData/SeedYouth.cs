using System;
using System.Data.Entity.Migrations;
using JumpLineUp.Models;

namespace JumpLineUp.Migrations.SeedData
{
    public static class SeedYouth
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            context.Youths.AddOrUpdate(x => x.Id,
                new Youth() {  Id = 1, FirstName = "LittleBabyGirl", LastName = "Nelson", RestraintTypeId = RestraintNames.HighBackBoosterSeat, BirthDate = new DateTime(2010,1,10), IsEnabled = true },
                new Youth() {  Id = 2, FirstName = "Emily", LastName = "Crouch", RestraintTypeId = RestraintNames.HighBackBoosterSeat, BirthDate = new DateTime(2011,2,11), IsEnabled = true },
                new Youth() {  Id = 3, FirstName = "Matt", LastName = "Crouch", RestraintTypeId = RestraintNames.HighBackBoosterSeat, BirthDate = new DateTime(2012,3,12), IsEnabled = true },
                new Youth() {  Id = 4, FirstName = "Kaelin", LastName = "Gulizia", RestraintTypeId = RestraintNames.HighBackBoosterSeat, BirthDate = new DateTime(2013,4,13), IsEnabled = true },
                new Youth() {  Id = 5, FirstName = "Jack", LastName = "Nelson", RestraintTypeId = RestraintNames.HighBackBoosterSeat, BirthDate = new DateTime(2014,5,14), IsEnabled = true },
                new Youth() {  Id = 6, FirstName = "McKinzye", LastName = "Hahn", RestraintTypeId = RestraintNames.HighBackBoosterSeat, BirthDate = new DateTime(2015,6,15), IsEnabled = true },
                new Youth() {  Id = 7, FirstName = "Payton", LastName = "Betzold", RestraintTypeId = RestraintNames.FivePointRearFacing, BirthDate = new DateTime(2016,7,16), IsEnabled = true },
                new Youth() {  Id = 8, FirstName = "Paige", LastName = "Betzold", RestraintTypeId = RestraintNames.FivePointRearFacing, BirthDate = new DateTime(2017,8,17), IsEnabled = true },
                new Youth() {  Id = 9, FirstName = "Jenna", LastName = "Thompson", RestraintTypeId = RestraintNames.BoosterSeat, BirthDate = new DateTime(2009,9,18), IsEnabled = true },
                new Youth() { Id = 10, FirstName = "Josh", LastName = "Thompson", RestraintTypeId = RestraintNames.BoosterSeat, BirthDate = new DateTime(2008,10,19), IsEnabled = true }

            );
            context.SaveChanges();

        }

    }
}