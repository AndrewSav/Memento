﻿/**
 * MetroFramework - Modern UI for WinForms
 * 
 * The MIT License (MIT)
 * Copyright (c) 2011 Sven Walter, http://github.com/viperneo
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of 
 * this software and associated documentation files (the "Software"), to deal in the 
 * Software without restriction, including without limitation the rights to use, copy, 
 * modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
 * and to permit persons to whom the Software is furnished to do so, subject to the 
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
 * CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
 * OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using MetroFramework.Animation;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using MetroFramework.Native;

namespace MetroFramework.Forms
{
    public sealed class MetroTaskWindow : MetroForm
    {
        private static MetroTaskWindow singletonWindow;
        public static void ShowTaskWindow(IWin32Window parent, string title, Control userControl, int secToClose)
        {
            if (singletonWindow != null)
            {
                singletonWindow.Close();
                singletonWindow.Dispose();
                singletonWindow = null;
            }

            singletonWindow = new(secToClose, userControl);
            singletonWindow.Text = title;
            singletonWindow.Resizable = false;
            singletonWindow.Movable = true;
            singletonWindow.StartPosition = FormStartPosition.Manual;
            
            if (parent != null && parent is IMetroForm)
            {
                singletonWindow.Theme = ((IMetroForm)parent).Theme;
                singletonWindow.Style = ((IMetroForm)parent).Style;
                singletonWindow.StyleManager = ((IMetroForm)parent).StyleManager.Clone(singletonWindow) as MetroStyleManager;
            }

            singletonWindow.Show();
        }

        public static bool IsVisible()
        {
            return (singletonWindow != null && singletonWindow.Visible);
        }

        public static void ShowTaskWindow(IWin32Window parent, string text, Control userControl)
        {
            ShowTaskWindow(parent, text, userControl, 0);
        }

        public static void ShowTaskWindow(string text, Control userControl, int secToClose)
        {
            ShowTaskWindow(null, text, userControl, secToClose);
        }

        public static void ShowTaskWindow(string text, Control userControl)
        {
            ShowTaskWindow(null, text, userControl);
        }

        public static void CancelAutoClose()
        {
            if (singletonWindow != null)
                singletonWindow.CancelTimer = true;
        }

        public static void ForceClose()
        {
            if (singletonWindow != null)
            {
                CancelAutoClose();
                singletonWindow.Close();
                singletonWindow.Dispose();
                singletonWindow = null;
            }
        }

        private bool cancelTimer = false;
        public bool CancelTimer
        {
            get { return cancelTimer; }
            set { cancelTimer = value; }
        }

        private readonly int closeTime = 0;
        private int elapsedTime = 0;
        private int progressWidth = 0;
        private DelayedCall timer;

        private readonly MetroPanel controlContainer;

        public MetroTaskWindow()
        {
            controlContainer = new();
            Controls.Add(controlContainer);
        }

        public MetroTaskWindow(int duration, Control userControl)
            : this()
        {
            controlContainer.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            closeTime = duration * 500;

            if (closeTime > 0)
                timer = DelayedCall.Start(UpdateProgress, 5);
        }


        private bool isInitialized = false;
        protected override void OnActivated(EventArgs e)
        {
            if (!isInitialized)
            {
                controlContainer.Theme = Theme;
                controlContainer.Style = Style;
                controlContainer.StyleManager = StyleManager;

                MaximizeBox = false;
                MinimizeBox = false;
                Movable = true;

                TopMost = true;

                Size = new(400, 200);

                Taskbar myTaskbar = new();
                switch (myTaskbar.Position)
                {
                    case TaskbarPosition.Left:
                        Location = new(myTaskbar.Bounds.Width + 5, myTaskbar.Bounds.Height - Height - 5);
                        break;
                    case TaskbarPosition.Top:
                        Location = new(myTaskbar.Bounds.Width - Width - 5, myTaskbar.Bounds.Height + 5);
                        break;
                    case TaskbarPosition.Right:
                        Location = new(myTaskbar.Bounds.X - Width - 5, myTaskbar.Bounds.Height - Height - 5);
                        break;
                    case TaskbarPosition.Bottom:
                        Location = new(myTaskbar.Bounds.Width - Width - 5, myTaskbar.Bounds.Y - Height - 5);
                        break;
                    case TaskbarPosition.Unknown:
                    default:
                        Location = new(Screen.PrimaryScreen.Bounds.Width - Width - 5, Screen.PrimaryScreen.Bounds.Height - Height - 5);
                        break;
                }

                controlContainer.Location = new(0, 60);
                controlContainer.Size = new(Width - 40, Height - 80);
                controlContainer.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;

                controlContainer.AutoScroll = false;
                controlContainer.HorizontalScrollbar = false;
                controlContainer.VerticalScrollbar = false;
                controlContainer.Refresh();

                if (StyleManager != null)
                {
                    StyleManager.Update();
                }

                isInitialized = true;

                MoveAnimation myMoveAnim = new();
                myMoveAnim.Start(controlContainer, new(20, 60), TransitionType.EaseInOutCubic, 15);
            }

            base.OnActivated(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (SolidBrush b = new(MetroPaint.BackColor.Form(Theme)))
            {
                e.Graphics.FillRectangle(b, new(Width - progressWidth, 0, progressWidth, 5));
            }
        }

        private void UpdateProgress()
        {
            if (elapsedTime == closeTime)
            {
                timer.Dispose();
                timer = null;
                Close();
                return;
            }

            elapsedTime += 5;

            if (cancelTimer)
                elapsedTime = 0;

            double perc = (double)elapsedTime / ((double)closeTime / 100);
            progressWidth = (int)((double)Width * (perc / 100));
            Invalidate(new Rectangle(0,0,Width,5));

            if (!cancelTimer)
                timer.Reset();
        }
    }
}
