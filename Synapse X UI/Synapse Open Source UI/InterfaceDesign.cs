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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Synapse_X_UI
{
    /// <summary>
    /// title: InterfaceDesign.cs
    /// description: Interface design class, contains ui animation methods
    /// author: brack4712
    /// </summary>
    class InterfaceDesign : Window
    {
        private TimeSpan duration = TimeSpan.FromSeconds(1);
        private IEasingFunction ease = new QuarticEase { EasingMode = EasingMode.EaseInOut };

        public void setDuration(TimeSpan newDuration)
        {
            duration = newDuration;
        }

        public IEasingFunction getEase()
        {
            return ease;
        }

        public InterfaceDesign(TimeSpan? timeSpan = null, IEasingFunction easingFunction = null)
        {
            if (timeSpan != null)
            {
                duration = (TimeSpan)timeSpan;
            }

            if (easingFunction != null)
            {
                ease = easingFunction;
            }
        }

        public void FadeIn(DependencyObject element)
        {
            DoubleAnimation fadeAnimation = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = duration,
                EasingFunction = ease
            };

            Storyboard.SetTarget(fadeAnimation, element);
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath(OpacityProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(fadeAnimation);
            storyboard.Begin();
        }

        public void FadeOut(DependencyObject element)
        {
            DoubleAnimation fadeAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = duration,
                EasingFunction = ease
            };

            Storyboard.SetTarget(fadeAnimation, element);
            Storyboard.SetTargetProperty(fadeAnimation, new PropertyPath(OpacityProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(fadeAnimation);
            storyboard.Begin();
        }

        public void Shift(DependencyObject element, Thickness from, Thickness to)
        {
            ThicknessAnimation shiftAnimation = new ThicknessAnimation()
            {
                From = from,
                To = to,
                Duration = duration,
                EasingFunction = ease
            };

            Storyboard.SetTarget(shiftAnimation, element);
            Storyboard.SetTargetProperty(shiftAnimation, new PropertyPath(MarginProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(shiftAnimation);
            storyboard.Begin();
        }

        public void ShiftWindow(Window window, double leftFrom, double topFrom, double leftTo, double topTo)
        {
            DoubleAnimation leftAnimation = new DoubleAnimation()
            {
                From = leftFrom,
                To = leftTo,
                Duration = duration,
                EasingFunction = ease
            };

            DoubleAnimation topAnimation = new DoubleAnimation()
            {
                From = topFrom,
                To = topTo,
                Duration = duration,
                EasingFunction = ease
            };

            Storyboard.SetTarget(leftAnimation, window);
            Storyboard.SetTargetProperty(leftAnimation, new PropertyPath(LeftProperty));

            Storyboard.SetTarget(topAnimation, window);
            Storyboard.SetTargetProperty(topAnimation, new PropertyPath(TopProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(leftAnimation);
            storyboard.Children.Add(topAnimation);
            storyboard.Begin();
        }

        public void ShiftWindowZero(Window window, double leftFrom, double topFrom, double leftTo, double topTo)
        {
            DoubleAnimation leftAnimation = new DoubleAnimation()
            {
                From = leftFrom,
                To = leftTo,
                Duration = TimeSpan.Zero,
                EasingFunction = ease
            };

            DoubleAnimation topAnimation = new DoubleAnimation()
            {
                From = topFrom,
                To = topTo,
                Duration = TimeSpan.Zero,
                EasingFunction = ease
            };

            Storyboard.SetTarget(leftAnimation, window);
            Storyboard.SetTargetProperty(leftAnimation, new PropertyPath(LeftProperty));

            Storyboard.SetTarget(topAnimation, window);
            Storyboard.SetTargetProperty(topAnimation, new PropertyPath(TopProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(leftAnimation);
            storyboard.Children.Add(topAnimation);
            storyboard.Begin();
        }

        public void Resize(DependencyObject element, double height, double width)
        {
            DoubleAnimation heightAnimation = new DoubleAnimation()
            {
                From = (double)element.GetValue(ActualHeightProperty),
                To = height,
                Duration = duration,
                EasingFunction = ease
            };

            DoubleAnimation widthAnimation = new DoubleAnimation()
            {
                From = (double)element.GetValue(ActualWidthProperty),
                To = width,
                Duration = duration,
                EasingFunction = ease
            };


            Storyboard.SetTarget(heightAnimation, element);
            Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(HeightProperty));

            Storyboard.SetTarget(widthAnimation, element);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(WidthProperty));


            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(heightAnimation);
            storyboard.Children.Add(widthAnimation);
            storyboard.Begin();
        }

        public void FontColor(DependencyObject element, string from, string to)
        {
            ColorAnimation colorAnimation = new ColorAnimation()
            {
                From = (Color)ColorConverter.ConvertFromString(from),
                To = (Color)ColorConverter.ConvertFromString(to),
                Duration = duration,
                EasingFunction = ease
            };

            Storyboard.SetTarget(colorAnimation, element);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Label.Foreground).(SolidColorBrush.Color)"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(colorAnimation);
            storyboard.Begin();
        }

        public void ButtonColor(DependencyObject element, string from, string to)
        {
            ColorAnimation colorAnimation = new ColorAnimation()
            {
                From = (Color)ColorConverter.ConvertFromString(from),
                To = (Color)ColorConverter.ConvertFromString(to),
                Duration = duration,
                EasingFunction = ease
            };

            Storyboard.SetTarget(colorAnimation, element);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Button.Background).(SolidColorBrush.Color)"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(colorAnimation);
            storyboard.Begin();
        }
    }
}
