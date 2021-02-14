using System;
using System.Linq;

namespace Infra.Helpers
{
    public class ValidationHelper
    {
        public static string GetRuleSets<T>(params T[] ruleSets) where T : Enum
            =>  string.Join(",", ruleSets.Select(ruleSet => Enum.GetName(typeof(T), ruleSet)));
    }
}
