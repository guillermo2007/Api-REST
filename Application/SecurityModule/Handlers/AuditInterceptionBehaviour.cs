

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Application.SecurityModule.Handlers
{
    public class AuditInterceptionBehaviour : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input,
            GetNextInterceptionBehaviorDelegate getNext)
        {
            Debug.WriteLine("Begin");

            var message =
                string.Format(
                    "Assembly : {0}.{1}Location : {2}.{3}Calling Class : {4}",
                    input.MethodBase.DeclaringType.Assembly.FullName,
                    Environment.NewLine,
                    input.MethodBase.DeclaringType.Assembly.Location,
                    Environment.NewLine,
                    input.MethodBase.DeclaringType.FullName
                    );

            //Just take the first parameter
            WriteToLog(string.Format("{0} is called with parameters '{1}'",
                input.MethodBase.Name,
                input.Inputs[0]));

            WriteToLog(message);

            var result = getNext().Invoke(input, getNext);
            WriteToLog(string.Format("{0} is ended", input.MethodBase.Name));
            Debug.WriteLine("End");
            return result;
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private void WriteToLog(string message)
        {
            var eventLog = new EventLog("");
            eventLog.Source = "Interception";
            eventLog.WriteEntry(string.Format("{0}", message, EventLogEntryType.Information));
        }

        IEnumerable<Type> IInterceptionBehavior.GetRequiredInterfaces()
        {
            throw new NotImplementedException();
        }
    }
}
