using System;
using System.Data.Linq.Mapping;

namespace ClouDiversity
{

    [Table]
    public class Event
    {

        [Column(IsPrimaryKey = true)]
        public int EventID
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public string EventName
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string EventPlace
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public DateTime DateFrom
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public DateTime DateTo
        {
            get;
            set;
        }
    }
}