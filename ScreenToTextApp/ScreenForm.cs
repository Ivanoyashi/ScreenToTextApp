using ScreenToTextApp.Recognition;
using ScreenToTextApp.Screening;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenToTextApp
{
    public partial class ScreenForm : Form
    {
        private Rectangle _selectedRectangle;
        private readonly TextRecognizer _textRecognizer;

        public ScreenForm()
        {
            InitializeComponent();

            BindEventHandlers();

            ConfigureForm();

            this._textRecognizer = new TextRecognizer();
        }

        private void BindEventHandlers()
        {
            this.CloseAppBtn.Click += (o, e) => Application.Exit();
        }

        private void ConfigureForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Maximized;
            this.KeyPreview = true;

            this.BackgroundImage = ScreenShot.GetScreenShot();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.CloseAppBtn.Location = new Point(this.Width - this.CloseAppBtn.Width, 0);

            base.OnSizeChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this._selectedRectangle.Location = e.Location;
        }

        protected override async void OnMouseUp(MouseEventArgs e)
        {
            try
            {
                if (this._selectedRectangle.Width > 0 && this._selectedRectangle.Height > 0)
                {
                    var bmp = ScreenShot.GetSelectedArea(this._selectedRectangle, this.BackgroundImage);

                    var text = await this._textRecognizer.RecognizeAsync(bmp);

                    Clipboard.SetText(text);

                    this._selectedRectangle.Size = Size.Empty;

                    Invalidate();

                    Application.Exit();

                    CreateNotification(title: "Текст сохранен",
                        body: "Для вставки нажмите CTRL+V. Для выбора WIN+V", ToolTipIcon.Info);
                }
            }
            catch (IronSoftware.Exceptions.LicensingException)
            {
                throw new Exception("The developers of Iron Ocr want money to run not in VS (I don't have it). Run in Visual Studio");
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                CreateNotification(title: "Ошибка",
                        body: "Не удалось получить текст из изображения", ToolTipIcon.Error);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var newSize = new Size(e.X - this._selectedRectangle.Left, e.Y - this._selectedRectangle.Top);

                if (newSize.Width > 5 && newSize.Height > 5)
                {
                    this._selectedRectangle.Size = newSize;
                    Invalidate();
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();

            base.OnKeyDown(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var region = new Region(this.ClientRectangle);
            region.Exclude(this._selectedRectangle);

            using var brush = new SolidBrush(Color.FromArgb(90, 0, 0, 0));
            e.Graphics.FillRegion(brush, region);
        }

        // todo: need move
        private void CreateNotification(string title, string body, ToolTipIcon toolTipIcon)
        {
            // todo: need move
            NotifyIcon notification = new()
            {
                BalloonTipText = body,
                BalloonTipTitle = title,
                BalloonTipIcon = toolTipIcon,
                Icon = this.Icon,
                Visible = true
            };

            notification.ShowBalloonTip(5000);
        }
    }
}
