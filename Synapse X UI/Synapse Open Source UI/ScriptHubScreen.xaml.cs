/*
    Synapse X UI
    Copyright (C) 2019 Synapse G.P.

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published
    by the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using sxlib.Specialized;

namespace Synapse_X_UI
{
    /// <summary>
    /// Interaction logic for ScriptHubScreen.xaml
    /// </summary>
    public partial class ScriptHubScreen
    {
        private readonly InterfaceDesign designMethods;
        private readonly Window window;
        private SxLibBase.SynHubEntry currentEntry;
        private readonly Dictionary<string, SxLibBase.SynHubEntry> hubData = new Dictionary<string, SxLibBase.SynHubEntry>();
        private bool active;

        public ScriptHubScreen(Window curWindow, List<SxLibBase.SynHubEntry> entries)
        {
            InitializeComponent();
            designMethods = new InterfaceDesign();
            window = curWindow;
            Left = curWindow.Left + 400;
            Top = curWindow.Top;

            foreach (var Script in entries)
            {
                hubData[Script.Name] = Script;
                synScripts.Items.Add(Script.Name);
            }

            Title = Globals.RandomString(Globals.Rnd.Next(10, 32));
        }

        private async void ScriptHubScreen_OnLoaded(object sender, RoutedEventArgs e)
        {
            designMethods.ShiftWindow(scriptHubScreen, Left, Top, Left + 325, Top);
            await Task.Delay(1000);
            active = true;
            ExploitScreen.debounce = false;
            window.LocationChanged += Window_LocationChanged;
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            if (!active) return;
            Left = window.Left + 725;
            Top = window.Top;
        }

        private async void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Globals.SxLib.ScriptHubMarkAsClosed();
            window.Focus();
            active = false;
            ExploitScreen.debounce = true;
            designMethods.ShiftWindow(scriptHubScreen, Left, Top, Left - 325, Top);
            await Task.Delay(1000);
            ExploitScreen.debounce = false;
            Close();
        }

        public bool IsOpen()
        {
            return Dispatcher.Invoke(() =>
            {
                return Application.Current.Windows.Cast<Window>().Any(x => x == this);
            });
        }

        private void SynScripts_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (synScripts.SelectedIndex == -1)
            {
                return;
            }

            currentEntry = hubData[synScripts.Items[synScripts.SelectedIndex].ToString()];
            description.Text = currentEntry.Description;

            thumbnail.Source = new BitmapImage(new Uri(currentEntry.Picture));
        }

        private void ExecuteButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (currentEntry == null) return;

            if (!Globals.SxLib.Ready())
            {
                executeButton.Content = "Not attached!";

                new Thread(() =>
                {
                    Thread.Sleep(1500);
                    if (!IsOpen()) return;

                    Dispatcher.Invoke(() =>
                    {
                        executeButton.Content = "Execute";
                    });
                }).Start();

                return;
            }

            currentEntry.Execute();
        }
    }
}
