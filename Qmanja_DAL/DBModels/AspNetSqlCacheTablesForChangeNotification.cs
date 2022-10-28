using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class AspNetSqlCacheTablesForChangeNotification
    {
        public string TableName { get; set; }
        public DateTime NotificationCreated { get; set; }
        public int ChangeId { get; set; }
    }
}
