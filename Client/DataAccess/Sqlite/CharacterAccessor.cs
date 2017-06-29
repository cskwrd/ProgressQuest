using Client.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;

namespace Client.DataAccess.Sqlite
{
    public class CharacterAccessor : ICharacterAccessor
    {
        public List<CharacterSummary> GetSavedCharacterSummaries()
        {
            List<CharacterSummary> summaries = new List<CharacterSummary>();
            using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["ProgressQuestConnectionString"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "SELECT Name, Race, Class, Level FROM Characters";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            summaries.Add(new CharacterSummary
                            {
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Race = reader.GetFieldValue<Races>(reader.GetOrdinal("Race")),
                                Class = reader.GetFieldValue<Classes>(reader.GetOrdinal("Class")),
                                Level = reader.GetInt32(reader.GetOrdinal("Level")),
                            });
                        }
                    }
                }
            }
            return summaries;
        }

        public void Save(Character character)
        {
            using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["ProgressQuestConnectionString"].ConnectionString))
            {
                conn.Open();
                long? statsId = null;
                // TODO : trace stats save start
                SQLiteTransaction insertStatsTransaction = conn.BeginTransaction();
                using (var cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO CharacterStats (Strength,Constitution,Dexterity,Intelligence,Wisdom,Charisma,HpMax,MpMax) VALUES (@str,@con,@dex,@int,@wis,@cha,@hpMax,@mpMax)";
                    cmd.Parameters.AddWithValue("@str", character.Stats.Strength);
                    cmd.Parameters.AddWithValue("@con", character.Stats.Constitution);
                    cmd.Parameters.AddWithValue("@dex", character.Stats.Dexterity);
                    cmd.Parameters.AddWithValue("@int", character.Stats.Intelligence);
                    cmd.Parameters.AddWithValue("@wis", character.Stats.Wisdom);
                    cmd.Parameters.AddWithValue("@cha", character.Stats.Charisma);
                    cmd.Parameters.AddWithValue("@hpMax", character.Stats.HpMax);
                    cmd.Parameters.AddWithValue("@mpMax", character.Stats.MpMax);
                    cmd.ExecuteNonQuery();
                    statsId = conn.LastInsertRowId;
                }
                // TODO : trace stats save end

                // TODO : trace character save start
                using (var cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO Characters (Name,Race,Class,CharacterStatsId) VALUES (@name,@race,@class,@statsId)";
                    cmd.Parameters.AddWithValue("@name", character.Name);
                    cmd.Parameters.AddWithValue("@race", character.Race);
                    cmd.Parameters.AddWithValue("@class", character.Class);
                    cmd.Parameters.AddWithValue("@statsId", statsId);
                    cmd.ExecuteNonQuery();
                }
                insertStatsTransaction.Commit();
                // TODO : trace character save end
            }
        }
    }
}
