// Licensed under the BSD license
// See the LICENSE file in the project root for more information

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TestAppWithGui
{
    partial class FormTest
    {
        private IContainer components = null;
        private Button buttonStartStopSyslogServer;
        private Button buttonTrace;
        private Button buttonDebug;
        private Button buttonInfo;
        private Button buttonWarn;
        private Button buttonError;
        private Button buttonFatal;
        private Button buttonFromFile;
        private Button buttonHuge;
        private Button buttonMultiple;
        private Button buttonContinuous;
        private Button buttonParallel;
        private Label udpLabel;
        private TextBox udpTextBox;
        private Label tcpLabel;
        private TextBox tcpTextBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            buttonStartStopSyslogServer = new Button();
            buttonTrace = new Button();
            buttonDebug = new Button();
            buttonInfo = new Button();
            buttonWarn = new Button();
            buttonError = new Button();
            buttonFatal = new Button();
            buttonFromFile = new Button();
            buttonHuge = new Button();
            buttonMultiple = new Button();
            buttonContinuous = new Button();
            buttonParallel = new Button();
            udpLabel = new Label();
            udpTextBox = new TextBox();
            tcpLabel = new Label();
            tcpTextBox = new TextBox();
            SuspendLayout();

            buttonStartStopSyslogServer.Location = new Point(36, 20);
            buttonStartStopSyslogServer.Name = "buttonStartSyslogServer";
            buttonStartStopSyslogServer.Size = new Size(212, 38);
            buttonStartStopSyslogServer.TabIndex = 0;
            buttonStartStopSyslogServer.Text = @"Start Syslog Server";
            buttonStartStopSyslogServer.UseVisualStyleBackColor = true;
            buttonStartStopSyslogServer.Click += new EventHandler(ButtonLogClick);

            buttonTrace.Location = new Point(36, 70);
            buttonTrace.Name = "buttonTrace";
            buttonTrace.Size = new Size(212, 38);
            buttonTrace.TabIndex = 0;
            buttonTrace.Text = "Trace event";
            buttonTrace.UseVisualStyleBackColor = true;
            buttonTrace.Click += new EventHandler(ButtonLogClick);

            buttonDebug.Location = new Point(36, 120);
            buttonDebug.Name = "buttonDebug";
            buttonDebug.Size = new Size(212, 38);
            buttonDebug.TabIndex = 1;
            buttonDebug.Text = "Debug event";
            buttonDebug.UseVisualStyleBackColor = true;
            buttonDebug.Click += new EventHandler(ButtonLogClick);

            buttonInfo.Location = new Point(36, 170);
            buttonInfo.Name = "buttonInfo";
            buttonInfo.Size = new Size(212, 38);
            buttonInfo.TabIndex = 2;
            buttonInfo.Text = "Info event";
            buttonInfo.UseVisualStyleBackColor = true;
            buttonInfo.Click += new EventHandler(ButtonLogClick);

            buttonWarn.Location = new Point(36, 220);
            buttonWarn.Name = "buttonWarn";
            buttonWarn.Size = new Size(212, 38);
            buttonWarn.TabIndex = 3;
            buttonWarn.Text = "Warn event";
            buttonWarn.UseVisualStyleBackColor = true;
            buttonWarn.Click += new EventHandler(ButtonLogClick);

            buttonError.Location = new Point(36, 270);
            buttonError.Name = "buttonError";
            buttonError.Size = new Size(212, 38);
            buttonError.TabIndex = 4;
            buttonError.Text = "Error event";
            buttonError.UseVisualStyleBackColor = true;
            buttonError.Click += new EventHandler(ButtonLogClick);

            buttonFatal.Location = new Point(36, 320);
            buttonFatal.Name = "buttonFatal";
            buttonFatal.Size = new Size(212, 38);
            buttonFatal.TabIndex = 5;
            buttonFatal.Text = "Fatal event";
            buttonFatal.UseVisualStyleBackColor = true;
            buttonFatal.Click += new EventHandler(ButtonLogClick);

            buttonFromFile.Location = new Point(36, 370);
            buttonFromFile.Name = "buttonFromFile";
            buttonFromFile.Size = new Size(212, 38);
            buttonFromFile.TabIndex = 6;
            buttonFromFile.Text = "From file events";
            buttonFromFile.UseVisualStyleBackColor = true;
            buttonFromFile.Click += new EventHandler(ButtonLogClick);

            buttonHuge.Location = new Point(36, 420);
            buttonHuge.Name = "buttonHuge";
            buttonHuge.Size = new Size(212, 38);
            buttonHuge.TabIndex = 6;
            buttonHuge.Text = "Huge events";
            buttonHuge.UseVisualStyleBackColor = true;
            buttonHuge.Click += new EventHandler(ButtonLogClick);

            buttonMultiple.Location = new Point(36, 470);
            buttonMultiple.Name = "buttonMultiple";
            buttonMultiple.Size = new Size(212, 38);
            buttonMultiple.TabIndex = 7;
            buttonMultiple.Text = "Multiple events";
            buttonMultiple.UseVisualStyleBackColor = true;
            buttonMultiple.Click += new EventHandler(ButtonLogClick);

            buttonContinuous.Location = new Point(36, 520);
            buttonContinuous.Name = "buttonContinuous";
            buttonContinuous.Size = new Size(212, 38);
            buttonContinuous.TabIndex = 7;
            buttonContinuous.Text = "Continuous events";
            buttonContinuous.UseVisualStyleBackColor = true;
            buttonContinuous.Click += new EventHandler(ButtonLogClick);

            buttonParallel.Location = new Point(36, 570);
            buttonParallel.Name = "buttonParallel";
            buttonParallel.Size = new Size(212, 38);
            buttonParallel.TabIndex = 7;
            buttonParallel.Text = "Parallel events";
            buttonParallel.UseVisualStyleBackColor = true;
            buttonParallel.Click += new EventHandler(ButtonLogClick);

            udpLabel.Location = new Point(885, 21);
            udpLabel.Name = "udpLabel";
            udpLabel.Text = "U" + Environment.NewLine + "D" + Environment.NewLine + "P";
            udpLabel.AutoSize = true;

            udpTextBox.Location = new Point(260, 21);
            udpTextBox.Name = "udpTextBox";
            udpTextBox.Size = new Size(620, 285);
            udpTextBox.TabIndex = 8;
            udpTextBox.Multiline = true;
            udpTextBox.ReadOnly = true;
            udpTextBox.ScrollBars = ScrollBars.Vertical;

            tcpLabel.Location = new Point(885, 323);
            tcpLabel.Name = "tcpLabel";
            tcpLabel.Text = "T" + Environment.NewLine + "C" + Environment.NewLine + "P";
            tcpLabel.AutoSize = true;

            tcpTextBox.Location = new Point(260, 323);
            tcpTextBox.Name = "tcpTextBox";
            tcpTextBox.Size = new Size(620,285);
            tcpTextBox.TabIndex = 9;
            tcpTextBox.Multiline = true;
            tcpTextBox.ReadOnly = true;
            tcpTextBox.ScrollBars = ScrollBars.Vertical;

            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 630);
            Controls.Add(buttonStartStopSyslogServer);
            Controls.Add(buttonTrace);
            Controls.Add(buttonDebug);
            Controls.Add(buttonInfo);
            Controls.Add(buttonWarn);
            Controls.Add(buttonError);
            Controls.Add(buttonFatal);
            Controls.Add(buttonFromFile);
            Controls.Add(buttonHuge);
            Controls.Add(buttonMultiple);
            Controls.Add(buttonContinuous);
            Controls.Add(buttonParallel);
            Controls.Add(udpLabel);
            Controls.Add(udpTextBox);
            Controls.Add(tcpLabel);
            Controls.Add(tcpTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormTest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Syslog Target Demo";
            this.FormClosing += new FormClosingEventHandler(OnFormClosing);
            ResumeLayout(false);
        }
    }
}