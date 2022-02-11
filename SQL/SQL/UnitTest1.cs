using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Xunit;

namespace SQL
{
    public class UnitTest1
    {
        [Fact]
        public void SimpleTest1()
        {

            SQLiteConnection westeros = SQL_Helper.OpenConnectionDB(@"Data Source =/Users/innasukhina/Documents/westeros.db");
            SQLiteCommand cmd = SQL_Helper.ManageDB("SELECT family_name FROM families WHERE family_id= 4", westeros);
            var actual = cmd.ExecuteScalar();
            Assert.Equal("Arryn", actual);
            SQL_Helper.CloseConnectionDB(westeros);
        }
        [Fact]
        public void FamilyIdByHeroNameTest()
        {

            SQLiteConnection westeros = SQL_Helper.OpenConnectionDB(@"Data Source =/Users/innasukhina/Documents/westeros.db");
            SQLiteCommand cmd = SQL_Helper.ManageDB("SELECT family_id FROM westeros WHERE hero_id = (SELECT hero_id FROM" +
                                                    " heroes WHERE hero_name= 'Robert Baratheon' AND castle='Storms End')", westeros);
            var actual = cmd.ExecuteScalar();
            Assert.Equal(7, Convert.ToInt64(actual));
            SQL_Helper.CloseConnectionDB(westeros);
        }

        [Fact]
        public void HeroKindomByCastleTest()
        {

            SQLiteConnection westeros = SQL_Helper.OpenConnectionDB(@"Data Source =/Users/innasukhina/Documents/westeros.db");
            SQLiteCommand cmd = SQL_Helper.ManageDB("SELECT kingdom FROM westeros WHERE hero_id = (SELECT hero_id FROM" +
                                                    " heroes WHERE castle='Highgarden' AND hero_name= 'Loras Tyrell')", westeros);
            var actual = cmd.ExecuteScalar();
            Assert.Equal("Kingdom of the Reach", actual);
            SQL_Helper.CloseConnectionDB(westeros);
        }
       
    }
}
