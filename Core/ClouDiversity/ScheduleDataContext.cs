
using System.Data.Linq;

namespace ClouDiversity
{
    public class ScheduleDataContext : DataContext
    {
        public ScheduleDataContext(string connectionString)
            : base(connectionString)
        {
        }
        public Table<Event> Events
        {
            get
            {
                return this.GetTable<Event>();
            }
        }
    }
}
