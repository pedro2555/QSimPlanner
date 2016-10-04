using QSP.Common;
using QSP.FuelCalculation;
using QSP.UI.Controllers.Units;
using System.Windows.Forms;

namespace QSP.UI.UserControls
{
    public class FuelParameterValidator
    {
        private FuelPlanningControl control;

        public FuelParameterValidator(FuelPlanningControl control)
        {
            this.control = control;
        }

        // TODO: Does this throw NullReferenceException.
        /// <exception cref="InvalidUserInputException"></exception>
        public FuelParameters Validate()
        {
            var c = control;

            var WtUnit = c.WeightUnit;
            double ZfwKg = ImportPattern1(c.Zfw, "Invalid ZFW.");
            double ContPerc = ImportPattern2(
                c.ContPercentComboBox, "Invalid contingency fuel.");

            double MissedAppFuelKg = ImportPattern1(
                c.MissedApproach, "Invalid missed approach fuel.");

            double HoldingMin = ImportPattern2(
                c.HoldTimeTxtBox, "Invalid holding time.");

            double ExtraFuelKg =
                ImportPattern1(c.Extra, "Invalid extra fuel.");

            double ApuTime = ImportPattern2(
                c.ApuTimeTxtBox, "Invalid APU time.");

            double TaxiTime = ImportPattern2(
                c.TaxiTimeTxtBox, "Invalid taxi time.");

            double FinalRsvMin = ImportPattern2(
                c.FinalReserveTxtBox, "Invalid final reserve time.");

            return new FuelParameters(
                ZfwKg,
                ContPerc,
                MissedAppFuelKg,
                HoldingMin,
                ExtraFuelKg,
                ApuTime,
                TaxiTime,
                FinalRsvMin,
                c.GetCurrentAircraft().Config.FuelBias,
                c.GetFuelData());
        }

        private static double ImportPattern1(
            WeightTextBoxController weightControl, string exceptionMsg)
        {
            double weightKg;

            try
            {
                weightKg = weightControl.GetWeightKg();
            }
            catch
            {
                throw new InvalidUserInputException(exceptionMsg);
            }

            if (weightKg < 0.0)
            {
                throw new InvalidUserInputException(exceptionMsg);
            }

            return weightKg;
        }

        private static double ImportPattern2(
            Control control, string exceptionMsg)
        {
            double weightKg;

            try
            {
                weightKg = double.Parse(control.Text);
            }
            catch
            {
                throw new InvalidUserInputException(exceptionMsg);
            }

            if (weightKg < 0.0)
            {
                throw new InvalidUserInputException(exceptionMsg);
            }

            return weightKg;
        }
    }
}

