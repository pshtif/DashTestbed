/*
 *	Created by:  Peter @sHTiF Stefcek
 */

using Dash;
using Dash.NCalc;
using Machina.Attributes;
using UnityEngine;

namespace Examples.Scripts
{
    [ClassAttributes.ExpressionFunctionsAttribute]
    public class CustomFunctions
    {
        private static bool Test(FunctionArgs p_args)
        {
            if (p_args.Parameters.Length != 0)
            {
                ExpressionFunctions.errorMessage = "Invalid parameters in Test function.";
                return false;
            }

            p_args.HasResult = true;
            p_args.Result = 0;
            return true;
        }
    }
}