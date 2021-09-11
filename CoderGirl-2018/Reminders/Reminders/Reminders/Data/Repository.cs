using Reminders.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reminders.Data
{
    /// <summary>
    ///     Interface for reading and writing data.
    /// </summary>
    public class Repository
    {
        private readonly SQLiteAsyncConnection _connection;

        /// <summary>
        ///     Connect to the database and create and missing tables.
        /// </summary>
        /// <param name="path">Path to the file, which is different on every platform.</param>
        public Repository(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Reminder>().Wait();
        }

        /// <summary>
        ///     Delete a reminder from the database.
        /// </summary>
        /// <param name="reminder">Reminder to delete.</param>
        public async Task ReminderDeleteAsync(Reminder reminder)
        {
            var result = await _connection.DeleteAsync(reminder).ConfigureAwait(false);
        }

        /// <summary>
        ///     Get all the reminders from the database.
        /// </summary>
        /// <returns>A list of all reminders.</returns>
        public async Task<List<Reminder>> ReminderGetAllAsync()
        {
            return await _connection.Table<Reminder>().ToListAsync();
        }

        /// <summary>
        ///     Save a new reminder to the database.
        /// </summary>
        /// <param name="reminder">New reminder.</param>
        public async Task ReminderSaveAsync(Reminder reminder)
        {
            // Do not allow saving an invalid record.
            if (!reminder.IsValid()) throw new ApplicationException("Reminder is not valid.");

            // Either insert a new reminder or update an existing one.
            await _connection.InsertOrReplaceAsync(reminder).ConfigureAwait(false);
        }
    }
}