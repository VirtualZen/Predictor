using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Predictor.Entities
{
    internal static class Validator
    {
        internal static bool isNullEmptyWhiteSpace(string s)
        {
            return (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s));
        }

        internal static bool isValidExpression(string target, string expression)
        {
            var m = System.Text.RegularExpressions.Regex.Match(target, expression);
            Debug.Print($"RegEx: (target[{target}],expression[{expression}]):=[{m.Value}]");
            return m.Success;
        }
    }
}
