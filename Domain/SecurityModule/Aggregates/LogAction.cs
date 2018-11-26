using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SecurityModule.Aggregates
{
    public class LogAction : EntityBase
    {
        public LogAction()
        {
            GenerateNewId();
            DateTimeAction = DateTime.Now;
        }

        public LogAction(string operationName, string scopeType, string data) : this()
        {
            OperationName = operationName;
            ScopeType = scopeType;
            Data = data;
        }

        public DateTime DateTimeAction { get; private set; }
        public string OperationName { get; set; }
        public string ScopeType { get; set;  }
        public string Data { get; set; }

    }
}
