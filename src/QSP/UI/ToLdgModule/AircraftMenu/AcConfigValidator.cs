﻿using QSP.AircraftProfiles.Configs;
using QSP.AviationTools;
using QSP.Common;
using QSP.Utilities.Units;

namespace QSP.UI.ToLdgModule.AircraftMenu
{
    public class AcConfigValidator
    {
        private AcMenuElements elem;

        public AcConfigValidator(AcMenuElements elem)
        {
            this.elem = elem;
        }

        // TODO: Number range validation?
        /// <exception cref="InvalidUserInputException"></exception>
        public AircraftConfigItem Read()
        {
            var wtUnit = (WeightUnit)elem.WeightUnitCBox.SelectedIndex;

            double wtUnitFactor = wtUnit == WeightUnit.KG ?
                    1.0 : Constants.LbKgRatio;

            double zfw, maxToWt, maxLdgWt, maxZfw, maxFuel, fuelBias;

            if (double.TryParse(elem.Zfw.Text, out zfw) == false)
            {
                throw new InvalidUserInputException("Invalid ZFW.");
            }

            if (double.TryParse(elem.MaxToWt.Text, out maxToWt) == false)
            {
                throw new InvalidUserInputException(
                    "Invalid max takeoff weight.");
            }

            if (double.TryParse(elem.MaxLdgWt.Text, out maxLdgWt) == false)
            {
                throw new InvalidUserInputException(
                    "Invalid max landing weight.");
            }

            if (double.TryParse(elem.MaxZfw.Text, out maxZfw) == false)
            {
                throw new InvalidUserInputException(
                    "Invalid max zero fuel weight.");
            }

            if (double.TryParse(elem.MaxFuel.Text, out maxFuel) == false)
            {
                throw new InvalidUserInputException(
                    "Invalid max fuel capacity.");
            }

            if (double.TryParse(elem.Bias.Text, out fuelBias) == false)
            {
                throw new InvalidUserInputException(
                    "Invalid fuel bias.");
            }

            zfw *= wtUnitFactor;
            maxToWt *= wtUnitFactor;
            maxLdgWt *= wtUnitFactor;
            maxZfw *= wtUnitFactor;
            maxFuel *= wtUnitFactor;
            fuelBias /= 100.0;

            return new AircraftConfigItem(
                elem.AcType.Text.Trim(),
                elem.Registration.Text.Trim().ToUpper(),
                elem.FuelProfile.Text,
                elem.ToProfile.Text,
                elem.LdgProfile.Text,
                zfw,
                maxToWt,
                maxLdgWt,
                maxZfw,
                maxFuel,
                fuelBias,
                wtUnit);
        }

        /// <exception cref="InvalidUserInputException"></exception>
        public AircraftConfigItem Validate()
        {
            var item = Read();

            if (item.AC == "")
            {
                throw new InvalidUserInputException(
                    "Aircraft type cannot be empty.");
            }

            if (item.Registration == "")
            {
                throw new InvalidUserInputException(
                    "Registration cannot be empty.");
            }

            return item;
        }
    }
}
