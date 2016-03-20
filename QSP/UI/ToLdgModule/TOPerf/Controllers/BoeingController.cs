﻿using QSP.Core;
using QSP.TOPerfCalculation;
using QSP.TOPerfCalculation.Boeing.PerfData;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QSP.UI.ToLdgModule.TOPerf.Controllers
{
    public class BoeingController : FormController
    {
        public BoeingController(PerfTable acPerf, TOPerfElements elements)
            : base(acPerf, elements)
        { }

        public override void WeightUnitChanged(object sender, EventArgs e)
        {
            double wt;

            if (double.TryParse(elements.weight.Text, out wt))
            {
                if (elements.wtUnit.SelectedIndex == 0)
                {
                    // LB -> KG 
                    wt *= AviationTools.Constants.LbKgRatio;
                }
                else
                {
                    // KG -> LB
                    wt *= AviationTools.Constants.KgLbRatio;
                }

                elements.weight.Text = ((int)Math.Round(wt)).ToString();
            }
        }

        public override void Initialize()
        {
            setDefaultSurfCond();
            setDefaultFlaps();
            setDerate();
            elements.AntiIce.SelectedIndex = 0;
            elements.Packs.SelectedIndex = 0;
        }

        public override void FlapsChanged(object sender, EventArgs e)
        {
            setDerate();
        }

        private void setDerate()
        {
            var thrustComboBox = elements.thrustRating;
            string text = thrustComboBox.Text;
            var table = ((BoeingPerfTable)acPerf.Item)
                         .GetTable(elements.flaps.SelectedIndex);

            var items = thrustComboBox.Items;
            items.Clear();

            if (table.AltnRatingAvail)
            {
                items.AddRange(table.ThrustRatings);

                thrustComboBox.SelectedIndex = 0;
                thrustComboBox.Text = text;
                thrustComboBox.Visible = true;
                elements.ThrustRatingLbl.Visible = true;
            }
            else
            {
                thrustComboBox.Visible = false;
                elements.ThrustRatingLbl.Visible = false;
            }
        }

        private void setDefaultSurfCond()
        {
            var items = elements.surfCond.Items;

            items.Clear();
            items.AddRange(new object[] {
                "Dry",
                "Wet"});

            elements.surfCond.SelectedIndex = 0;
        }

        private void setDefaultFlaps()
        {
            var items = elements.flaps.Items;
            items.Clear();

            foreach (var i in ((BoeingPerfTable)acPerf.Item).Flaps)
            {
                items.Add(i);
            }

            elements.flaps.SelectedIndex = 0;
        }

        public override void Compute(object sender, EventArgs e)
        {
            try
            {
                var para = new BoeingParameterValidator(elements).Validate();

                var result = new TOPerfCalculation.Boeing.TOCalculator(
                    (BoeingPerfTable)acPerf.Item, para).TakeOffReport();

                elements.result.Text = result.ToString(
                    elements.tempUnit.SelectedIndex == 0 ?
                    TemperatureUnit.Celsius :
                    TemperatureUnit.Fahrenheit,
                    elements.lengthUnit.SelectedIndex == 0 ?
                    LengthUnit.Meter :
                    LengthUnit.Feet);

                OnCalculationComplete(EventArgs.Empty);
            }
            catch (InvalidUserInputException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (RunwayTooShortException)
            {//TODO:
                elements.result.ForeColor = Color.Red;
                elements.result.Text = "Runway length is insufficient for takeoff.";
            }
            catch(PoorClimbPerformanceException)
            {
                elements.result.ForeColor = Color.Red;
                elements.result.Text = "Aircraft too heavy to meet climb performance requirement.";
            }
        }
    }
}