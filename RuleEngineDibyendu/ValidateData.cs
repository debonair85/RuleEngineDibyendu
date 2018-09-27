using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngineDibyendu
{
    public static class ValidateData
    {
        public static bool Validation(CustomData customData)
        {
            /*
            ATL1 value should not rise above 240.00
            ATL2 value should never be LOW
            ATL3 should not be in future
            */

            bool returnVal = false;
            switch (customData.Signal.ToUpper())
            {
                case "ATL1":
                    double i;
                    returnVal = double.TryParse(customData.Value, out i);
                    break;
                case "ATL2":
                    returnVal = customData.Value.ToUpper() != "LOW";
                    break;
                case "ATL3":
                    DateTime dt;
                    returnVal = DateTime.TryParse(customData.Value, out dt);
                    if (returnVal)
                        returnVal = dt < DateTime.Now;
                    break;
            }

            return returnVal;
        }
    }
}
