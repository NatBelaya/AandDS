namespace Sort_Form
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.input = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.output = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.sortButton = new System.Windows.Forms.Button();
			this.getUps = new System.Windows.Forms.Button();
			this.getRand = new System.Windows.Forms.Button();
			this.getDwns = new System.Windows.Forms.Button();
			this.sortGroup = new System.Windows.Forms.GroupBox();
			this.custom = new System.Windows.Forms.RadioButton();
			this.quick = new System.Windows.Forms.RadioButton();
			this.swap = new System.Windows.Forms.RadioButton();
			this.insertion = new System.Windows.Forms.RadioButton();
			this.selection = new System.Windows.Forms.RadioButton();
			this.inpSize = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.sortGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// input
			// 
			this.input.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.input.Location = new System.Drawing.Point(8, 27);
			this.input.Margin = new System.Windows.Forms.Padding(2);
			this.input.Multiline = true;
			this.input.Name = "input";
			this.input.ReadOnly = true;
			this.input.Size = new System.Drawing.Size(253, 230);
			this.input.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 6);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Input";
			// 
			// output
			// 
			this.output.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.output.Location = new System.Drawing.Point(273, 27);
			this.output.Margin = new System.Windows.Forms.Padding(2);
			this.output.Multiline = true;
			this.output.Name = "output";
			this.output.ReadOnly = true;
			this.output.Size = new System.Drawing.Size(253, 230);
			this.output.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(271, 6);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Output";
			// 
			// sortButton
			// 
			this.sortButton.Enabled = false;
			this.sortButton.Location = new System.Drawing.Point(449, 259);
			this.sortButton.Margin = new System.Windows.Forms.Padding(2);
			this.sortButton.Name = "sortButton";
			this.sortButton.Size = new System.Drawing.Size(77, 25);
			this.sortButton.TabIndex = 4;
			this.sortButton.Text = "Sort";
			this.sortButton.UseVisualStyleBackColor = true;
			this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
			// 
			// getUps
			// 
			this.getUps.Location = new System.Drawing.Point(8, 259);
			this.getUps.Margin = new System.Windows.Forms.Padding(2);
			this.getUps.Name = "getUps";
			this.getUps.Size = new System.Drawing.Size(77, 25);
			this.getUps.TabIndex = 5;
			this.getUps.Text = "Sorted up";
			this.getUps.UseVisualStyleBackColor = true;
			this.getUps.Click += new System.EventHandler(this.getUps_Click);
			// 
			// getRand
			// 
			this.getRand.Location = new System.Drawing.Point(184, 259);
			this.getRand.Margin = new System.Windows.Forms.Padding(2);
			this.getRand.Name = "getRand";
			this.getRand.Size = new System.Drawing.Size(77, 25);
			this.getRand.TabIndex = 6;
			this.getRand.Text = "Random";
			this.getRand.UseVisualStyleBackColor = true;
			this.getRand.Click += new System.EventHandler(this.getRand_Click);
			// 
			// getDwns
			// 
			this.getDwns.Location = new System.Drawing.Point(96, 259);
			this.getDwns.Margin = new System.Windows.Forms.Padding(2);
			this.getDwns.Name = "getDwns";
			this.getDwns.Size = new System.Drawing.Size(77, 25);
			this.getDwns.TabIndex = 7;
			this.getDwns.Text = "Sorted down";
			this.getDwns.UseVisualStyleBackColor = true;
			this.getDwns.Click += new System.EventHandler(this.getDwns_Click);
			// 
			// sortGroup
			// 
			this.sortGroup.BackColor = System.Drawing.SystemColors.Control;
			this.sortGroup.Controls.Add(this.custom);
			this.sortGroup.Controls.Add(this.quick);
			this.sortGroup.Controls.Add(this.swap);
			this.sortGroup.Controls.Add(this.insertion);
			this.sortGroup.Controls.Add(this.selection);
			this.sortGroup.Location = new System.Drawing.Point(529, 21);
			this.sortGroup.Margin = new System.Windows.Forms.Padding(2);
			this.sortGroup.Name = "sortGroup";
			this.sortGroup.Padding = new System.Windows.Forms.Padding(2);
			this.sortGroup.Size = new System.Drawing.Size(76, 127);
			this.sortGroup.TabIndex = 8;
			this.sortGroup.TabStop = false;
			this.sortGroup.Text = "Sort";
			// 
			// custom
			// 
			this.custom.AutoSize = true;
			this.custom.Location = new System.Drawing.Point(5, 103);
			this.custom.Margin = new System.Windows.Forms.Padding(2);
			this.custom.Name = "custom";
			this.custom.Size = new System.Drawing.Size(60, 17);
			this.custom.TabIndex = 4;
			this.custom.Text = "Custom";
			this.custom.UseVisualStyleBackColor = true;
			// 
			// quick
			// 
			this.quick.AutoSize = true;
			this.quick.Location = new System.Drawing.Point(5, 81);
			this.quick.Margin = new System.Windows.Forms.Padding(2);
			this.quick.Name = "quick";
			this.quick.Size = new System.Drawing.Size(53, 17);
			this.quick.TabIndex = 3;
			this.quick.Text = "Quick";
			this.quick.UseVisualStyleBackColor = true;
			// 
			// swap
			// 
			this.swap.AutoSize = true;
			this.swap.Location = new System.Drawing.Point(5, 60);
			this.swap.Margin = new System.Windows.Forms.Padding(2);
			this.swap.Name = "swap";
			this.swap.Size = new System.Drawing.Size(73, 17);
			this.swap.TabIndex = 2;
			this.swap.Text = "Exchange";
			this.swap.UseVisualStyleBackColor = true;
			// 
			// insertion
			// 
			this.insertion.AutoSize = true;
			this.insertion.Location = new System.Drawing.Point(5, 38);
			this.insertion.Margin = new System.Windows.Forms.Padding(2);
			this.insertion.Name = "insertion";
			this.insertion.Size = new System.Drawing.Size(65, 17);
			this.insertion.TabIndex = 1;
			this.insertion.Text = "Insertion";
			this.insertion.UseVisualStyleBackColor = true;
			// 
			// selection
			// 
			this.selection.AutoSize = true;
			this.selection.Checked = true;
			this.selection.Location = new System.Drawing.Point(5, 17);
			this.selection.Margin = new System.Windows.Forms.Padding(2);
			this.selection.Name = "selection";
			this.selection.Size = new System.Drawing.Size(69, 17);
			this.selection.TabIndex = 0;
			this.selection.TabStop = true;
			this.selection.Text = "Selection";
			this.selection.UseVisualStyleBackColor = true;
			// 
			// inpSize
			// 
			this.inpSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inpSize.FormattingEnabled = true;
			this.inpSize.ItemHeight = 13;
			this.inpSize.Items.AddRange(new object[] {
            "10",
            "100",
            "1000",
            "10000"});
			this.inpSize.Location = new System.Drawing.Point(529, 168);
			this.inpSize.Margin = new System.Windows.Forms.Padding(2);
			this.inpSize.Name = "inpSize";
			this.inpSize.Size = new System.Drawing.Size(79, 21);
			this.inpSize.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(529, 151);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Input Size";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(615, 292);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.inpSize);
			this.Controls.Add(this.sortGroup);
			this.Controls.Add(this.getDwns);
			this.Controls.Add(this.getRand);
			this.Controls.Add(this.getUps);
			this.Controls.Add(this.sortButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.output);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.input);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.Text = "Lab4";
			this.sortGroup.ResumeLayout(false);
			this.sortGroup.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Button getUps;
        private System.Windows.Forms.Button getRand;
        private System.Windows.Forms.Button getDwns;
        private System.Windows.Forms.GroupBox sortGroup;
        private System.Windows.Forms.RadioButton custom;
        private System.Windows.Forms.RadioButton quick;
        private System.Windows.Forms.RadioButton swap;
        private System.Windows.Forms.RadioButton insertion;
        private System.Windows.Forms.RadioButton selection;
        private System.Windows.Forms.ComboBox inpSize;
        private System.Windows.Forms.Label label3;
    }
}

