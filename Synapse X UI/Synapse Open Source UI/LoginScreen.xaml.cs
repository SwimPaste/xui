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

using System.Windows;

namespace Synapse_X_UI
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void LoginScreen_OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // to be implemented
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // to be implemented
        private void forgotButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // to be implemented
        private void serialButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
