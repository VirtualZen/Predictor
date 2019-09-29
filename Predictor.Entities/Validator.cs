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

        internal static bool isValidField(string fieldName, string field, string expression, List<string> fieldResults)
        {
            bool isValid = !Validator.isNullEmptyWhiteSpace(field) && Validator.isValidExpression(field, expression);
            if (!isValid)
            {
                fieldResults.Add($"{fieldName}:isNotValid");
            }
            return isValid;
        }

        internal static bool isValidDate(string fieldName, string field, List<string> fieldResults)
        {
            // TODO set date format via app configuration, now using OS default parsing
            DateTime result;
            bool couldParseDate = DateTime.TryParse(field, out result);
            Debug.Print($"Date Field:[{fieldName}]:=[{field}], Could Parse := [{couldParseDate}]");
            bool isValid = !Validator.isNullEmptyWhiteSpace(field) && couldParseDate;
            if (!isValid)
            {
                fieldResults.Add($"{fieldName}:isNotValid");
            }
            return isValid;
        }
    }
}
