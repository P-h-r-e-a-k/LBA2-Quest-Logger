namespace LBA2_Quest_Logger
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lvQuest = new System.Windows.Forms.ListView();
            this.chQuestOffset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQuestDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSubquest = new System.Windows.Forms.ListView();
            this.chSubquestDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSubquestValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtQuestDescription = new System.Windows.Forms.TextBox();
            this.btnQuestDescUpdate = new System.Windows.Forms.Button();
            this.lblQuestDesc = new System.Windows.Forms.Label();
            this.btnSubquestDescUpdate = new System.Windows.Forms.Button();
            this.lblSubquestDesc = new System.Windows.Forms.Label();
            this.txtSubquestDescription = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDebug = new System.Windows.Forms.Button();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.lblOffset = new System.Windows.Forms.Label();
            this.lvlValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(363, 369);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(525, 369);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lvQuest
            // 
            this.lvQuest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chQuestOffset,
            this.chQuestDescription});
            this.lvQuest.FullRowSelect = true;
            this.lvQuest.GridLines = true;
            this.lvQuest.HideSelection = false;
            this.lvQuest.Location = new System.Drawing.Point(12, 12);
            this.lvQuest.MultiSelect = false;
            this.lvQuest.Name = "lvQuest";
            this.lvQuest.Size = new System.Drawing.Size(471, 302);
            this.lvQuest.TabIndex = 2;
            this.lvQuest.UseCompatibleStateImageBehavior = false;
            this.lvQuest.View = System.Windows.Forms.View.Details;
            this.lvQuest.SelectedIndexChanged += new System.EventHandler(this.lvQuest_SelectedIndexChanged);
            // 
            // chQuestOffset
            // 
            this.chQuestOffset.Text = "Offset";
            // 
            // chQuestDescription
            // 
            this.chQuestDescription.Text = "Description";
            this.chQuestDescription.Width = 399;
            // 
            // lvSubquest
            // 
            this.lvSubquest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSubquestDescription,
            this.chSubquestValue});
            this.lvSubquest.GridLines = true;
            this.lvSubquest.HideSelection = false;
            this.lvSubquest.Location = new System.Drawing.Point(489, 12);
            this.lvSubquest.Name = "lvSubquest";
            this.lvSubquest.Size = new System.Drawing.Size(471, 302);
            this.lvSubquest.TabIndex = 3;
            this.lvSubquest.UseCompatibleStateImageBehavior = false;
            this.lvSubquest.View = System.Windows.Forms.View.Details;
            this.lvSubquest.SelectedIndexChanged += new System.EventHandler(this.lvSubquest_SelectedIndexChanged);
            // 
            // chSubquestDescription
            // 
            this.chSubquestDescription.Text = "Description";
            this.chSubquestDescription.Width = 406;
            // 
            // chSubquestValue
            // 
            this.chSubquestValue.Text = "Value";
            // 
            // txtQuestDescription
            // 
            this.txtQuestDescription.Location = new System.Drawing.Point(92, 320);
            this.txtQuestDescription.Name = "txtQuestDescription";
            this.txtQuestDescription.Size = new System.Drawing.Size(310, 20);
            this.txtQuestDescription.TabIndex = 4;
            // 
            // btnQuestDescUpdate
            // 
            this.btnQuestDescUpdate.Location = new System.Drawing.Point(408, 318);
            this.btnQuestDescUpdate.Name = "btnQuestDescUpdate";
            this.btnQuestDescUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnQuestDescUpdate.TabIndex = 5;
            this.btnQuestDescUpdate.Text = "Update";
            this.btnQuestDescUpdate.UseVisualStyleBackColor = true;
            this.btnQuestDescUpdate.Click += new System.EventHandler(this.btnQuestDescUpdate_Click);
            // 
            // lblQuestDesc
            // 
            this.lblQuestDesc.AutoSize = true;
            this.lblQuestDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestDesc.Location = new System.Drawing.Point(12, 323);
            this.lblQuestDesc.Name = "lblQuestDesc";
            this.lblQuestDesc.Size = new System.Drawing.Size(71, 13);
            this.lblQuestDesc.TabIndex = 6;
            this.lblQuestDesc.Text = "Description";
            // 
            // btnSubquestDescUpdate
            // 
            this.btnSubquestDescUpdate.Location = new System.Drawing.Point(885, 318);
            this.btnSubquestDescUpdate.Name = "btnSubquestDescUpdate";
            this.btnSubquestDescUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnSubquestDescUpdate.TabIndex = 7;
            this.btnSubquestDescUpdate.Text = "Update";
            this.btnSubquestDescUpdate.UseVisualStyleBackColor = true;
            this.btnSubquestDescUpdate.Click += new System.EventHandler(this.btnSubquestDescUpdate_Click);
            // 
            // lblSubquestDesc
            // 
            this.lblSubquestDesc.AutoSize = true;
            this.lblSubquestDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubquestDesc.Location = new System.Drawing.Point(489, 323);
            this.lblSubquestDesc.Name = "lblSubquestDesc";
            this.lblSubquestDesc.Size = new System.Drawing.Size(71, 13);
            this.lblSubquestDesc.TabIndex = 8;
            this.lblSubquestDesc.Text = "Description";
            // 
            // txtSubquestDescription
            // 
            this.txtSubquestDescription.Location = new System.Drawing.Point(566, 320);
            this.txtSubquestDescription.Name = "txtSubquestDescription";
            this.txtSubquestDescription.Size = new System.Drawing.Size(310, 20);
            this.txtSubquestDescription.TabIndex = 9;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(444, 369);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(198, 358);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 11;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(92, 346);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(100, 20);
            this.txtOffset.TabIndex = 12;
            this.txtOffset.Text = "57C47";
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOffset.Location = new System.Drawing.Point(12, 349);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(41, 13);
            this.lblOffset.TabIndex = 13;
            this.lblOffset.Text = "Offset";
            // 
            // lvlValue
            // 
            this.lvlValue.AutoSize = true;
            this.lvlValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlValue.Location = new System.Drawing.Point(12, 374);
            this.lvlValue.Name = "lvlValue";
            this.lvlValue.Size = new System.Drawing.Size(39, 13);
            this.lvlValue.TabIndex = 14;
            this.lvlValue.Text = "Value";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(92, 371);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 20);
            this.txtValue.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 411);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lvlValue);
            this.Controls.Add(this.lblOffset);
            this.Controls.Add(this.txtOffset);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtSubquestDescription);
            this.Controls.Add(this.lblSubquestDesc);
            this.Controls.Add(this.btnSubquestDescUpdate);
            this.Controls.Add(this.lblQuestDesc);
            this.Controls.Add(this.btnQuestDescUpdate);
            this.Controls.Add(this.txtQuestDescription);
            this.Controls.Add(this.lvSubquest);
            this.Controls.Add(this.lvQuest);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lvQuest;
        private System.Windows.Forms.ListView lvSubquest;
        private System.Windows.Forms.ColumnHeader chQuestOffset;
        private System.Windows.Forms.ColumnHeader chQuestDescription;
        private System.Windows.Forms.ColumnHeader chSubquestDescription;
        private System.Windows.Forms.ColumnHeader chSubquestValue;
        private System.Windows.Forms.TextBox txtQuestDescription;
        private System.Windows.Forms.Button btnQuestDescUpdate;
        private System.Windows.Forms.Label lblQuestDesc;
        private System.Windows.Forms.Button btnSubquestDescUpdate;
        private System.Windows.Forms.Label lblSubquestDesc;
        private System.Windows.Forms.TextBox txtSubquestDescription;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.Label lvlValue;
        private System.Windows.Forms.TextBox txtValue;
    }
}

