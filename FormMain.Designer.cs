namespace nf
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Create = new System.Windows.Forms.Button();
            this.OutArea = new System.Windows.Forms.TextBox();
            this.checkCreateImage = new System.Windows.Forms.CheckBox();
            this.checkCreateMeta = new System.Windows.Forms.CheckBox();
            this.numericUpDownNOut = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkInsDeploy = new System.Windows.Forms.CheckBox();
            this.checkCreateScv = new System.Windows.Forms.CheckBox();
            this.checkMetaCollection = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            this.SuspendLayout();
            // 
            // Create
            // 
            this.Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Create.Location = new System.Drawing.Point(279, 106);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(193, 60);
            this.Create.TabIndex = 7;
            this.Create.Text = "Create";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // OutArea
            // 
            this.OutArea.Location = new System.Drawing.Point(576, 106);
            this.OutArea.Name = "OutArea";
            this.OutArea.Size = new System.Drawing.Size(700, 31);
            this.OutArea.TabIndex = 8;
            // 
            // checkCreateImage
            // 
            this.checkCreateImage.AutoSize = true;
            this.checkCreateImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkCreateImage.Location = new System.Drawing.Point(82, 251);
            this.checkCreateImage.Name = "checkCreateImage";
            this.checkCreateImage.Size = new System.Drawing.Size(497, 41);
            this.checkCreateImage.TabIndex = 9;
            this.checkCreateImage.Text = "Создавать файлы изображений";
            this.checkCreateImage.UseVisualStyleBackColor = true;
            this.checkCreateImage.CheckedChanged += new System.EventHandler(this.checkCreateImage_CheckedChanged);
            // 
            // checkCreateMeta
            // 
            this.checkCreateMeta.AutoSize = true;
            this.checkCreateMeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkCreateMeta.Location = new System.Drawing.Point(983, 222);
            this.checkCreateMeta.Name = "checkCreateMeta";
            this.checkCreateMeta.Size = new System.Drawing.Size(433, 41);
            this.checkCreateMeta.TabIndex = 10;
            this.checkCreateMeta.Text = "Создавать meta файлы Nft";
            this.checkCreateMeta.UseVisualStyleBackColor = true;
            this.checkCreateMeta.CheckedChanged += new System.EventHandler(this.checkCreateMeta_CheckedChanged);
            // 
            // numericUpDownNOut
            // 
            this.numericUpDownNOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownNOut.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownNOut.Location = new System.Drawing.Point(1534, 409);
            this.numericUpDownNOut.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownNOut.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNOut.Name = "numericUpDownNOut";
            this.numericUpDownNOut.Size = new System.Drawing.Size(120, 44);
            this.numericUpDownNOut.TabIndex = 12;
            this.numericUpDownNOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownNOut.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownNOut.ValueChanged += new System.EventHandler(this.numericUpDownNOut_ValueChanged);
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownSize.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSize.Location = new System.Drawing.Point(796, 312);
            this.numericUpDownSize.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownSize.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(120, 44);
            this.numericUpDownSize.TabIndex = 13;
            this.numericUpDownSize.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numericUpDownSize.ValueChanged += new System.EventHandler(this.numericUpDownSize_ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(976, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 37);
            this.label1.TabIndex = 14;
            this.label1.Text = "Количество выходных элементов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(75, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(642, 37);
            this.label2.TabIndex = 15;
            this.label2.Text = "Разрешение выходных файлов изображений";
            // 
            // checkInsDeploy
            // 
            this.checkInsDeploy.AutoSize = true;
            this.checkInsDeploy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkInsDeploy.Location = new System.Drawing.Point(983, 316);
            this.checkInsDeploy.Name = "checkInsDeploy";
            this.checkInsDeploy.Size = new System.Drawing.Size(747, 41);
            this.checkInsDeploy.TabIndex = 16;
            this.checkInsDeploy.Text = "Создать файл-инструкцию по развертыванию  Nft";
            this.checkInsDeploy.UseVisualStyleBackColor = true;
            this.checkInsDeploy.CheckedChanged += new System.EventHandler(this.checkInsDeploy_CheckedChanged);
            // 
            // checkCreateScv
            // 
            this.checkCreateScv.AutoSize = true;
            this.checkCreateScv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkCreateScv.Location = new System.Drawing.Point(983, 269);
            this.checkCreateScv.Name = "checkCreateScv";
            this.checkCreateScv.Size = new System.Drawing.Size(690, 41);
            this.checkCreateScv.TabIndex = 17;
            this.checkCreateScv.Text = "Создавать Scv файл с адресами владельцев";
            this.checkCreateScv.UseVisualStyleBackColor = true;
            this.checkCreateScv.CheckedChanged += new System.EventHandler(this.checkCreateScv_CheckedChanged);
            // 
            // checkMetaCollection
            // 
            this.checkMetaCollection.AutoSize = true;
            this.checkMetaCollection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkMetaCollection.Location = new System.Drawing.Point(983, 175);
            this.checkMetaCollection.Name = "checkMetaCollection";
            this.checkMetaCollection.Size = new System.Drawing.Size(518, 41);
            this.checkMetaCollection.TabIndex = 19;
            this.checkMetaCollection.Text = "Создавать meta файл коллекции";
            this.checkMetaCollection.UseVisualStyleBackColor = true;
            this.checkMetaCollection.CheckedChanged += new System.EventHandler(this.checkMetaCollection_CheckedChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(1534, 94);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(221, 49);
            this.buttonSave.TabIndex = 20;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Location = new System.Drawing.Point(1534, 605);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(169, 88);
            this.buttonExit.TabIndex = 21;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2465, 1226);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.checkMetaCollection);
            this.Controls.Add(this.checkCreateScv);
            this.Controls.Add(this.checkInsDeploy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownSize);
            this.Controls.Add(this.numericUpDownNOut);
            this.Controls.Add(this.checkCreateMeta);
            this.Controls.Add(this.checkCreateImage);
            this.Controls.Add(this.OutArea);
            this.Controls.Add(this.Create);
            this.Name = "FormMain";
            this.Text = "ParseAuc";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.TextBox OutArea;
        private System.Windows.Forms.CheckBox checkCreateImage;
        private System.Windows.Forms.CheckBox checkCreateMeta;
        private System.Windows.Forms.NumericUpDown numericUpDownNOut;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkInsDeploy;
        private System.Windows.Forms.CheckBox checkCreateScv;
        private System.Windows.Forms.CheckBox checkMetaCollection;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonExit;
    }
}

