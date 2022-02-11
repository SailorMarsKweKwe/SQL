using System;
using System.Data.SQLite;
using Xunit;

namespace SQL
{
    public class UnitTest1
    {
        [Fact]
        public void ArmsByCastleTest()
        {

            SQLiteConnection westeros = SQL_Helper.OpenConnectionDB(@"Data Source =/Users/innasukhina/RiderProjects/SQL_Friday/SQL/westeros.db");
            SQLiteCommand cmd = SQL_Helper.ManageDB("SELECT arms FROM families WHERE castle = (SELECT castle FROM heroes WHERE"+
                " hero_name = 'Cercei Lannister' AND hero_id = (SELECT hero_id FROM westeros WHERE kingdom = 'Kingdom of the Rock'"+
                " AND famous_thing = 'Lannister Gold'))", westeros);
            var actual = cmd.ExecuteScalar();
            Assert.Equal("The Lion rampant", actual);
            SQL_Helper.CloseConnectionDB(westeros);
        }
        [Fact]
        public void FamilyIdByHeroNameTest()
        {

            SQLiteConnection westeros = SQL_Helper.OpenConnectionDB(@"Data Source =/Users/innasukhina/RiderProjects/SQL_Friday/SQL/westeros.db");
            SQLiteCommand cmd = SQL_Helper.ManageDB("SELECT family_id FROM westeros WHERE hero_id = (SELECT hero_id FROM" +
                " heroes WHERE hero_name= 'Robert Baratheon' AND castle='Storms End')", westeros);
            var actual = cmd.ExecuteScalar();
            Assert.Equal(7, Convert.ToInt64(actual));
            SQL_Helper.CloseConnectionDB(westeros);
        }

        [Fact]
        public void HeroKingdomByCastleTest()
        {

            SQLiteConnection westeros = SQL_Helper.OpenConnectionDB(@"Data Source =/Users/innasukhina/RiderProjects/SQL_Friday/SQL/westeros.db");
            SQLiteCommand cmd = SQL_Helper.ManageDB("SELECT kingdom FROM westeros WHERE hero_id = (SELECT hero_id FROM" +
                " heroes WHERE castle='Highgarden' AND hero_name= 'Loras Tyrell')", westeros);
            var actual = cmd.ExecuteScalar();
            Assert.Equal("Kingdom of the Reach", actual);
            SQL_Helper.CloseConnectionDB(westeros);
        }
        [Fact]
        public void FirstVictimByHeroIdTest()
        {

            SQLiteConnection westeros = SQL_Helper.OpenConnectionDB(@"Data Source =/Users/innasukhina/RiderProjects/SQL_Friday/SQL/westeros.db");
            SQLiteCommand cmd = SQL_Helper.ManageDB("SELECT first_victim FROM heroes WHERE hero_id=(SELECT hero_id" +
                " FROM westeros WHERE family_id=(SELECT family_id FROM families WHERE family_name " +
                "= 'Baratheon' AND castle = 'Storms End') AND kingdom = 'Kingdom of the Stormlands') ", westeros);
            var actual = cmd.ExecuteScalar();
            Assert.Equal("Rhaegar Targaryen", actual);
            SQL_Helper.CloseConnectionDB(westeros);
        }
        [Fact]
        public void CastleByFamilyIdTest()
        {

            SQLiteConnection westeros = SQL_Helper.OpenConnectionDB(@"Data Source =/Users/innasukhina/RiderProjects/SQL_Friday/SQL/westeros.db");
            SQLiteCommand cmd = SQL_Helper.ManageDB("SELECT castle FROM families WHERE family_id=(SELECT family_id" +
                " FROM westeros WHERE famous_thing= 'Dornish wine' AND hero_id=(SELECT hero_id FROM heroes WHERE hero_name"+
                " = 'Oberyn Martell' AND first_victim = 'knight of Kings Landing ') AND kingdom = 'Principality of Dorne') ", westeros);
            var actual = cmd.ExecuteScalar();
            Assert.Equal("Sunspear", actual);
            SQL_Helper.CloseConnectionDB(westeros);
        }
    }
}
