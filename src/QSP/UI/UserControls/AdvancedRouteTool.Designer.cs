﻿namespace QSP.UI.UserControls
{
    partial class AdvancedRouteTool
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fromRwyLbl = new System.Windows.Forms.Label();
            this.sidLbl = new System.Windows.Forms.Label();
            this.fromWptLbl = new System.Windows.Forms.Label();
            this.toWptLbl = new System.Windows.Forms.Label();
            this.starLbl = new System.Windows.Forms.Label();
            this.toRwyLbl = new System.Windows.Forms.Label();
            this.routeRichTxtBox = new System.Windows.Forms.RichTextBox();
            this.routeSummaryLbl = new System.Windows.Forms.Label();
            this.fromIdentLbl = new System.Windows.Forms.Label();
            this.fromIdentTxtBox = new System.Windows.Forms.TextBox();
            this.toIdentTxtBox = new System.Windows.Forms.TextBox();
            this.toIdentLbl = new System.Windows.Forms.Label();
            this.filterStarBtn = new System.Windows.Forms.Button();
            this.filterSidBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.routeOptionBtn = new System.Windows.Forms.Button();
            this.showRouteActionsBtn = new System.Windows.Forms.Button();
            this.toWptComboBox = new QSP.UI.Controls.ComboBoxWithBorder();
            this.starComboBox = new QSP.UI.Controls.ComboBoxWithBorder();
            this.toRwyComboBox = new QSP.UI.Controls.ComboBoxWithBorder();
            this.fromWptComboBox = new QSP.UI.Controls.ComboBoxWithBorder();
            this.sidComboBox = new QSP.UI.Controls.ComboBoxWithBorder();
            this.fromRwyComboBox = new QSP.UI.Controls.ComboBoxWithBorder();
            this.toTypeComboBox = new QSP.UI.Controls.ComboBoxWithBorder();
            this.fromTypeComboBox = new QSP.UI.Controls.ComboBoxWithBorder();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // fromRwyLbl
            // 
            this.fromRwyLbl.AutoSize = true;
            this.fromRwyLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromRwyLbl.Location = new System.Drawing.Point(248, 6);
            this.fromRwyLbl.Name = "fromRwyLbl";
            this.fromRwyLbl.Size = new System.Drawing.Size(60, 20);
            this.fromRwyLbl.TabIndex = 4;
            this.fromRwyLbl.Text = "Runway";
            // 
            // sidLbl
            // 
            this.sidLbl.AutoSize = true;
            this.sidLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sidLbl.Location = new System.Drawing.Point(339, 6);
            this.sidLbl.Name = "sidLbl";
            this.sidLbl.Size = new System.Drawing.Size(32, 20);
            this.sidLbl.TabIndex = 6;
            this.sidLbl.Text = "SID";
            // 
            // fromWptLbl
            // 
            this.fromWptLbl.AutoSize = true;
            this.fromWptLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromWptLbl.Location = new System.Drawing.Point(516, 6);
            this.fromWptLbl.Name = "fromWptLbl";
            this.fromWptLbl.Size = new System.Drawing.Size(73, 20);
            this.fromWptLbl.TabIndex = 8;
            this.fromWptLbl.Text = "Waypoint";
            // 
            // toWptLbl
            // 
            this.toWptLbl.AutoSize = true;
            this.toWptLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toWptLbl.Location = new System.Drawing.Point(516, 74);
            this.toWptLbl.Name = "toWptLbl";
            this.toWptLbl.Size = new System.Drawing.Size(73, 20);
            this.toWptLbl.TabIndex = 14;
            this.toWptLbl.Text = "Waypoint";
            // 
            // starLbl
            // 
            this.starLbl.AutoSize = true;
            this.starLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.starLbl.Location = new System.Drawing.Point(339, 74);
            this.starLbl.Name = "starLbl";
            this.starLbl.Size = new System.Drawing.Size(44, 20);
            this.starLbl.TabIndex = 12;
            this.starLbl.Text = "STAR";
            // 
            // toRwyLbl
            // 
            this.toRwyLbl.AutoSize = true;
            this.toRwyLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toRwyLbl.Location = new System.Drawing.Point(248, 74);
            this.toRwyLbl.Name = "toRwyLbl";
            this.toRwyLbl.Size = new System.Drawing.Size(60, 20);
            this.toRwyLbl.TabIndex = 10;
            this.toRwyLbl.Text = "Runway";
            // 
            // routeRichTxtBox
            // 
            this.routeRichTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.routeRichTxtBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routeRichTxtBox.Location = new System.Drawing.Point(13, 227);
            this.routeRichTxtBox.Name = "routeRichTxtBox";
            this.routeRichTxtBox.Size = new System.Drawing.Size(793, 92);
            this.routeRichTxtBox.TabIndex = 14;
            this.routeRichTxtBox.Text = "";
            // 
            // routeSummaryLbl
            // 
            this.routeSummaryLbl.AutoSize = true;
            this.routeSummaryLbl.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routeSummaryLbl.Location = new System.Drawing.Point(593, 200);
            this.routeSummaryLbl.Name = "routeSummaryLbl";
            this.routeSummaryLbl.Size = new System.Drawing.Size(207, 23);
            this.routeSummaryLbl.TabIndex = 18;
            this.routeSummaryLbl.Text = "Distance: 459 NM (+3.5%)";
            // 
            // fromIdentLbl
            // 
            this.fromIdentLbl.AutoSize = true;
            this.fromIdentLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromIdentLbl.Location = new System.Drawing.Point(147, 6);
            this.fromIdentLbl.Name = "fromIdentLbl";
            this.fromIdentLbl.Size = new System.Drawing.Size(43, 20);
            this.fromIdentLbl.TabIndex = 19;
            this.fromIdentLbl.Text = "ICAO";
            // 
            // fromIdentTxtBox
            // 
            this.fromIdentTxtBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fromIdentTxtBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromIdentTxtBox.Location = new System.Drawing.Point(151, 30);
            this.fromIdentTxtBox.Name = "fromIdentTxtBox";
            this.fromIdentTxtBox.Size = new System.Drawing.Size(91, 30);
            this.fromIdentTxtBox.TabIndex = 1;
            this.fromIdentTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toIdentTxtBox
            // 
            this.toIdentTxtBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.toIdentTxtBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toIdentTxtBox.Location = new System.Drawing.Point(151, 98);
            this.toIdentTxtBox.Name = "toIdentTxtBox";
            this.toIdentTxtBox.Size = new System.Drawing.Size(91, 30);
            this.toIdentTxtBox.TabIndex = 7;
            this.toIdentTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toIdentLbl
            // 
            this.toIdentLbl.AutoSize = true;
            this.toIdentLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toIdentLbl.Location = new System.Drawing.Point(147, 74);
            this.toIdentLbl.Name = "toIdentLbl";
            this.toIdentLbl.Size = new System.Drawing.Size(43, 20);
            this.toIdentLbl.TabIndex = 21;
            this.toIdentLbl.Text = "ICAO";
            // 
            // filterStarBtn
            // 
            this.filterStarBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.filterStarBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.filterStarBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.filterStarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterStarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterStarBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.filterStarBtn.Location = new System.Drawing.Point(461, 97);
            this.filterStarBtn.Name = "filterStarBtn";
            this.filterStarBtn.Size = new System.Drawing.Size(54, 31);
            this.filterStarBtn.TabIndex = 10;
            this.filterStarBtn.Text = "Filter";
            this.filterStarBtn.UseVisualStyleBackColor = false;
            // 
            // filterSidBtn
            // 
            this.filterSidBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.filterSidBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.filterSidBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.filterSidBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filterSidBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterSidBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.filterSidBtn.Location = new System.Drawing.Point(461, 29);
            this.filterSidBtn.Name = "filterSidBtn";
            this.filterSidBtn.Size = new System.Drawing.Size(54, 31);
            this.filterSidBtn.TabIndex = 4;
            this.filterSidBtn.Text = "Filter";
            this.filterSidBtn.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Route";
            // 
            // routeOptionBtn
            // 
            this.routeOptionBtn.AutoSize = true;
            this.routeOptionBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.routeOptionBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.routeOptionBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.routeOptionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.routeOptionBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routeOptionBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.routeOptionBtn.Location = new System.Drawing.Point(13, 153);
            this.routeOptionBtn.Name = "routeOptionBtn";
            this.routeOptionBtn.Size = new System.Drawing.Size(82, 35);
            this.routeOptionBtn.TabIndex = 12;
            this.routeOptionBtn.Text = "Options";
            this.routeOptionBtn.UseVisualStyleBackColor = false;
            // 
            // showRouteActionsBtn
            // 
            this.showRouteActionsBtn.AutoSize = true;
            this.showRouteActionsBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showRouteActionsBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.showRouteActionsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.showRouteActionsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showRouteActionsBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showRouteActionsBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.showRouteActionsBtn.Location = new System.Drawing.Point(110, 153);
            this.showRouteActionsBtn.Name = "showRouteActionsBtn";
            this.showRouteActionsBtn.Size = new System.Drawing.Size(78, 35);
            this.showRouteActionsBtn.TabIndex = 13;
            this.showRouteActionsBtn.Text = "Actions";
            this.showRouteActionsBtn.UseVisualStyleBackColor = false;
            // 
            // toWptComboBox
            // 
            this.toWptComboBox.BorderColor = System.Drawing.Color.DimGray;
            this.toWptComboBox.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.toWptComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toWptComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toWptComboBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toWptComboBox.FormattingEnabled = true;
            this.toWptComboBox.Location = new System.Drawing.Point(520, 97);
            this.toWptComboBox.Name = "toWptComboBox";
            this.toWptComboBox.Size = new System.Drawing.Size(286, 31);
            this.toWptComboBox.TabIndex = 11;
            // 
            // starComboBox
            // 
            this.starComboBox.BorderColor = System.Drawing.Color.DimGray;
            this.starComboBox.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.starComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.starComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.starComboBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.starComboBox.FormattingEnabled = true;
            this.starComboBox.Location = new System.Drawing.Point(343, 97);
            this.starComboBox.Name = "starComboBox";
            this.starComboBox.Size = new System.Drawing.Size(113, 31);
            this.starComboBox.TabIndex = 9;
            // 
            // toRwyComboBox
            // 
            this.toRwyComboBox.BorderColor = System.Drawing.Color.DimGray;
            this.toRwyComboBox.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.toRwyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toRwyComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toRwyComboBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toRwyComboBox.FormattingEnabled = true;
            this.toRwyComboBox.Location = new System.Drawing.Point(252, 97);
            this.toRwyComboBox.Name = "toRwyComboBox";
            this.toRwyComboBox.Size = new System.Drawing.Size(79, 31);
            this.toRwyComboBox.TabIndex = 8;
            // 
            // fromWptComboBox
            // 
            this.fromWptComboBox.BorderColor = System.Drawing.Color.DimGray;
            this.fromWptComboBox.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.fromWptComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromWptComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fromWptComboBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromWptComboBox.FormattingEnabled = true;
            this.fromWptComboBox.Location = new System.Drawing.Point(520, 29);
            this.fromWptComboBox.Name = "fromWptComboBox";
            this.fromWptComboBox.Size = new System.Drawing.Size(286, 31);
            this.fromWptComboBox.TabIndex = 5;
            // 
            // sidComboBox
            // 
            this.sidComboBox.BorderColor = System.Drawing.Color.DimGray;
            this.sidComboBox.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sidComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sidComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sidComboBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sidComboBox.FormattingEnabled = true;
            this.sidComboBox.Location = new System.Drawing.Point(343, 29);
            this.sidComboBox.Name = "sidComboBox";
            this.sidComboBox.Size = new System.Drawing.Size(113, 31);
            this.sidComboBox.TabIndex = 3;
            // 
            // fromRwyComboBox
            // 
            this.fromRwyComboBox.BorderColor = System.Drawing.Color.DimGray;
            this.fromRwyComboBox.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.fromRwyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromRwyComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fromRwyComboBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromRwyComboBox.FormattingEnabled = true;
            this.fromRwyComboBox.Location = new System.Drawing.Point(252, 29);
            this.fromRwyComboBox.Name = "fromRwyComboBox";
            this.fromRwyComboBox.Size = new System.Drawing.Size(79, 31);
            this.fromRwyComboBox.TabIndex = 2;
            // 
            // toTypeComboBox
            // 
            this.toTypeComboBox.BorderColor = System.Drawing.Color.DimGray;
            this.toTypeComboBox.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.toTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toTypeComboBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toTypeComboBox.FormattingEnabled = true;
            this.toTypeComboBox.Location = new System.Drawing.Point(13, 97);
            this.toTypeComboBox.Name = "toTypeComboBox";
            this.toTypeComboBox.Size = new System.Drawing.Size(129, 31);
            this.toTypeComboBox.TabIndex = 6;
            // 
            // fromTypeComboBox
            // 
            this.fromTypeComboBox.BorderColor = System.Drawing.Color.DimGray;
            this.fromTypeComboBox.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.fromTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fromTypeComboBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromTypeComboBox.FormattingEnabled = true;
            this.fromTypeComboBox.Location = new System.Drawing.Point(13, 29);
            this.fromTypeComboBox.Name = "fromTypeComboBox";
            this.fromTypeComboBox.Size = new System.Drawing.Size(129, 31);
            this.fromTypeComboBox.TabIndex = 0;
            // 
            // AdvancedRouteTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.routeOptionBtn);
            this.Controls.Add(this.showRouteActionsBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.filterStarBtn);
            this.Controls.Add(this.filterSidBtn);
            this.Controls.Add(this.toIdentTxtBox);
            this.Controls.Add(this.toIdentLbl);
            this.Controls.Add(this.fromIdentTxtBox);
            this.Controls.Add(this.fromIdentLbl);
            this.Controls.Add(this.routeSummaryLbl);
            this.Controls.Add(this.routeRichTxtBox);
            this.Controls.Add(this.toWptComboBox);
            this.Controls.Add(this.toWptLbl);
            this.Controls.Add(this.starComboBox);
            this.Controls.Add(this.starLbl);
            this.Controls.Add(this.toRwyComboBox);
            this.Controls.Add(this.toRwyLbl);
            this.Controls.Add(this.fromWptComboBox);
            this.Controls.Add(this.fromWptLbl);
            this.Controls.Add(this.sidComboBox);
            this.Controls.Add(this.sidLbl);
            this.Controls.Add(this.fromRwyComboBox);
            this.Controls.Add(this.fromRwyLbl);
            this.Controls.Add(this.toTypeComboBox);
            this.Controls.Add(this.fromTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "AdvancedRouteTool";
            this.Size = new System.Drawing.Size(813, 329);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controls.ComboBoxWithBorder fromTypeComboBox;
        private Controls.ComboBoxWithBorder toTypeComboBox;
        private Controls.ComboBoxWithBorder fromRwyComboBox;
        private System.Windows.Forms.Label fromRwyLbl;
        private Controls.ComboBoxWithBorder sidComboBox;
        private System.Windows.Forms.Label sidLbl;
        private Controls.ComboBoxWithBorder fromWptComboBox;
        private System.Windows.Forms.Label fromWptLbl;
        private Controls.ComboBoxWithBorder toWptComboBox;
        private System.Windows.Forms.Label toWptLbl;
        private Controls.ComboBoxWithBorder starComboBox;
        private System.Windows.Forms.Label starLbl;
        private Controls.ComboBoxWithBorder toRwyComboBox;
        private System.Windows.Forms.Label toRwyLbl;
        private System.Windows.Forms.RichTextBox routeRichTxtBox;
        private System.Windows.Forms.Label routeSummaryLbl;
        private System.Windows.Forms.Label fromIdentLbl;
        private System.Windows.Forms.TextBox fromIdentTxtBox;
        private System.Windows.Forms.TextBox toIdentTxtBox;
        private System.Windows.Forms.Label toIdentLbl;
        private System.Windows.Forms.Button filterSidBtn;
        private System.Windows.Forms.Button filterStarBtn;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button routeOptionBtn;
        public System.Windows.Forms.Button showRouteActionsBtn;
    }
}
