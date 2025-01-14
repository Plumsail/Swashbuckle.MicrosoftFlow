﻿using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Plumsail.Swashbuckle.MicrosoftPowerAutomate.Helpers
{
    internal static class ParameterParser
    {
        internal static IDictionary<string, object> Parse(string s)
        {
            var parameters = QueryHelpers.ParseQuery(s);
            return parameters.Select(ParseParameter).ToDictionary(x => x.Key, x => x.Value);
        }

        internal static IDictionary<string, object> ParseProperties(string s)
        {
            var parameters = QueryHelpers.ParseQuery(s);
            return parameters.Select(ParsePropertiesParameters).ToDictionary(x => x.Key, x => x.Value);
        }

        private static KeyValuePair<string, object> ParseParameter(KeyValuePair<string, StringValues> parameter)
        {
            var matches = Regex.Match(parameter.Value, @"^{(.+)}$");
            if (matches.Success)
            {
                return new KeyValuePair<string, object>
                (
                    parameter.Key,
                    new Dictionary<string, string> { { Constants.Parameter, matches.Groups[1].Value } }
                );
            }

            // parse true/false values as bools
            return parameter.Value[0] switch
            {
                "true" => new KeyValuePair<string, object>(parameter.Key, true),
                "false" => new KeyValuePair<string, object>(parameter.Key, false),
                _ => new KeyValuePair<string, object>(parameter.Key, parameter.Value[0]),
            };
        }

        private static KeyValuePair<string, object> ParsePropertiesParameters(KeyValuePair<string, StringValues> parameter)
        {
            var matches = Regex.Match(parameter.Value, @"^{(.+)}$");
            if (matches.Success)
            {
                return new KeyValuePair<string, object>
                (
                    parameter.Key,
                    new Dictionary<string, string> { { Constants.ParameterReferenece, matches.Groups[1].Value } }
                );
            }

            return new KeyValuePair<string, object>
            (
                parameter.Key,
                new Dictionary<string, object> { { Constants.Value, parameter.Value[0] } }
            );
        }
    }
}