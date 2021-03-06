﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QSP.UI.Controllers.ControlGroup
{
    public class GroupController
    {
        private readonly List<ColorController> controllers;

        public GroupController(params ControlColorPair[] controlColors)
        {
            controllers = controlColors.Select(c => new ColorController(c.Control, c.Colors))
                .ToList();
        }

        public void Initialize()
        {
            foreach (var i in controllers)
            {
                i.Subscribed = true;
                i.SetInactiveStyle();
                i.Control.Click += (s, e) => SetSelected((Control) s);
            }
        }

        public void SetSelected(Control btn)
        {
            foreach (var i in controllers)
            {
                if (i.Control == btn)
                {
                    i.Subscribed = false;
                    i.SetActiveStyle();
                }
                else
                {
                    i.Subscribed = true;
                    i.SetInactiveStyle();
                }
            }
        }
        
        public class ControlColorPair
        {
            public Control Control { get; }
            public ColorGroup Colors { get; }

            public ControlColorPair(Control control, ColorGroup colors)
            {
                this.Control = control;
                this.Colors = colors;
            }
        }
    }
}
