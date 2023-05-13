using Dapper;
using FsCodeAplication.Repositories.Abstractions.Entities;
using FsCodeDomain.Entities;
using Microsoft.Data.SqlClient;

namespace FsCodeAplication.Repositories.Implementations.Entities
{
    public class ReminderRepository : IReminderRepository
    {
        public async Task<IEnumerable<Reminder>> GetAllReminders()
        {
            var query = "SELECT *FROM Reminders";
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                var entities = await connection.QueryAsync<Reminder>(query);
                return entities;
            }
        }

        public async Task<Reminder> GetReminder(int id)
        {
            var query = $"SELECT *FROM Reminders Where Id={id}";
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                var entity = await connection.QueryFirstOrDefaultAsync<Reminder>(query);
                return entity;
            }
        }

        public async Task<IEnumerable<Reminder>> GetActiveReminders()
        {
            var query = $"SELECT *FROM Reminders Where IsActive={1}";
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                var entities = connection.Query<Reminder>(query);
                return entities;
            }
        }
    }
}
