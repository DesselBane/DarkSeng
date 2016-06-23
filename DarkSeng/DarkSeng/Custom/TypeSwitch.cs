using System;
using System.Linq;

namespace DarkSeng.Custom
{
    public class TypeSwitch
    {
        #region Inner Classes

        public class CaseInfo
        {
            public bool IsDefault { get; set; }
            public Type Target { get; set; }
            public Action<object> Action { get; set; }
        }

        #endregion Inner Classes

        #region Public

        /// <summary>
        /// Like the switch Statement
        /// </summary>
        /// <param name="source">Like switch('source')</param>
        /// <param name="cases">Your case statements.</param>
        public static void Do(object source, params CaseInfo[] cases)
        {
            //If source is null trigger default, if no default exit
            if (source == null)
            {
                var defaultOp = cases.FirstOrDefault(x => x.IsDefault);
                if (defaultOp.IsDefault)
                {
                    defaultOp.Action(source);
                }
                return;
            }


            var type = source.GetType();

            CaseInfo defaultOption = null;
            bool caseHit = false;

            foreach (var entry in cases)
            {
                if (entry.IsDefault)
                    defaultOption = entry;

                if (entry.Target == type)
                {
                    caseHit = true;
                    entry.Action(source);
                    break;
                }
            }

            if (!caseHit && defaultOption != null)
            {
                defaultOption.Action(source);
            }
        }

        /// <summary>
        /// This is a Case statment.
        /// </summary>
        /// <typeparam name="T">If T matches source.getType() this statement will be executed.</typeparam>
        /// <param name="action">The action to be executed</param>
        public static CaseInfo Case<T>(Action action)
        {
            return new CaseInfo()
            {
                Action = x => action(),
                Target = typeof(T)
            };
        }

        /// <summary>
        /// This is a Case statment.
        /// </summary>
        /// <typeparam name="T">If T matches source.getType() this statement will be executed.</typeparam>
        /// <param name="action">The action to be executed</param>
        public static CaseInfo Case<T>(Action<T> action)
        {
            return new CaseInfo()
            {
                Action = (x) => action((T)x),
                Target = typeof(T)
            };
        }

        /// <summary>
        /// This Action will be executed if all other statements do not apply false
        /// </summary>
        /// <param name="action">Action delegate to be executed</param>
        public static CaseInfo Default(Action action)
        {
            return new CaseInfo()
            {
                Action = x => action(),
                IsDefault = true
            };
        }

        #endregion Public

    }
}
