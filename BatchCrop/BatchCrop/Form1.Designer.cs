﻿namespace BatchCrop {
	partial class MainWndForm {
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
		/// 修改這個方法的內容。
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWndForm));
			this.ImageRootLabel = new System.Windows.Forms.Label();
			this.DirListLabel = new System.Windows.Forms.Label();
			this.ImageListLabel = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.DirList = new System.Windows.Forms.Label();
			this.ImageList = new System.Windows.Forms.Label();
			this.btn_save = new System.Windows.Forms.Button();
			this.btn_again = new System.Windows.Forms.Button();
			this.YT_Label = new System.Windows.Forms.Label();
			this.YB_Label = new System.Windows.Forms.Label();
			this.XL_Label = new System.Windows.Forms.Label();
			this.XR_Label = new System.Windows.Forms.Label();
			this.StartLabel = new System.Windows.Forms.Label();
			this.Blocker_Upper = new System.Windows.Forms.Label();
			this.Blocker_Left = new System.Windows.Forms.Label();
			this.Blocker_Right = new System.Windows.Forms.Label();
			this.Blocker_Lower = new System.Windows.Forms.Label();
			this.ImageBbList = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// ImageRootLabel
			// 
			this.ImageRootLabel.BackColor = System.Drawing.Color.Gray;
			this.ImageRootLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.ImageRootLabel.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.ImageRootLabel.ForeColor = System.Drawing.Color.White;
			this.ImageRootLabel.Location = new System.Drawing.Point(12, 8);
			this.ImageRootLabel.Name = "ImageRootLabel";
			this.ImageRootLabel.Size = new System.Drawing.Size(556, 32);
			this.ImageRootLabel.TabIndex = 1;
			this.ImageRootLabel.Text = "點按以選擇包含所有圖片子資料夾的資料夾路徑";
			this.ImageRootLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ImageRootLabel.Click += new System.EventHandler(this.ImageRootLabel_Click);
			// 
			// DirListLabel
			// 
			this.DirListLabel.BackColor = System.Drawing.Color.Gray;
			this.DirListLabel.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.DirListLabel.ForeColor = System.Drawing.Color.White;
			this.DirListLabel.Location = new System.Drawing.Point(12, 47);
			this.DirListLabel.Name = "DirListLabel";
			this.DirListLabel.Size = new System.Drawing.Size(191, 29);
			this.DirListLabel.TabIndex = 2;
			this.DirListLabel.Text = "資料夾列表";
			this.DirListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ImageListLabel
			// 
			this.ImageListLabel.BackColor = System.Drawing.Color.Gray;
			this.ImageListLabel.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.ImageListLabel.ForeColor = System.Drawing.Color.White;
			this.ImageListLabel.Location = new System.Drawing.Point(209, 47);
			this.ImageListLabel.Name = "ImageListLabel";
			this.ImageListLabel.Size = new System.Drawing.Size(501, 29);
			this.ImageListLabel.TabIndex = 3;
			this.ImageListLabel.Text = "所有圖片列表";
			this.ImageListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.Enabled = false;
			this.pictureBox1.Location = new System.Drawing.Point(716, 44);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(512, 512);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// DirList
			// 
			this.DirList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(100)))), ((int)(((byte)(108)))));
			this.DirList.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.DirList.ForeColor = System.Drawing.Color.White;
			this.DirList.Location = new System.Drawing.Point(12, 76);
			this.DirList.Name = "DirList";
			this.DirList.Size = new System.Drawing.Size(191, 546);
			this.DirList.TabIndex = 5;
			// 
			// ImageList
			// 
			this.ImageList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(108)))), ((int)(((byte)(100)))));
			this.ImageList.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.ImageList.ForeColor = System.Drawing.Color.White;
			this.ImageList.Location = new System.Drawing.Point(209, 76);
			this.ImageList.Name = "ImageList";
			this.ImageList.Size = new System.Drawing.Size(281, 546);
			this.ImageList.TabIndex = 6;
			// 
			// btn_save
			// 
			this.btn_save.Enabled = false;
			this.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.PaleGreen;
			this.btn_save.FlatAppearance.BorderSize = 3;
			this.btn_save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(108)))), ((int)(((byte)(100)))));
			this.btn_save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(108)))), ((int)(((byte)(100)))));
			this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_save.Font = new System.Drawing.Font("微軟正黑體", 16F);
			this.btn_save.ForeColor = System.Drawing.Color.White;
			this.btn_save.Location = new System.Drawing.Point(716, 562);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(140, 60);
			this.btn_save.TabIndex = 7;
			this.btn_save.Text = "成功，繼續";
			this.btn_save.UseVisualStyleBackColor = true;
			this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
			// 
			// btn_again
			// 
			this.btn_again.Enabled = false;
			this.btn_again.FlatAppearance.BorderColor = System.Drawing.Color.SkyBlue;
			this.btn_again.FlatAppearance.BorderSize = 3;
			this.btn_again.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(100)))), ((int)(((byte)(108)))));
			this.btn_again.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(100)))), ((int)(((byte)(108)))));
			this.btn_again.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_again.Font = new System.Drawing.Font("微軟正黑體", 16F);
			this.btn_again.ForeColor = System.Drawing.Color.White;
			this.btn_again.Location = new System.Drawing.Point(862, 562);
			this.btn_again.Name = "btn_again";
			this.btn_again.Size = new System.Drawing.Size(140, 60);
			this.btn_again.TabIndex = 8;
			this.btn_again.Text = "失敗，重來";
			this.btn_again.UseVisualStyleBackColor = true;
			this.btn_again.Click += new System.EventHandler(this.btn_again_Click);
			// 
			// YT_Label
			// 
			this.YT_Label.BackColor = System.Drawing.Color.Gray;
			this.YT_Label.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.YT_Label.ForeColor = System.Drawing.Color.White;
			this.YT_Label.Location = new System.Drawing.Point(860, 8);
			this.YT_Label.Name = "YT_Label";
			this.YT_Label.Size = new System.Drawing.Size(140, 33);
			this.YT_Label.TabIndex = 9;
			this.YT_Label.Text = "Y(上) :";
			this.YT_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// YB_Label
			// 
			this.YB_Label.BackColor = System.Drawing.Color.Gray;
			this.YB_Label.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.YB_Label.ForeColor = System.Drawing.Color.White;
			this.YB_Label.Location = new System.Drawing.Point(1088, 559);
			this.YB_Label.Name = "YB_Label";
			this.YB_Label.Size = new System.Drawing.Size(140, 33);
			this.YB_Label.TabIndex = 10;
			this.YB_Label.Text = "Y(下) :";
			this.YB_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// XL_Label
			// 
			this.XL_Label.BackColor = System.Drawing.Color.Gray;
			this.XL_Label.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.XL_Label.ForeColor = System.Drawing.Color.White;
			this.XL_Label.Location = new System.Drawing.Point(716, 8);
			this.XL_Label.Name = "XL_Label";
			this.XL_Label.Size = new System.Drawing.Size(140, 33);
			this.XL_Label.TabIndex = 11;
			this.XL_Label.Text = "X(左) :";
			this.XL_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// XR_Label
			// 
			this.XR_Label.BackColor = System.Drawing.Color.Gray;
			this.XR_Label.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.XR_Label.ForeColor = System.Drawing.Color.White;
			this.XR_Label.Location = new System.Drawing.Point(1088, 8);
			this.XR_Label.Name = "XR_Label";
			this.XR_Label.Size = new System.Drawing.Size(140, 33);
			this.XR_Label.TabIndex = 12;
			this.XR_Label.Text = "X(右) :";
			this.XR_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// StartLabel
			// 
			this.StartLabel.BackColor = System.Drawing.Color.Gray;
			this.StartLabel.Enabled = false;
			this.StartLabel.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.StartLabel.ForeColor = System.Drawing.Color.White;
			this.StartLabel.Location = new System.Drawing.Point(574, 8);
			this.StartLabel.Name = "StartLabel";
			this.StartLabel.Size = new System.Drawing.Size(136, 32);
			this.StartLabel.TabIndex = 13;
			this.StartLabel.Text = "開始";
			this.StartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.StartLabel.Click += new System.EventHandler(this.StartLabel_Click);
			// 
			// Blocker_Upper
			// 
			this.Blocker_Upper.BackColor = System.Drawing.Color.DarkCyan;
			this.Blocker_Upper.Enabled = false;
			this.Blocker_Upper.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.Blocker_Upper.ForeColor = System.Drawing.Color.White;
			this.Blocker_Upper.Location = new System.Drawing.Point(716, 44);
			this.Blocker_Upper.Name = "Blocker_Upper";
			this.Blocker_Upper.Size = new System.Drawing.Size(512, 107);
			this.Blocker_Upper.TabIndex = 14;
			this.Blocker_Upper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Blocker_Left
			// 
			this.Blocker_Left.BackColor = System.Drawing.Color.DarkCyan;
			this.Blocker_Left.Enabled = false;
			this.Blocker_Left.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.Blocker_Left.ForeColor = System.Drawing.Color.White;
			this.Blocker_Left.Location = new System.Drawing.Point(716, 151);
			this.Blocker_Left.Name = "Blocker_Left";
			this.Blocker_Left.Size = new System.Drawing.Size(166, 269);
			this.Blocker_Left.TabIndex = 15;
			this.Blocker_Left.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Blocker_Right
			// 
			this.Blocker_Right.BackColor = System.Drawing.Color.DarkCyan;
			this.Blocker_Right.Enabled = false;
			this.Blocker_Right.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.Blocker_Right.ForeColor = System.Drawing.Color.White;
			this.Blocker_Right.Location = new System.Drawing.Point(1092, 151);
			this.Blocker_Right.Name = "Blocker_Right";
			this.Blocker_Right.Size = new System.Drawing.Size(136, 269);
			this.Blocker_Right.TabIndex = 16;
			this.Blocker_Right.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Blocker_Lower
			// 
			this.Blocker_Lower.BackColor = System.Drawing.Color.DarkCyan;
			this.Blocker_Lower.Enabled = false;
			this.Blocker_Lower.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.Blocker_Lower.ForeColor = System.Drawing.Color.White;
			this.Blocker_Lower.Location = new System.Drawing.Point(716, 420);
			this.Blocker_Lower.Name = "Blocker_Lower";
			this.Blocker_Lower.Size = new System.Drawing.Size(512, 139);
			this.Blocker_Lower.TabIndex = 17;
			this.Blocker_Lower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ImageBbList
			// 
			this.ImageBbList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
			this.ImageBbList.Font = new System.Drawing.Font("微軟正黑體", 14F);
			this.ImageBbList.ForeColor = System.Drawing.Color.White;
			this.ImageBbList.Location = new System.Drawing.Point(490, 76);
			this.ImageBbList.Name = "ImageBbList";
			this.ImageBbList.Size = new System.Drawing.Size(220, 546);
			this.ImageBbList.TabIndex = 18;
			// 
			// MainWndForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(1240, 633);
			this.Controls.Add(this.ImageBbList);
			this.Controls.Add(this.Blocker_Lower);
			this.Controls.Add(this.Blocker_Right);
			this.Controls.Add(this.Blocker_Left);
			this.Controls.Add(this.Blocker_Upper);
			this.Controls.Add(this.StartLabel);
			this.Controls.Add(this.XR_Label);
			this.Controls.Add(this.XL_Label);
			this.Controls.Add(this.YB_Label);
			this.Controls.Add(this.YT_Label);
			this.Controls.Add(this.btn_again);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.ImageList);
			this.Controls.Add(this.DirList);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.ImageListLabel);
			this.Controls.Add(this.DirListLabel);
			this.Controls.Add(this.ImageRootLabel);
			this.Font = new System.Drawing.Font("微軟正黑體", 12F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainWndForm";
			this.Text = "圖片切割小工具";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label ImageRootLabel;
		private System.Windows.Forms.Label DirListLabel;
		private System.Windows.Forms.Label ImageListLabel;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label DirList;
		private System.Windows.Forms.Label ImageList;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_again;
		private System.Windows.Forms.Label YT_Label;
		private System.Windows.Forms.Label YB_Label;
		private System.Windows.Forms.Label XL_Label;
		private System.Windows.Forms.Label XR_Label;
		private System.Windows.Forms.Label StartLabel;
		private System.Windows.Forms.Label Blocker_Upper;
		private System.Windows.Forms.Label Blocker_Left;
		private System.Windows.Forms.Label Blocker_Right;
		private System.Windows.Forms.Label Blocker_Lower;
		private System.Windows.Forms.Label ImageBbList;
	}
}

